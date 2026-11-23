using UnityEditor;
using UnityEditor.SceneManagement;

namespace Vano.Editor
{
    [InitializeOnLoad]
    public static class AutoOpenScene
    {
        static AutoOpenScene()
        {
            EditorApplication.delayCall += () =>
            {
                if (EditorSceneManager.GetActiveScene().name != "Prototype")
                {
                    var scene = AssetDatabase.LoadAssetAtPath<SceneAsset>("Assets/_Project/Scenes/Prototype.unity");
                    if (scene != null)
                        EditorSceneManager.OpenScene("Assets/_Project/Scenes/Prototype.unity");
                }
            };
        }
    }
}