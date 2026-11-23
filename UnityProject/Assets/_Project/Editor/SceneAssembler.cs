using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace Vano.Editor
{
    public static class SceneAssembler
    {
        private const string ScenePath = "Assets/_Project/Scenes/Prototype.unity";
        private const string DataFolder = "Assets/_Project/Data";
        private const string PrefabFolder = "Assets/_Project/Prefabs";

        [MenuItem("Vano/Assemble Prototype Scene")]
        public static void Assemble()
        {
            EnsureFolders();
            var vehicleData = CreateVehicleDataAssets();
            var crystalPrefab = CreateCrystalPrefab();
            var obstaclePrefab = CreateObstaclePrefab();

            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            // --- Ground (sloped plane) ---
            var ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "Ground";
            ground.transform.rotation = Quaternion.Euler(15f, 0f, 0f);
            ground.transform.localScale = new Vector3(6f, 1f, 12f);
            ground.transform.position = new Vector3(0f, 0f, 0f);
            var groundMat = new Material(Shader.Find("Standard"));
            groundMat.color = new Color(0.85f, 0.92f, 0.98f);
            ground.GetComponent<Renderer>().sharedMaterial = groundMat;

            // --- Player ---
            var player = new GameObject("Player");
            player.transform.position = new Vector3(0f, 2f, -5f);
            var cap = player.AddComponent<CapsuleCollider>();
            cap.height = 1.8f; cap.radius = 0.4f; cap.center = new Vector3(0f, 0.9f, 0f);
            var rb = player.AddComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            var input = player.AddComponent<PlayerInput>();
            var pc = player.AddComponent<PlayerController>();
            var tc = player.AddComponent<TransformationController>();

            // wire PlayerController.input
            var soPc = new SerializedObject(pc);
            soPc.FindProperty("input").objectReferenceValue = input;
            soPc.FindProperty("vehicleData").objectReferenceValue = vehicleData[0];
            soPc.ApplyModifiedProperties();

            // wire TransformationController
            var soTc = new SerializedObject(tc);
            soTc.FindProperty("player").objectReferenceValue = pc;
            soTc.FindProperty("input").objectReferenceValue = input;
            var vehProp = soTc.FindProperty("vehicles");
            vehProp.arraySize = vehicleData.Length;
            for (int i = 0; i < vehicleData.Length; i++)
                vehProp.GetArrayElementAtIndex(i).objectReferenceValue = vehicleData[i];
            soTc.ApplyModifiedProperties();

            // --- Camera ---
            var camGO = new GameObject("Main Camera");
            camGO.tag = "MainCamera";
            camGO.transform.position = new Vector3(0f, 6f, -12f);
            camGO.transform.LookAt(new Vector3(0f, 2f, -5f));
            var cam = camGO.AddComponent<Camera>();
            cam.clearFlags = CameraClearFlags.Skybox;
            var tpc = camGO.AddComponent<ThirdPersonCamera>();
            var soCam = new SerializedObject(tpc);
            soCam.FindProperty("target").objectReferenceValue = player.transform;
            soCam.FindProperty("player").objectReferenceValue = pc;
            soCam.ApplyModifiedProperties();

            // --- Light ---
            var lightGO = new GameObject("Directional Light");
            var light = lightGO.AddComponent<Light>();
            light.type = LightType.Directional;
            light.color = new Color(1f, 0.95f, 0.85f);
            light.intensity = 1.1f;
            lightGO.transform.rotation = Quaternion.Euler(50f, -30f, 0f);

            // --- Managers ---
            var managers = new GameObject("Managers");
            managers.AddComponent<GameManager>();
            managers.AddComponent<ScoreManager>();

            // --- Spawner ---
            var spawner = new GameObject("Spawner");
            var sm = spawner.AddComponent<SpawnManager>();
            var soSm = new SerializedObject(sm);
            soSm.FindProperty("player").objectReferenceValue = player.transform;
            soSm.FindProperty("crystalPrefab").objectReferenceValue = crystalPrefab;
            soSm.FindProperty("obstaclePrefab").objectReferenceValue = obstaclePrefab;
            soSm.ApplyModifiedProperties();

            // --- HUD (simple canvas) ---
            CreateHUD(player);

            EditorSceneManager.SaveScene(scene, ScenePath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("VANO: Prototype scene assembled at " + ScenePath);
        }

        private static void EnsureFolders()
        {
            if (!AssetDatabase.IsValidFolder("Assets/_Project")) AssetDatabase.CreateFolder("Assets", "_Project");
            if (!AssetDatabase.IsValidFolder(DataFolder)) AssetDatabase.CreateFolder("Assets/_Project", "Data");
            if (!AssetDatabase.IsValidFolder(PrefabFolder)) AssetDatabase.CreateFolder("Assets/_Project", "Prefabs");
            if (!AssetDatabase.IsValidFolder("Assets/_Project/Editor")) AssetDatabase.CreateFolder("Assets/_Project", "Editor");
        }

        private static VehicleData[] CreateVehicleDataAssets()
        {
            var defs = new (string name, float maxSpeed, float accel, float steer, float jump, float fric, float drift, float slide, float dur, float cd)[]
            {
                ("Standard Snowboard", 28f, 14f, 6f, 7f, 0.60f, 0.25f, 0.75f, 12f, 2f),
                ("Big Snowboard",      26f, 12f, 4f, 5f, 0.70f, 0.35f, 0.70f, 12f, 2f),
                ("Snow Sled",          30f, 15f, 5f, 4f, 0.45f, 0.20f, 0.85f, 12f, 2f),
                ("Snowmobile",         34f, 16f, 8f, 4f, 0.50f, 0.18f, 0.80f, 10f, 2f),
            };
            var arr = new VehicleData[defs.Length];
            for (int i = 0; i < defs.Length; i++)
            {
                var d = defs[i];
                string path = $"{DataFolder}/Vehicle_{i}_{d.name.Replace(" ", "")}.asset";
                var existing = AssetDatabase.LoadAssetAtPath<VehicleData>(path);
                if (existing == null)
                {
                    var v = ScriptableObject.CreateInstance<VehicleData>();
                    v.vehicleName = d.name;
                    v.maxSpeed = d.maxSpeed;
                    v.acceleration = d.accel;
                    v.steerTorque = d.steer;
                    v.jumpForce = d.jump;
                    v.friction = d.fric;
                    v.driftFriction = d.drift;
                    v.slideSpeedMultiplier = d.slide;
                    v.duration = d.dur;
                    v.cooldown = d.cd;
                    AssetDatabase.CreateAsset(v, path);
                    arr[i] = v;
                }
                else
                {
                    arr[i] = existing;
                }
            }
            return arr;
        }

        private static GameObject CreateCrystalPrefab()
        {
            string path = $"{PrefabFolder}/Crystal.prefab";
            var existing = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (existing != null) return existing;

            var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.name = "Crystal";
            go.transform.localScale = Vector3.one * 0.6f;
            var col = go.GetComponent<SphereCollider>();
            col.isTrigger = true;
            var crystal = go.AddComponent<Crystal>();
            var mat = new Material(Shader.Find("Standard"));
            mat.color = new Color(0.3f, 0.8f, 1f);
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", new Color(0.2f, 0.6f, 1f));
            go.GetComponent<Renderer>().sharedMaterial = mat;
            var prefab = PrefabUtility.SaveAsPrefabAsset(go, path);
            Object.DestroyImmediate(go);
            return prefab;
        }

        private static GameObject CreateObstaclePrefab()
        {
            string path = $"{PrefabFolder}/Obstacle.prefab";
            var existing = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (existing != null) return existing;

            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = "Obstacle";
            go.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            var obs = go.AddComponent<Obstacle>();
            var mat = new Material(Shader.Find("Standard"));
            mat.color = new Color(0.55f, 0.35f, 0.2f);
            go.GetComponent<Renderer>().sharedMaterial = mat;
            var prefab = PrefabUtility.SaveAsPrefabAsset(go, path);
            Object.DestroyImmediate(go);
            return prefab;
        }

        private static void CreateHUD(GameObject player)
        {
            // Simple canvas with text fields
            var canvasGO = new GameObject("HUD Canvas");
            var canvas = canvasGO.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasGO.AddComponent<UnityEngine.UI.CanvasScaler>();
            canvasGO.AddComponent<UnityEngine.UI.GraphicRaycaster>();

            var hud = canvasGO.AddComponent<HUDController>();

            // Create text fields
            var scoreText = CreateText(canvasGO.transform, "ScoreText", new Vector2(10, -10), "Score: 0");
            var crystalText = CreateText(canvasGO.transform, "CrystalsText", new Vector2(10, -40), "Crystals: 0");
            var speedText = CreateText(canvasGO.transform, "SpeedText", new Vector2(10, -70), "Speed: 0");
            var vehicleText = CreateText(canvasGO.transform, "VehicleText", new Vector2(10, -100), "Standard Snowboard");

            var soHud = new SerializedObject(hud);
            soHud.FindProperty("scoreText").objectReferenceValue = scoreText;
            soHud.FindProperty("crystalsText").objectReferenceValue = crystalText;
            soHud.FindProperty("speedText").objectReferenceValue = speedText;
            soHud.FindProperty("vehicleText").objectReferenceValue = vehicleText;
            soHud.ApplyModifiedProperties();

            // Restart button (hidden until crash; simple)
            var btnGO = new GameObject("RestartButton");
            btnGO.transform.SetParent(canvasGO.transform, false);
            var btnRect = btnGO.AddComponent<RectTransform>();
            btnRect.anchorMin = new Vector2(0.5f, 0.5f);
            btnRect.anchorMax = new Vector2(0.5f, 0.5f);
            btnRect.anchoredPosition = Vector2.zero;
            btnRect.sizeDelta = new Vector2(200, 60);
            var btnImg = btnGO.AddComponent<UnityEngine.UI.Image>();
            btnImg.color = new Color(0.2f, 0.6f, 1f);
            var btn = btnGO.AddComponent<UnityEngine.UI.Button>();
            var txtGO = new GameObject("Text");
            txtGO.transform.SetParent(btnGO.transform, false);
            var txt = txtGO.AddComponent<UnityEngine.UI.Text>();
            txt.text = "Restart";
            txt.alignment = TextAnchor.MiddleCenter;
            txt.color = Color.white;
            var txtRect = txtGO.GetComponent<RectTransform>();
            txtRect.anchorMin = Vector2.zero; txtRect.anchorMax = Vector2.one;
            txtRect.offsetMin = Vector2.zero; txtRect.offsetMax = Vector2.zero;
            btnGO.AddComponent<RestartButton>();
        }

        private static UnityEngine.UI.Text CreateText(Transform parent, string name, Vector2 pos, string content)
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);
            var rect = go.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0, 1);
            rect.anchorMax = new Vector2(0, 1);
            rect.anchoredPosition = pos;
            rect.sizeDelta = new Vector2(300, 30);
            var t = go.AddComponent<UnityEngine.UI.Text>();
            t.text = content;
            t.fontSize = 20;
            t.color = Color.white;
            // default font
            t.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            if (t.font == null) t.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            return t;
        }
    }
}
