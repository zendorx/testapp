using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameOfWhales.Json;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;
using GowMiniJSON = GameOfWhales.Json.MiniJSON;

namespace GameOfWhales
{
    public class DeviceInfoIos : DeviceInfo
    {
#if UNITY_IOS

		public override string platform {
			get {
				return "ios";
			}
		}

		protected override IEnumerator C_Init () {

			GowIOSBinding.Init(Settings.serverUrl, Settings.instance.gameKey, Settings.instance.androidGameId, Settings.instance.androidPublicKey);

			yield return 0;
		}

		public override void RequestNotifications() {
			GowIOSBinding.RequestNotifications();
		}

		public override void GetPlayerId(System.Action<string> completed) {
			if (completed == null)
				return;
			completed(UnityEngine.iOS.Device.advertisingIdentifier); 

		}

		protected override void ProcessGetDeviceToken() {
            GowIOSBinding.RegisterForRemoteNotifications();
        }

		protected override void ShowDeviceDialog(string title, string message, params DialogButtons[] buttons) {
			var buttonsStrings = buttons.Select(b => b.ToString()).ToArray();
			GowIOSBinding.ShowDefaultDialog(title, message, buttonsStrings);
		}

		public override void RemoveNotification(string pushId) {
			GowIOSBinding.RemoveNotification(pushId);
		}

		public override void CancelNotification(string pushId) {
			GowIOSBinding.CancelNotification();
		}

		private void OnPushMessages(string response) {
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

        private void OnCurrentPushMessage(string response) {
            var jsonResponse = GowMiniJSON.Deserialize(response) as JsonObject;
            var notification = jsonResponse.Get<JsonObject>("currentPushMessage");
            OnCurrentNotificationRecieved(notification);
        }

		private void OnTokenRegistered(string token) {
			OnDeviceTokenReceived(token);
		}

		private void OnTokenRegisterFailed(string error) {
			OnDeviceTokenReceived(null);
		}
		#endif
    }
}