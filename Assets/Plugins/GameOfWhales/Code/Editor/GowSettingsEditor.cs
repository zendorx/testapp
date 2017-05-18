using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using GameOfWhales;
using System.Net;

namespace GameOfWhales.Editor {
	[CustomEditor(typeof(Settings))]
	public class GowSettingsEditor : UnityEditor.Editor {

		public enum GOWSettingsTab {
			Login = 0,
			Custom = 1
		}

		private GOWSettingsTab _tab = GOWSettingsTab.Login;

		private Settings _settings;
 
		public override void OnInspectorGUI() {

			_settings = (Settings)target;

			if (_settings == null) {
				return;
			}

			var logoStyle = new GUIStyle();
			logoStyle.alignment = TextAnchor.MiddleCenter;
			var logoTexture  = Resources.Load<Texture>("gow-logo");

			GUILayout.Label(logoTexture, logoStyle);

			var tabsList = new List<string>();

			System.Enum.GetValues(typeof(GOWSettingsTab)).Cast<GOWSettingsTab>().ForEach(t => {
				tabsList.Add(t.ToString());
			});

			_tab = (GOWSettingsTab)GUILayout.Toolbar((int)_tab, tabsList.ToArray());

			if (_tab == GOWSettingsTab.Login) {
				GowSettingsEditorLogin.OnGUI(_settings, this);
			} else if (_tab == GOWSettingsTab.Custom) {
				GowSettingsEditorSettings.OnGUI(_settings, this);
			}
    	}

		public void SetTab(GOWSettingsTab newTab) {
			_tab = newTab;
		}
	}
}