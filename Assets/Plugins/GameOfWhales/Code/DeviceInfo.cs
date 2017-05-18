using System;
using System.Collections;
using System.Collections.Generic;
using GameOfWhales.Json;
using UnityEngine;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;
using GOWMiniJSON = GameOfWhales.Json.MiniJSON;

namespace GameOfWhales
{
    public class DeviceInfo : MonoBehaviour
    {
        protected enum DialogButtons
        {
            Ok,
            Cancel,
        }

        protected class DialogRequests
        {
            public string id;
            public string title;
            public string message;
            public Action onOk;
            public Action onCancel;
        }

        public event Action<GowNotification[]> NotificationRecieved;
        public event Action<GowNotification> CurrentNotificationRecieved;
        public event Action<string> TokenReceived;

        private readonly Queue<DialogRequests> _dialogResponsesQueue = new Queue<DialogRequests>();

        private readonly List<string> _dialogPushIds = new List<string>();

        private DialogRequests _currentDialogRequest;

        public string token { get; protected set; }

        public virtual string platform
        {
            get { return "unityeditor"; }
        }

        public string timezone
        {
            get { return TimeZone.CurrentTimeZone.StandardName; }
        }

        protected virtual IEnumerator C_Init()
        {
            yield return 0;
        }

        public virtual void GetPlayerId(Action<string> completed)
        {
            if (completed == null)
                return;
#if UNITY_EDITOR
            completed(SystemInfo.deviceUniqueIdentifier + "ID");
#else
            LogUtils.LogError(System.Guid.NewGuid().ToString() + "ID");

#endif
        }

        public void GetDeviceToken()
        {
            if (string.IsNullOrEmpty(token)) {
                ProcessGetDeviceToken();
            } 
            else 
            {
                OnDeviceTokenReceived(token);
            }
        }

        protected virtual void ProcessGetDeviceToken() {

        }

        public virtual void RemoveNotification(string pushID)
        {
        }

        public virtual void RequestNotifications()
        {
        }

        public virtual void Update()
        {
        }

        protected void OnCurrentNotificationRecieved(JsonObject notification)
        {

            if (!GowNotification.IsValid(notification)) {
                LogUtils.LogWarning("Not valid json : " + (notification == null ? "<NULL>" : GOWMiniJSON.Serialize(notification)));
                return;
            }

            if (CurrentNotificationRecieved != null)
            {
                CurrentNotificationRecieved(new GowNotification(notification));
            }
        }

        protected void OnNotificationsRecieved(JsonObject[] notifications)
        {
            if (NotificationRecieved != null)
            {

                NotificationRecieved(notifications.Select(json => {
                    if (!GowNotification.IsValid(json)) {
                        LogUtils.LogWarning("Not valid json : " + json == null ? "<NULL>" : GOWMiniJSON.Serialize(json));
                        return null;
                    }
                    return new GowNotification(json);
                }).SelectNotNull().ToArray());
            }
        }

        protected void OnDeviceTokenReceived(string token)
        {
            this.token = token;
            if (TokenReceived != null)
            {
                TokenReceived(token);
            }
        }

        public virtual void ShowDefaultDialog(string id, string title, string message, Action onOk)
        {
            ShowDefaultDialog(id, title, message, onOk, null);
        }

        public virtual void ShowDefaultDialog(string id, string title, string message, Action onOk, Action onCancel)
        {
            if (!_dialogPushIds.Contains(id))
            {
                _dialogPushIds.Add(id);
                _dialogResponsesQueue.Enqueue(new DialogRequests
                {
                    id = id,
                    title = title,
                    message = message,
                    onOk = onOk,
                    onCancel = onCancel,
                });
            }
        }

        protected virtual void ShowDeviceDialog(string title, string message, params DialogButtons[] buttons)
        {
        }

        private IEnumerator C_DialogCoroutine()
        {
            while (true)
            {
                if (_currentDialogRequest == null && _dialogResponsesQueue.Count > 0)
                {
                    _currentDialogRequest = _dialogResponsesQueue.Dequeue();

                    var pushId = _currentDialogRequest.id;

                    var buttons = new List<DialogButtons>();
                    if (_currentDialogRequest.onOk != null)
                    {
                        buttons.Add(DialogButtons.Ok);
                    }
                    if (_currentDialogRequest.onCancel != null)
                    {
                        buttons.Add(DialogButtons.Cancel);
                    }
                    CancelNotification(_currentDialogRequest.id);

                    if (buttons.Count == 0)
                    {
                        LogUtils.LogError("Cant show dialog without buttons");
                    }
                    else
                    {
                        ShowDeviceDialog(_currentDialogRequest.title, _currentDialogRequest.message, buttons.ToArray());

                        while (_currentDialogRequest != null)
                        {
                            yield return 0;
                        }
                    }

                    _dialogPushIds.Remove(pushId);
                }

                yield return 0;
            }
        }

        private void DefaultDialogCallback(string response)
        {
            var jsonResponse = GOWMiniJSON.Deserialize(response) as JsonObject;
            var dialogResponseString = jsonResponse.Get<string>("response");
            if (string.IsNullOrEmpty(dialogResponseString))
            {
                LogUtils.LogError("Incorrect dialog response: " + dialogResponseString);
            }
            try
            {
                var dialogResponse = (DialogButtons) Enum.Parse(typeof(DialogButtons), dialogResponseString);
                if (_currentDialogRequest != null)
                {
                    var callback = dialogResponse == DialogButtons.Ok
                        ? _currentDialogRequest.onOk
                        : _currentDialogRequest.onCancel;
                    if (callback != null)
                    {
                        callback();
                    }
                }
            }
            catch (ArgumentException e)
            {
                Debug.LogError("Parse enum exception: " + e.Message + "\r\n" + e.StackTrace);
            }
            _currentDialogRequest = null;
        }

        public virtual void CancelNotification(string pushId)
        {
        }

        IEnumerator Start()
        {
            yield return StartCoroutine(C_Init());
            StartCoroutine(C_DialogCoroutine());
        }
    }
}