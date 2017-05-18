using System;
using System.Collections;
using System.Collections.Generic;
using GameOfWhales.Json;
using UnityEngine;
using UnityEngine.Purchasing;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;
using GoWMiniJSON = GameOfWhales.Json.MiniJSON;

namespace GameOfWhales
{
    /// <summary>
    /// Main GameOfWhales internal controller.
    /// Autocreated singleton.
    /// </summary>
    public class Controller : MonoBehaviour, IStoreListener
    {
        private static Controller _instance;

        public static Controller instance
        {
            get
            {
                if (_instance)
                    return _instance;
                var obj = new GameObject(Settings.controllerName);
                obj.AddComponent<Controller>();
                return _instance;
            }
        }

        public static event Action<InitializationFailureReason> InitializeFailed;
        public static event Action<PurchaseFailedEventArgs> PurchaseFailed;
        public static event Action Initialized;
        public static event Action<PurchaseCompletedEventArgs> PurchaseCompleted;
        public static event Action<ReplacementEventArgs> ReplacementObsolete;
        public static event Action<DefinitionEventArgs> DefinitionObsolete;

        public static event Action<GowNotification[], Action<GowNotification>> NotificationsRecieved;
        public static event Action<GowNotification, Action<GowNotification>> CurrentNotificationRecieved;

        public List<ProductDefinition> _definitions = new List<ProductDefinition>();
        private SpecialOffers _specialOffers = new SpecialOffers();


        private Client _client;
        private DeviceInfo _device;
        private IStoreController _store;
        private IExtensionProvider _storeExt;
        private HashSet<string> _segments = new HashSet<string>();
        private ProductDefinition[] _productDefs;

        private event Action _applicationQuit;

        private readonly CompoundStoreListener _compoundStoreListener = new CompoundStoreListener();
        private ConfigurationBuilder _configurationBuilder;

        public bool isReady { get; private set; }
        public bool isLogged { get; private set; }
        public bool nowLogging { get; private set; }

        public SpecialOffers specialOffers
        {
            get { return _specialOffers; }
        }

        public IStoreController store
        {
            get { return _store; }
        }

        public HashSet<string> segments
        {
            get { return _segments; }
        }



        private void Check()
        {
            if (!isReady)
            {
                throw new UnityException("Game of whales is not ready");
            }
        }

        public void Init(ConfigurationBuilder configurationBuilder, string[] productDefinitions,
            IStoreListener customStoreListener)
        {
            _configurationBuilder = configurationBuilder;
            if (_configurationBuilder == null)
            {
                var module = StandardPurchasingModule.Instance();
                _configurationBuilder = ConfigurationBuilder.Instance(module);
            }

            _compoundStoreListener.Clear();
            _compoundStoreListener.AddStoreListener(this);
            if (customStoreListener != null)
                _compoundStoreListener.AddStoreListener(customStoreListener);

            StopAllCoroutines();

            Settings.Check();
            isReady = false;
            _specialOffers = new SpecialOffers();
            if (productDefinitions != null)
            {
                productDefinitions.ForEach(id =>
                {
                    _configurationBuilder.products.Add(CreateProduct(id, ProductType.Consumable));
                });
            }

            Login(
                loginData => 
                {
                    if (_configurationBuilder.products.Count > 0) {
                        UnityPurchasingInit();
                    } else {
                        isReady = true;
                        if (Initialized != null) {
                            Initialized();
                        }
                    }
                    StartCoroutine(C_CheckSpecialOffers());
                },
                err =>
                {
                    LogUtils.LogError("Logging error : " + err);
                    UnityPurchasingInit();
                }
            );
        }

        public static ProductDefinition CreateProduct(string id, ProductType productType) {
#if UNITY_5_0_0 || UNITY_5_0_1 || UNITY_5_0_2 || UNITY_5_0_3 || UNITY_5_0_4 || UNITY_5_1_0 || UNITY_5_1_1 || UNITY_5_1_2 || UNITY_5_1_3 || UNITY_5_1_4 || UNITY_5_1_5 || UNITY_5_2_0 || UNITY_5_2_1 || UNITY_5_2_2 || UNITY_5_2_3 || UNITY_5_2_4 || UNITY_5_2_5 || UNITY_5_3_0 ||  UNITY_5_3_1 ||  UNITY_5_3_2 ||  UNITY_5_3_3 ||  UNITY_5_3_4 ||  UNITY_5_3_5
            return new ProductDefinition(id, id, productType);
#else
            return new ProductDefinition(id, productType);
#endif
        }

        public void Login(System.Action<JsonObject> callback, System.Action<string> onError) {
            StartCoroutine(C_Login(callback, onError));
        }

        private IEnumerator C_Login(System.Action<JsonObject> callback, System.Action<string> onError)
        {
            while (nowLogging)
            {
                yield return 0;
            }

            isLogged = false;
            nowLogging = true;
            GetPlayerId((playerId) =>
            {
                LogUtils.Log("Get player ID:" + playerId);
                _client.Login(Settings.instance.gameKey,
                    playerId,
                    _device.timezone,
                    _device.platform,
                    Application.version,
                    (obj) =>
                    {
                        LogUtils.Log("Logged in");
                        nowLogging = false;
                        isLogged = true;
                        _applicationQuit += () => 
                        {
                            _client.Logout(Settings.instance.gameKey, playerId, (long)Time.unscaledTime);
                        };

                        if (Settings.instance.autoSubscribeToNotifications) 
                        {
                            _device.GetDeviceToken();
                        }

                        _device.RequestNotifications();

                        InitSegments(obj.GetSequence<string>("segments"));

                        InitSpecialOffers(obj.GetSequence<JsonObject>("specialOffers"));
                        
                        if (callback != null)
                        {
                            callback(obj);
                        }
                    },
                    error => 
                    {
                        nowLogging = false;
                        if (onError != null) 
                        {
                            onError(error);
                        }
                    });
            });
        }

        private void GetPlayerId(System.Action<string> callback) {
            _device.GetPlayerId(playerId =>
            {
                if (string.IsNullOrEmpty(playerId))
                {
                    playerId = GowDataStorage.instance.userId;
                }
                else
                {
                    var rep = playerId.Replace("-", "").Replace("0", "");
                    if (string.IsNullOrEmpty(rep))
                    {
                        playerId = GowDataStorage.instance.userId;
                    }
                }

                if (callback != null)
                {
                    callback(playerId);
                }
            });
        }

        public void GetSpecialOffers(Action<string> failed)
        {
            GetPlayerId((playerId) =>
            {
                _client.GetSpecialOffers(Settings.instance.gameKey, playerId, response =>
                {
                    InitSpecialOffers(response.GetSequence<JsonObject>("specialOffers"));
                    UnityPurchasingInit();
                }, failed);
            });
        }

        private void InitSegments(IEnumerable<string> segmentsStrings)
        {
            _segments.Clear();
            segmentsStrings.ForEach(s=>_segments.Add(s));
        }

        private void InitSpecialOffers(IEnumerable<JsonObject> specialOffersJson)
        {
            _specialOffers.Clear();
            specialOffersJson.ForEach(sobj =>
            {
                try
                {
                    var def = new SpecialOffers.Definition(sobj);
                    _specialOffers.Add(def);
                    def.GetIds()
                        .ForEach(id =>
                        {
                            _configurationBuilder.products.Add(CreateProduct(id, ProductType.Consumable));
                        });
                }
                catch (Exception x)
                {
                    LogUtils.LogError(x.Message);
                    LogUtils.LogError(x.StackTrace);
                }
            });
        }

        private IEnumerator C_CheckSpecialOffers()
        {
            while (true)
            {
                var waitTo = _specialOffers.Check(_store, so =>
                {
                    if (DefinitionObsolete != null)
                    {
                        DefinitionObsolete(new DefinitionEventArgs(so));
                    }
                });
                var waitSeconds = (int) (waitTo - DateTime.Now).TotalSeconds;
                yield return new WaitForSeconds(waitSeconds);
            }
        }

        private void UnityPurchasingInit()
        {
            LogUtils.Log("UnityPurchasingInit begin");
            var gp = _configurationBuilder.Configure<IGooglePlayConfiguration>();
            gp.SetPublicKey(Settings.instance.androidPublicKey);
            UnityPurchasing.Initialize(_compoundStoreListener, _configurationBuilder);
            LogUtils.Log("UnityPurchasingInit end");
        }


        public void Buy(Product product)
        {
            if (_store == null) {
                throw new UnityException("Not properly inited");
            }
            Check();
            LogUtils.Log("Buy " + product.definition.id);
            if (!product.availableToPurchase)
            {
                LogUtils.Log("Product " + product.definition.id + " is not available to purchase");
                return;
            }
            _store.InitiatePurchase(product, null);
        }

        public void Buy(string productId)
        {
            if (_store == null) {
                throw new UnityException("Not properly inited");
            }
            Check();
            var product = _store.products.WithID(productId);
            Buy(product);
        }

        public void Buy(SpecialOffers.Replacement replacement)
        {
            if (_store == null) {
                throw new UnityException("Not properly inited");
            }
            Check();
            LogUtils.Log("Buy special offer " + replacement.sku);
            if (!replacement.product.availableToPurchase)
            {
                LogUtils.Log("Product " + replacement.product.definition.id + " is not available to purchase");
                return;
            }
            _store.InitiatePurchase(replacement.product, null);
        }

        public Product GetProduct(string productId)
        {
            Check();
            return _store == null ? null : _store.products.WithID(productId);
        }

        #region IStoreListener implementation

        void IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            LogUtils.Log("IStoreListener.OnInitialized");
            _store = controller;
            _storeExt = extensions;

            var appleExt = _storeExt.GetExtension<IAppleExtensions>();
            appleExt.RegisterPurchaseDeferredListener(OnDeferred);

            _specialOffers.Init(_store);

            isReady = true;
            if (Initialized != null)
            {
                Initialized();
            }
        }

        PurchaseProcessingResult IStoreListener.ProcessPurchase(PurchaseEventArgs e)
        {
            var product = e.purchasedProduct;
            var rep = _specialOffers.GetReplacementBySOSku(e.purchasedProduct.definition.id);
            ReportPurchase(e,
                res => {
                    if (Settings.instance.autoConfirmPurchase) {
                        _store.ConfirmPendingPurchase(e.purchasedProduct);
                    }
                    JsonObject so;
                    res.TryGet("specialOffer", out so);

                    string soPayload = null;
                    if (so != null) {
                        so.TryGet("soPayload", out soPayload);
                    }

                    soPayload = string.IsNullOrEmpty(soPayload) ? null : soPayload;

                    string originReceipt;
                    res.TryGet("originReceipt", out originReceipt);

                    if (PurchaseCompleted != null) {
                        PurchaseCompleted(new PurchaseCompletedEventArgs(product, PurchaseCheckingState.Legal, rep,
                            soPayload, originReceipt));
                    }
                },
                err => {
                    if (Settings.instance.autoConfirmPurchase && Settings.instance.autoConfirmPurchaseWhenError) {
                        _store.ConfirmPendingPurchase(e.purchasedProduct);
                    }
                    if (PurchaseCompleted != null) {
                        PurchaseCompleted(
                            new PurchaseCompletedEventArgs(product, PurchaseCheckingState.Error, rep));
                    }
                });
            return PurchaseProcessingResult.Pending;
        }

        public void ReportPurchase(PurchaseEventArgs e) {
            ReportPurchase(e, null, null);
        }

        private void ReportPurchase(PurchaseEventArgs e, Action<JsonObject> completed, Action<string> error) {
            var rep = _specialOffers.GetReplacementBySOSku(e.purchasedProduct.definition.id);

            GetPlayerId((playerId) => {
                var product = e.purchasedProduct;
                if (rep != null) {
                    product = rep.originalProduct;
                }

                _client.Receipt(Settings.instance.gameKey,
                    playerId,
                    e.purchasedProduct.metadata.isoCurrencyCode,
                    (float)e.purchasedProduct.metadata.localizedPrice,
                    e.purchasedProduct.transactionID,
                    e.purchasedProduct.receipt,
                    rep != null ? rep.definition.id : null,
                    rep != null ? rep.originalSku : null,
                    rep != null ? rep.definition.soPayload : null,
                    completed, error);
            });
        }

        void IStoreListener.OnInitializeFailed(InitializationFailureReason error)
        {
            if (InitializeFailed != null)
            {
                InitializeFailed(error);
            }
        }

        void IStoreListener.OnPurchaseFailed(Product product, PurchaseFailureReason reason)
        {
            if (PurchaseFailed != null)
            {
                PurchaseFailed(new PurchaseFailedEventArgs(product, reason));
            }
        }

        private void OnDeferred(Product item)
        {
            LogUtils.Log("Purchase deferred: " + item.definition.id);
        }

        #endregion

        void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(this);
            gameObject.name = Settings.controllerName;
            _client = gameObject.AddComponent<Client>();

#if UNITY_EDITOR
            _device = gameObject.AddComponent<DeviceInfo>();
#elif UNITY_ANDROID
			_device = gameObject.AddComponent<DeviceInfoAndroid>();
#elif UNITY_IOS
			_device = gameObject.AddComponent<DeviceInfoIos>();
#endif
            _device.NotificationRecieved += OnNotificationsRecieved;
            _device.CurrentNotificationRecieved += OnCurrentNotificationRecieved;
            _device.TokenReceived += OnDeviceToken;
        }

        private void OnNotificationsRecieved(GowNotification[] notifications)
        {
            if (NotificationsRecieved != null)
            {
                NotificationsRecieved(notifications, n => { RemoveDeviceNotification(n.pushId); });
            }
            else
            {
                DefaultProcessNotifications(notifications);
            }
        }

        private void OnDeviceToken(string token)
        {
            if (string.IsNullOrEmpty(token)) {
                return;
            }
            if (!isLogged) {
                return;
            }
            GetPlayerId(playerId =>
            {
                LogUtils.Log("DeviceToken:" + token);
                _client.Token(Settings.instance.gameKey, playerId, token);
            });
        }

        public void RemoveDeviceNotification(string pushId)
        {
            _device.RemoveNotification(pushId);
        }

        private void OnCurrentNotificationRecieved(GowNotification notification)
        {
            if (CurrentNotificationRecieved != null)
            {
                CurrentNotificationRecieved(notification, n => { RemoveDeviceNotification(n.pushId); });
            }
            else
            {
                DefaultProcessCurrentNotification(notification);
            }
        }

        public void DefaultProcessNotifications(GowNotification[] notifications)
        {
            notifications.Where(n => n.isValid).ForEach(n =>
            {
                _device.ShowDefaultDialog(n.pushId, n.title, n.message,
                    () =>
                    {
                        GetPlayerId(playerId =>
                        {
                            _client.PushReacted(Settings.instance.gameKey, playerId,
                                new[] {n.pushId},
                                successJson => { RemoveDeviceNotification(n.pushId); },
                                error => Debug.LogError("Reacted Error: " + error));
                        });
                    },
                    () =>
                    {
                        GetPlayerId(playerId =>
                        {
                            _client.PushReacted(Settings.instance.gameKey, playerId,
                                new[] {n.pushId},
                                successJson => { RemoveDeviceNotification(n.pushId); },
                                error => Debug.LogError("Reacted Error: " + error));
                        });
                    });
            });
        }

        public void DefaultProcessCurrentNotification(GowNotification notification)
        {
            if (notification == null || !notification.isValid)
            {
                return;
            }
            _device.ShowDefaultDialog(notification.pushId, notification.title, notification.message,
                () => { RemoveDeviceNotification(notification.pushId); });
        }

        public void RequestNotifications()
        {
            _device.RequestNotifications();
        }

        void OnApplicationQuit()
        {
            if (_applicationQuit == null)
                return;
            _applicationQuit();
            _applicationQuit = null;
        }

        void OnApplicationPause(bool pausing)
        {
            if (!pausing)
            {
                RequestNotifications();
            }
        }

        public void SubscribeToNotifications()
        {
            _device.GetDeviceToken();
        }
    }
}