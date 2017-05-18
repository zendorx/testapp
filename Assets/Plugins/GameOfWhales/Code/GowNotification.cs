using UnityEngine.Purchasing;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;
using GameOfWhales.Json;

namespace GameOfWhales
{
    public class GowNotification
    {
        public readonly string title;
        public readonly string message;
        public readonly string pushId;

        public GowNotification(JsonObject json)
        {
            if (json != null) {
                json.TryGet("title", out title);
                json.TryGet("subtitle", out message);
                json.TryGet("pushID", out pushId);
            }
        }

        public bool isValid
        {
            get {
                var valid = !string.IsNullOrEmpty(title)
                    && !string.IsNullOrEmpty(message)
                    && !string.IsNullOrEmpty(pushId);

                if (!valid) {
                    LogUtils.LogWarning(string.Format("Message {0} is not valid", pushId));
                }

                return valid;
            }
        }

        public static bool IsValid(JsonObject json) {
            return json != null && json.ContainsKey("pushID");
        }
    }

}