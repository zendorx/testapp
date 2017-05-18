using UnityEngine;
using UnityEditor;
using System.Collections;
using GameOfWhales.Json;

using GoWMiniJSON = GameOfWhales.Json.MiniJSON;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace GameOfWhales.Editor {
	public class GowSettingsEditorSettings : GowSettingsEditorBase {
		public static void OnGUI(Settings settings, GowSettingsEditor settingsEditor) {

			if (IsTokenValid(settings.token)) {

                EditorGUILayout.BeginHorizontal();
                Label(string.Format("Studio: {0}", settings.selectedStudioName));
                if (Button("Select other", 122)) {
					settings.selectedGameId = null;
					settings.selectedStudioId = null;

					settingsEditor.SetTab(GowSettingsEditor.GOWSettingsTab.Login);
				}
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                Label(string.Format("Game: {0}", settings.selectedGameName));
                if (Button("Select other", 100)) {
                    settings.selectedGameId = null;

					settingsEditor.SetTab(GowSettingsEditor.GOWSettingsTab.Login);
				}
                if (FetchButton()) {
                    var args = new JsonObject();
                    args.Add("game", settings.selectedGameId);
                    args.Add("token", settings.token);

                    SendRequest("games.get", args, response => {

                        var gameObject = response.GetChild("result");

                        settings.selectedGameId = gameObject["_id"].ToString();
                        settings.selectedGameName = gameObject["name"].ToString();
                        settings.selectedGameCategory = gameObject["category"].ToString();
                        settings.gameKey = gameObject["securityKey"].ToString();
                        settings.androidGameId = gameObject["androidAppID"].ToString();
                        settings.androidPublicKey = gameObject["androidPublicKey"].ToString();

                    }, error => { });
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                Label(string.Format("Category: {0}", settings.selectedGameCategory));
                EditorGUILayout.EndHorizontal();
                

                GUILayout.Label(string.Format("Game key: {0}", settings.gameKey));
			} else {
				settings.gameKey = EditorGUILayout.TextField("Game key", settings.gameKey);
			}
			settings.androidGameId = EditorGUILayout.TextField("Firebase Sender Id", settings.androidGameId);
			settings.androidPublicKey = EditorGUILayout.TextField("Android Public Key", settings.androidPublicKey);

            SerializedObject serializedSettings = new UnityEditor.SerializedObject(settings);

            settings.autoConfirmPurchase = EditorGUILayout.Toggle("Autoconfirm purchase", settings.autoConfirmPurchase);

            if (settings.autoConfirmPurchase) {
                settings.autoConfirmPurchaseWhenError = EditorGUILayout.Toggle("Autoconfirm purchase when error", settings.autoConfirmPurchaseWhenError);
            }

            settings.autoSubscribeToNotifications = EditorGUILayout.Toggle("Autosubscribe to notifications", settings.autoSubscribeToNotifications);

            settings.loggingEnabled = EditorGUILayout.Toggle("Enable logging", settings.loggingEnabled);

			serializedSettings.ApplyModifiedProperties();

			if (GUI.changed) {
				EditorUtility.SetDirty(settings);
			}

			// settings.loggingEnabled = EditorGUILayout.Toggle("Enable logging", settings.loggingEnabled);
		}
	}
}
