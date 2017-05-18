using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;
using GoWMiniJSON = GameOfWhales.Json.MiniJSON;

namespace GameOfWhales
{
    public class Client : MonoBehaviour
    {
        private void Post(string command, JsonObject args, Action<JsonObject> completed = null,
            Action<string> error = null)
        {
            StartCoroutine(C_Post(command, args, completed, error));
        }

        private IEnumerator C_Post(string command, JsonObject args, Action<JsonObject> completed, Action<string> error)
        {
            if (command != "sdk.login") {
                if (Controller.instance.nowLogging) 
                {
                    while (!Controller.instance.isLogged) {
                        yield return 0;
                    }
                }
                else 
                {
                    while (!Controller.instance.isLogged) {
                        var wait = true;

                        Controller.instance.Login(loginData => { wait = false; }, errorMessage => { wait = false; });

                        while (wait) {
                            yield return 0;
                        }
                    }
                }
            }

            LogUtils.Log("!!!SEND " + command + " " + GoWMiniJSON.Serialize(args));
            var argsBytes = Encoding.UTF8.GetBytes(GoWMiniJSON.Serialize(args));
            var headers = new Dictionary<string, string>
            {
                {"Content-Type", "application/json"},
                {"Content-Length", argsBytes.Length.ToString()}
            };

            var www = new WWW(Settings.serverUrl + "/" + command, argsBytes, headers);

            yield return www;
            if (!string.IsNullOrEmpty(www.error))
            {
                var fullError = string.Format("Server: {0} \r\nCommand: {1} \r\nArguments : {2} \r\nError: {3}\r\n", Settings.serverUrl, command, GoWMiniJSON.Serialize(args), www.error);
                Debug.LogError(fullError);
                if (error != null)
                {
                    error(www.error);
                }
            }
            else if (completed != null)
            {
                LogUtils.Log("RESPONSE:" + www.text);
                var obj = (JsonObject) GoWMiniJSON.Deserialize(www.text);
                completed(obj);
            }
        }

        public void Login(string gameKey, string playerId, string timezone, string platform, string version,
            Action<JsonObject> completed = null, Action<string> error = null)
        {
            var args = new JsonObject();
            args["game"] = gameKey;
            args["user"] = playerId;
            args["timezone"] = timezone;
            args["platform"] = platform;
            args["version"] = version;
            args["device"] = SystemInfo.deviceModel;

            System.Action<JsonObject> finalCompleted = response => {
                if (response.ContainsKey("user")) {
                    GowDataStorage.instance.userId = response["user"].ToString();
                }
                if (completed != null) {
                    completed(response);
                }
            };

            Post("sdk.login", args, finalCompleted, error);
        }

        public void Token(string gameKey, string playerId, string deviceToken, Action<JsonObject> completed = null,
            Action<string> error = null)
        {
            var args = new JsonObject();
            args["game"] = gameKey;
            args["user"] = playerId;
            args["token"] = deviceToken;  
            Post("sdk.token", args, completed, error);
        }

        public void Logout(string gameKey, string playerId, long playSeconds, Action<JsonObject> completed = null,
            Action<string> error = null)
        {
            var args = new JsonObject();
            args["game"] = gameKey;
            args["user"] = playerId;
            args["seconds"] = playSeconds;
            Post("sdk.logout", args, completed, error);
        }

        public void Purchase(string gameKey, string playerId, string productId, string currency, float price,
            string transactionId, string receipt, Action<JsonObject> completed = null, Action<string> error = null)
        {
            var args = new JsonObject();
            args["game"] = gameKey;
            args["user"] = playerId;
            args["product"] = productId;
            args["currency"] = currency;
            args["price"] = price * 100;
            args["receipt"] = GoWMiniJSON.jsonDecode(receipt);
            args["transactionId"] = transactionId;
            Post("sdk.purchase", args, completed, error);
        }

        public void Receipt(string gameKey, string playerId, string currency, float price, string transactionId,
            string receipt, string soId, string originalSku, string soPayload, Action<JsonObject> completed = null,
            Action<string> error = null)
        {
            var args = new JsonObject();
            args["game"] = gameKey;
            args["user"] = playerId;
            args["currency"] = currency;
            args["price"] = price * 100;
            args["receipt"] = receipt;
            args["transactionId"] = transactionId;
            args["soPayload"] = soPayload;
            if (soId != null)
            {
                args["so"] = soId;
                args["originalSku"] = originalSku;
            }
            Post("sdk.receipt", args, completed, error);
        }

        public void PushSuccess(string gameKey, string playerId, string[] success, Action<JsonObject> completed = null,
            Action<string> error = null)
        {
            Push(gameKey, playerId, success, new string[0], completed, error);
        }

        public void PushReacted(string gameKey, string playerId, string[] reacted, Action<JsonObject> completed = null,
            Action<string> error = null)
        {
            Push(gameKey, playerId, new string[0], reacted, completed, error);
        }

        public void Push(string gameKey, string playerId, string[] success, string[] reacted,
            Action<JsonObject> completed = null, Action<string> error = null)
        {
            var args = new JsonObject();
            args["game"] = gameKey;
            args["user"] = playerId;
            args["delivered"] = success;
            args["reacted"] = reacted;
            Post("sdk.push", args, completed, error);
        }

        public void Check(Action<JsonObject> handler)
        {
            var args = new JsonObject();
            Post("sdk.check", args, handler);
        }

        public void GetSpecialOffers(string gameKey, string playerId, Action<JsonObject> completed = null,
            Action<string> error = null)
        {
            var args = new JsonObject();
            args["game"] = gameKey;
            args["user"] = playerId;
            Post("sdk.sos", args, completed, error);
        }
    }
}