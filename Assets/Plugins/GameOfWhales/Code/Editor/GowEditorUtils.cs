using System;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace GameOfWhales {
	public class GowEditorUtils:MonoBehaviour {
		[MenuItem ("Assets/Game of Whales/Settings", false, 0)]
		private static void OpenSettings () {
			if(Settings.instance == null) {
				CreateSettings();
			}
			Selection.activeObject = Settings.instance;
		}

        [MenuItem("Assets/Game of Whales/Create 'GameOfWhales' Controller GameObject", false, 0)]
        private static void CreateGameOfWhalesController() {
            var gameOfWhalesGO = new GameObject(Settings.controllerName);
            gameOfWhalesGO.AddComponent<Controller>();
        }

        private static Settings CreateSettings()
		{
			string path = "Assets/Plugins/GameOfWhales/Resources/"+Settings.settingsResourceName+".asset";

			Directory.CreateDirectory(Application.dataPath + "/Plugins/GameOfWhales/Resources");

			if (File.Exists(path))
			{
				AssetDatabase.DeleteAsset(path);
				AssetDatabase.Refresh();
			}

			var asset = ScriptableObject.CreateInstance<Settings>();
			AssetDatabase.CreateAsset(asset, path);
			AssetDatabase.Refresh();

			AssetDatabase.SaveAssets();
			return asset;
		}
	}
}

