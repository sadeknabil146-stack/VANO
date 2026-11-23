using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Vano.Editor
{
    public static class BuildScript
    {
        [MenuItem("Vano/Build Android APK")]
        public static void BuildAndroid()
        {
            PlayerSettings.companyName = "VanoGames";
            PlayerSettings.productName = "VANO Last Ride";
            PlayerSettings.applicationIdentifier = "com.vanogames.vanolastride";
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
            PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
            PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeLeft;

            var scenes = new[] { "Assets/_Project/Scenes/Prototype.unity" };
            string outPath = "Builds/VANO.apk";
            System.IO.Directory.CreateDirectory("Builds");
            var report = BuildPipeline.BuildPlayer(scenes, outPath, BuildTarget.Android, BuildOptions.Development);
            if (report.summary.result == BuildResult.Succeeded)
                Debug.Log("Build succeeded: " + outPath);
            else
                Debug.LogError("Build failed: " + report.summary.result);
        }
    }
}