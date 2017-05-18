using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using GameOfWhales.Json;
using System;

using GoWMiniJSON = GameOfWhales.Json.MiniJSON;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;

namespace GameOfWhales.Editor {
	public class GowSettingsEditorLogin : GowSettingsEditorBase {

		private class Studio {
			public string id;
			public string name;
		}

		private class Game {
			public string id;
			public string name;
            public string category;
            public string securityKey;
            public string androidGameID;
            public string androidPublicKey;
        }

		private static string _email;
		private static string _password;

		private static Studio[] _studios;
		private static Game[] _games;

		private static Studio _studio;
		private static Game _game;

		private static string _newStudioName;
		private static string _newGameName;

		public static void Reset() {
			_studios = new Studio[0];
			_games = new Game[0];
			_studio = null;
			_game = null;
			_newStudioName = null;
			_newGameName = null;
		}

        public static void OnGUI(Settings settings, GowSettingsEditor settingsEditor) {

            GUIStyle errorStyle = new GUIStyle();
            errorStyle.normal.textColor = Color.red;

            if (IsTokenValid(settings.token)) {

                EditorGUILayout.BeginHorizontal();
                LabelRight(string.Format("Email: {0}", settings.email));
                if (ButtonLogout()) {
                    Reset();
                    settings.token = null;
                    settings.selectedGameId = null;
                    settings.selectedGameName = null;
                    settings.selectedGameCategory = null;
                    settings.gameKey = null;
                    settings.androidGameId = null;
                    settings.androidPublicKey = null;
					_password = null;
					_studios = null;
					_studio = null;
					_games = null;
					_game = null;
                    EditorUtility.SetDirty(settings);
                    Undo.RecordObject(settings, settings.name);
                    AssetDatabase.SaveAssets();
                }
                EditorGUILayout.EndHorizontal();
            }

            if (!IsTokenValid(settings.token)) {
                if (!string.IsNullOrEmpty(_email)) {
                    _email = _email.Trim();
                }
                _email = EditorGUILayout.TextField("Email", _email);
                _password = EditorGUILayout.PasswordField("Password", _password);

                if (Button("Login")) {
                    if (string.IsNullOrEmpty(_email)) {
                        webErrorLine = "Email cannot be empty";
                    } else if (string.IsNullOrEmpty(_password)) {
                        webErrorLine = "Password cannot be empty";
                    } else {
                        Login(_email, _password, token => {
                            settings.selectedStudioId = null;
                            settings.selectedGameId = null;
                            settings.token = token;
                            settings.email = _email;
                        }, error => {
                        });
                    }
                }
            } else if (_studio == null || string.IsNullOrEmpty(settings.selectedStudioId) || settings.selectedStudioId != _studio.id) {
                DrawSelectStudio(settings);
            } else if (_game == null || string.IsNullOrEmpty(settings.selectedGameId) || settings.selectedGameId != _game.id) {

                DrawSelectStudio(settings);

                DrawSelectGame(settings);

            } else {
                GUILayout.Label("You logged in");
                GowSettingsEditorSettings.OnGUI(settings, settingsEditor);
            }

            DrawErrorLabel();
        }

        private static void DrawSelectStudio(Settings settings) {
            EditorGUILayout.BeginHorizontal();

            if (_studios == null || _studios.Length == 0) {
                _studios = new Studio[] { new Studio { name = "---" } };
                FetchStudios(settings);
            }

            if (_studio == null) {
                if (_studios.Any(s => !string.IsNullOrEmpty(s.id)) && !string.IsNullOrEmpty(settings.selectedStudioId)) {
                    _studio = _studios.Where(s => s.id == settings.selectedStudioId).FirstOrDefault();
                }

                if (_studio == null || (_studio != null && !_studios.Select(s => s.name).Contains(_studio.name))) {
                    _studio = _studios.FirstOrDefault();
                }
            }

            _studio = _studios[Popup(_studio == null ? 0 : Array.IndexOf(_studios.Select(s => s.name).ToArray(), _studio.name), _studios.Select(s => s.name).ToArray())];
            if (FetchButton()) {
                FetchStudios(settings);
            }
            
            if (Button("Select", 100)) {
                if (!string.IsNullOrEmpty(_studio.id)) {
                    settings.selectedStudioId = _studio.id;
                    settings.selectedStudioName = _studio.name;

                    _game = null;

                    FetchGames(settings);
                }
            }

            EditorGUILayout.EndHorizontal();
        }

        private static void FetchStudios(Settings settings) {
            var args = new JsonObject();
            args.Set("token", settings.token);

            SendRequest("studios.list", args, response => {

                var studiosList = new List<Studio>();
                foreach (var studio in response.GetSequence("result")) {
                    var studioObject = studio as JsonObject;
                    var studioName = studioObject["name"].ToString();

                    var sameNameStudios = studiosList.Where(s => s.name == studioName);

                    if (sameNameStudios.Count() > 0) {
                        studioName = string.Format("{0} {1}", studioName, sameNameStudios.Count());
                    }

                    studiosList.Add(new Studio {
                        id = studioObject["_id"].ToString(),
                        name = studioName,
                    });
                }

                if (studiosList.Count == 0) {
                    studiosList.Add(new Studio {
                        name = "---",
                    });
                }

                _studios = studiosList.ToArray();
            }, error => {
            });
        }

        private static void DrawSelectGame(Settings settings) {
            
            EditorGUILayout.BeginHorizontal();

            if (_games == null || _games.Length == 0) {
                _games = new Game[] { new Game { name = "---" } };
                FetchGames(settings);
            }

            if (_games.Any(g => !string.IsNullOrEmpty(g.id)) && !string.IsNullOrEmpty(settings.selectedGameId)) {
                _game = _games.Where(g => g.id == settings.selectedGameId).FirstOrDefault();
            }

            if (_game == null || (_game != null && !_games.Select(g => g.name).Contains(_game.name))) {
                _game = _games.FirstOrDefault();
            }

            _game = _games[Popup(_game == null ? 0 : Array.IndexOf(_games.Select(g => g.name).ToArray(), _game.name), _games.Select(g => g.name).ToArray())];
            if (FetchButton()) {
                FetchGames(settings);
            }
            
            if (Button("Select", 100)) {
                if (!string.IsNullOrEmpty(_game.id)) {
                    settings.selectedGameId = _game.id;
                    settings.selectedGameName = _game.name;
                    settings.selectedGameCategory = _game.category;
                    settings.gameKey = _game.securityKey;
                    settings.androidGameId = _game.androidGameID;
                    settings.androidPublicKey = _game.androidPublicKey;

                    EditorUtility.SetDirty(settings);
                    Undo.RecordObject(settings, settings.name);
                    AssetDatabase.SaveAssets();
                }
            }

            EditorGUILayout.EndHorizontal();
        }

        private static void FetchGames(Settings settings) {

            if (string.IsNullOrEmpty(settings.selectedStudioId)) {
                return;
            }

            var args = new JsonObject();
            args.Set("token", settings.token);
            args.Set("studio", settings.selectedStudioId);

            SendRequest("studios.games", args, response => {
                var gamesList = new List<Game>();
                foreach (var game in response.GetSequence("result")) {
                    var gameObject = game as JsonObject;

                    var gameName = gameObject["name"] == null ? "<null>" : gameObject["name"].ToString();

                    var sameNameGames = gamesList.Where(g => g.name == gameName);

                    if (sameNameGames.Count() > 0) {
                        gameName = string.Format("{0} {1}", gameName, sameNameGames.Count());
                    }

                    if (gameObject["studio"].ToString() == settings.selectedStudioId) {
                        gamesList.Add(new Game {
                            id = gameObject["_id"].ToString(),
                            name = gameName,
                            securityKey = gameObject.ContainsKey("securityKey") && gameObject["securityKey"] != null ? gameObject["securityKey"].ToString() : null,
                            category = gameObject.ContainsKey("category") && gameObject["category"] != null ? gameObject["category"].ToString() : null,
                            androidGameID = gameObject.ContainsKey("androidAppID") && gameObject["androidAppID"] != null ? gameObject["androidAppID"].ToString() : null,
                            androidPublicKey = gameObject.ContainsKey("androidPublicKey") && gameObject["androidPublicKey"] != null ? gameObject["androidPublicKey"].ToString() : null,
                        });
                    }
                }

                if (gamesList.Count == 0) {
                    gamesList.Add(new Game {
                        name = "---",
                    });
                }

                _games = gamesList.ToArray();
            }, error => {
            });
        }
	}
}