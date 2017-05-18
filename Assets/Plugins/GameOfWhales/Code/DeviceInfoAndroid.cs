using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameOfWhales.Json;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;
using GowMiniJSON = GameOfWhales.Json.MiniJSON;

namespace GameOfWhales
{
    public class DeviceInfoAndroid : DeviceInfo
    {
#if UNITY_ANDROID

		private string _advertisingId;
		private event Action<string> _onAdvertisingId;

        private AndroidJavaClass _unity;
        private bool _androidInited;

        public override string platform {
			get {
				return "android";
			}
		}

		protected override IEnumerator C_Init() {
            if (!_androidInited) {
                yield return StartCoroutine(C_CheckAndroidInited(() => { }));
            }
		}

        public void Inited(string data) {
            _androidInited = true;
        }


        public override void GetPlayerId(Action<string> completed) {
			if (completed == null)
				return;
			if (_advertisingId != null) {
				completed(_advertisingId);
			} else {
				_onAdvertisingId += completed;
			}
		}

		private void AndroidOnAdvertisingId(string id){
			_advertisingId = id;

			if (_onAdvertisingId != null) {
				_onAdvertisingId(id);
				_onAdvertisingId = null;
			}
		}

		protected override void ProcessGetDeviceToken() {
            _unity.CallStatic("requestDeviceToken");
        }

		private void AndroidOnDeviceToken(string deviceToken){
			OnDeviceTokenReceived(deviceToken);
		}

        private IEnumerator C_CheckAndroidInited(Action callBack) {
            if (!_androidInited) {
                _unity = new AndroidJavaClass("com.gameofwhales.plugin.unity.Unity");
                _unity.CallStatic("init", Settings.serverUrl, Settings.instance.gameKey, Settings.instance.androidGameId, Settings.instance.androidPublicKey);
            }
            while (!_androidInited) {
                yield return 0;
            }
            if (callBack != null) {
                callBack();
            }
        }

        public override void RemoveNotification(string pushID) {
            StartCoroutine(C_CheckAndroidInited(() => {
                _unity.CallStatic("removeNotification", pushID);
            }));
        }

        public override void RequestNotifications() {
            StartCoroutine(C_CheckAndroidInited(() => {
                _unity.CallStatic("requestNotifications", false);
            }));
        }

        protected override void ShowDeviceDialog(string title, string message, params DialogButtons[] buttons) {
            if (buttons.Length == 0) {
                LogUtils.LogError("Cant show dialog without buttons");
                return;
            }
            StartCoroutine(C_CheckAndroidInited(() => {
                var dialogButtons = new List<string>();
                buttons.ForEach(b => dialogButtons.Add(b.ToString()));
                _unity.CallStatic("showDefaultDialog", title, message, dialogButtons.ToArray());
            }));
        }

        public override void CancelNotification(string pushId) {
            _unity.CallStatic("cancelNotification", pushId);
        }

        private void AndroidPushMessages(string response) {
            var jsonResponse = GowMiniJSON.Deserialize(response) as JsonObject;
            var objectsList = jsonResponse.Get<List<object>>("notifications");
            var notifications = new List<JsonObject>();
            objectsList.ForEach(o =>
            {
                var item = o as JsonObject;
                if (item != null) {
                    notifications.Add(item);
                }
            });
            OnNotificationsRecieved(notifications.ToArray());
        }

        private void AndroidCurrentPushMessage(string response) {
            var jsonResponse = GowMiniJSON.Deserialize(response) as JsonObject;
            var notification = jsonResponse.Get<JsonObject>("currentPushMessage");
            OnCurrentNotificationRecieved(notification);
        }
#endif
    }
}