using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using GameOfWhales;
using GameOfWhales.Json;

using GoWMiniJSON = GameOfWhales.Json.MiniJSON;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace GameOfWhales.Editor {
	public class GowSettingsEditorBase {

        protected static string webErrorLine;

        protected static string[] gameCategories;
        protected static string newGameCategory;

        protected static void SendRequest(string point, JsonObject args, System.Action<JsonObject> success, System.Action<string> failed) {
			var argsBytes = System.Text.Encoding.UTF8.GetBytes(GoWMiniJSON.Serialize(args));
			var request = WebRequest.Create(Settings.serverUrl + "/" + point);
			request.Method = "POST";
			request.ContentType = "application/json";
			request.ContentLength = argsBytes.Length;
            var dataStream = request.GetRequestStream ();
			dataStream.Write(argsBytes, 0, argsBytes.Length);
			dataStream.Close();
            try {
                var response = request.GetResponse();

                webErrorLine = null;

                if (success != null) {
                    success((JsonObject)GoWMiniJSON.Deserialize(GetTextResponse(response)));
                }
            } catch (WebException e) {
                var errorResponse = (JsonObject)GoWMiniJSON.Deserialize(GetTextResponse(e.Response));
                webErrorLine = errorResponse["error"].ToString();
                if (failed != null) {
                    failed(webErrorLine);
                }
                LogUtils.LogError(webErrorLine);
            }
		}

        private static string GetTextResponse(WebResponse response) {
            var data = response.GetResponseStream();

            var reader = new StreamReader(data);
            string textResponse = reader.ReadToEnd();

            return textResponse;
        }

		protected static void Login(string email, string password, System.Action<string> success, System.Action<string> failed) {
			var args = new JsonObject();
			args.Add("email", email.Trim());
			args.Add("password", password);
			args.Add("rememberMe", true);

			SendRequest("user.login", args, loginResponse => {
				if (success != null) {
					success(loginResponse.GetChild("result")["token"].ToString());
				}
			}, error => {
                if (failed != null) {
                    failed(error);
                }
            });
		}

		protected static bool IsTokenValid (string token) {

			if (string.IsNullOrEmpty(token)) {
				return false;
			}

			var decoded = DecodeToken(token);
			var expired = double.Parse(decoded["exp"].ToString());

			DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddSeconds( expired ).ToLocalTime();

			if (dtDateTime > DateTime.Now.ToLocalTime()) {
				return true;
			}

			return false;
		}

		protected static JsonObject DecodeToken(string token) {
			var parts = token.Split('.');
			var header = parts[0];
			var payload = parts[1];
			byte[] crypto = Base64UrlDecode(parts[2]);

			var headerJson = System.Text.Encoding.UTF8.GetString(Base64UrlDecode(header));
			var headerData = (JsonObject)GoWMiniJSON.Deserialize(headerJson);
			var payloadJson = System.Text.Encoding.UTF8.GetString(Base64UrlDecode(payload));
			var payloadData = (JsonObject)GoWMiniJSON.Deserialize(payloadJson);

			return payloadData;
		}

		// from JWT spec
		private static byte[] Base64UrlDecode(string input) {
			var output = input;
			output = output.Replace('-', '+'); // 62nd char of encoding
			output = output.Replace('_', '/'); // 63rd char of encoding
			switch (output.Length % 4) {// Pad with trailing '='s
				case 0: break; // No pad chars in this case
				case 2: output += "=="; break; // Two pad chars
				case 3: output += "="; break; // One pad char
				default: throw new System.Exception("Illegal base64url string!");
			}
			var converted = System.Convert.FromBase64String(output); // Standard base64 decoder
			return converted;
		}

        protected static void DrawErrorLabel() {
            GUIStyle errorStyle = new GUIStyle();
            errorStyle.normal.textColor = Color.red;

            if (!string.IsNullOrEmpty(webErrorLine)) {
                GUILayout.Label(webErrorLine, errorStyle);
            }
        }

        public static void Label(string label) {
            GUILayout.Label(label, GowSettingsSkin.label);
        }

        public static void ErrorLabel(string label) {
            GUILayout.Label(label, GowSettingsSkin.errorLabel);
        }

        public static string TextField(string label, string value) {
            return EditorGUILayout.TextField(label, value, GowSettingsSkin.textField);
        }

        public static string PasswordField(string label, string value) {
            return EditorGUILayout.PasswordField(label, value, GowSettingsSkin.passwordField);
        }

        public static bool Toggle(string label, bool value) {
            return GUILayout.Toggle(value, label, GowSettingsSkin.toggle);
        }

        public static bool FetchButton() {
            return GUILayout.Button(Resources.Load<Texture>("gow-refresh-icon"), GowSettingsSkin.fetchButton);
        }

        public static bool Button(string label) {
            return GUILayout.Button(label, GowSettingsSkin.button); 
        }

        public static bool Button(string label, int width) {
            var newStyle = new GUIStyle(GowSettingsSkin.button);
            newStyle.fixedWidth = width;
            return GUILayout.Button(label, newStyle);
        }

        public static int Popup(int selected, string[] displayedOptions) {
            return EditorGUILayout.Popup(selected, displayedOptions, GowSettingsSkin.popup);
        }

        public static void LabelRight(string label) {
            GUILayout.Label(label, GowSettingsSkin.labelRight);
        }

        public static bool ButtonLogout() {
            return GUILayout.Button("Logout", GowSettingsSkin.buttonLogout);
        }
    }
}