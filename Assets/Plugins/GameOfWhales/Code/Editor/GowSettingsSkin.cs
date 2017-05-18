using UnityEngine;
using System.Collections;


namespace GameOfWhales.Editor {
    public class GowSettingsSkin {

        private static GUIStyle _label;
        private static GUIStyle _errorLabel;
        private static GUIStyle _labelRight;
        private static GUIStyle _textField;
        private static GUIStyle _passwordField;
        private static GUIStyle _toggle;
        private static GUIStyle _button;
        private static GUIStyle _buttonLogout;
        private static GUIStyle _fetchButton;
        private static GUIStyle _addButton;
        private static GUIStyle _popup;

        public static GUIStyle label {
            get {
                if (_label == null) {
                    _label = new GUIStyle(GUI.skin.label);
                    _label.alignment = TextAnchor.MiddleLeft;
                }
                return _label;
            }
        }

        public static GUIStyle errorLabel {
            get {
                if (_errorLabel == null) {
                    _errorLabel = new GUIStyle(GUI.skin.label);
                    _errorLabel.alignment = TextAnchor.MiddleLeft;
                    _errorLabel.normal.textColor = Color.red;
                }
                return _errorLabel;
            }
        }

        public static GUIStyle labelRight {
            get {
                if (_labelRight == null) {
                    _labelRight = new GUIStyle(GUI.skin.label);
                    _labelRight.alignment = TextAnchor.MiddleRight;
                }
                return _labelRight;
            }
        }

        public static GUIStyle textField {
            get {
                if (_textField == null) {
                    _textField = new GUIStyle(GUI.skin.textArea);
                    _textField.alignment = TextAnchor.MiddleLeft;
                }
                return _textField;
            }
        }

        public static GUIStyle passwordField {
            get {
                return textField;
            }
        }

        public static GUIStyle toggle {
            get {
                if (_toggle == null) {
                    _toggle = new GUIStyle(GUI.skin.toggle);
                    _toggle.alignment = TextAnchor.MiddleLeft;
                    _toggle.richText = true;
                }
                return _toggle;
            }
        }

        public static GUIStyle button {
            get {
                if (_button == null) {
                    _button = new GUIStyle(GUI.skin.button);
                    _button.alignment = TextAnchor.MiddleCenter;
                    _button.fixedHeight = 18;
                }
                return _button;
            }
        }

        public static GUIStyle buttonLogout {
            get {
                if (_buttonLogout == null) {
                    _buttonLogout = new GUIStyle(GUI.skin.button);
                    _buttonLogout.fixedHeight = 18;
                    _buttonLogout.fixedWidth = 100;
                }
                return _buttonLogout;
            }
        }

        public static GUIStyle fetchButton {
            get {
                if (_fetchButton == null) {
                    _fetchButton = new GUIStyle(GUI.skin.button);
                    _fetchButton.alignment = TextAnchor.MiddleLeft;
                    _fetchButton.padding = new RectOffset(1, 1, 1, 1);
                    _fetchButton.fixedWidth = 18;
                    _fetchButton.fixedHeight = 18;
                }
                return _fetchButton;
            }
        }

        public static GUIStyle addButton {
            get {
                if (_addButton == null) {
                    _addButton = new GUIStyle(GUI.skin.button);
                    _addButton.alignment = TextAnchor.MiddleLeft;
                    _addButton.padding = new RectOffset(4, 4, 2, 4);
                    _addButton.fixedWidth = 18;
                    _addButton.fixedHeight = 18;
                }
                return _addButton;
            }
        }

        public static GUIStyle popup {
            get {
                if (_popup == null) {
                    _popup = new GUIStyle(UnityEditor.EditorStyles.popup);
                    _popup.alignment = TextAnchor.MiddleLeft;
                    _popup.margin.top = 3;
                    _popup.fixedHeight = 18;
                }
                return _popup;
            }
        }
    }
}
