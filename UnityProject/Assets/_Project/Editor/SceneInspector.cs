using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Vano.Editor
{
    public static class SceneInspector
    {
        [MenuItem("Vano/Inspect Scene")]
        public static void Inspect()
        {
            var scene = EditorSceneManager.OpenScene("Assets/_Project/Scenes/Prototype.unity");
            Debug.Log("=== SCENE INSPECT: " + scene.name + " ===");
            foreach (var go in scene.GetRootGameObjects())
            {
                Debug.Log("ROOT: " + go.name);
                foreach (var c in go.GetComponents<Component>())
                    Debug.Log("   COMP: " + c.GetType().Name);
                foreach (var child in GetAllChildren(go))
                {
                    Debug.Log("  CHILD: " + child.name);
                    foreach (var c in child.GetComponents<Component>())
                        Debug.Log("     COMP: " + c.GetType().Name);
                }
            }
            // Check key refs
            var cam = GameObject.Find("Main Camera");
            if (cam != null)
            {
                var tpc = cam.GetComponent<ThirdPersonCamera>();
                if (tpc != null)
                {
                    var so = new SerializedObject(tpc);
                    Debug.Log("CAM target: " + so.FindProperty("target").objectReferenceValue);
                    Debug.Log("CAM player: " + so.FindProperty("player").objectReferenceValue);
                }
            }
            var player = GameObject.Find("Player");
            if (player != null)
            {
                var pc = player.GetComponent<PlayerController>();
                if (pc != null)
                {
                    var so = new SerializedObject(pc);
                    Debug.Log("PLAYER input: " + so.FindProperty("input").objectReferenceValue);
                    Debug.Log("PLAYER vehicleData: " + so.FindProperty("vehicleData").objectReferenceValue);
                }
                var tc = player.GetComponent<TransformationController>();
                if (tc != null)
                {
                    var so = new SerializedObject(tc);
                    Debug.Log("TRANSFORM vehicles: " + so.FindProperty("vehicles").arraySize);
                }
            }
            var spawner = GameObject.Find("Spawner");
            if (spawner != null)
            {
                var sm = spawner.GetComponent<SpawnManager>();
                if (sm != null)
                {
                    var so = new SerializedObject(sm);
                    Debug.Log("SPAWNER player: " + so.FindProperty("player").objectReferenceValue);
                    Debug.Log("SPAWNER crystalPrefab: " + so.FindProperty("crystalPrefab").objectReferenceValue);
                    Debug.Log("SPAWNER obstaclePrefab: " + so.FindProperty("obstaclePrefab").objectReferenceValue);
                }
            }
            Debug.Log("=== END INSPECT ===");
        }

        private static System.Collections.Generic.List<GameObject> GetAllChildren(GameObject go)
        {
            var list = new System.Collections.Generic.List<GameObject>();
            foreach (Transform t in go.transform)
            {
                list.Add(t.gameObject);
                list.AddRange(GetAllChildren(t.gameObject));
            }
            return list;
        }
    }
}
