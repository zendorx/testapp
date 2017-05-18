using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

namespace GameOfWhales {
    public class GowExampleStoreListener : MonoBehaviour, IStoreListener {

        private ConfigurationBuilder _configurationBuilder;
        private IStoreController _store;
        private IExtensionProvider _storeExt;

        public event Action Initialized;
        public event Action<InitializationFailureReason> InitializeFailed;
        public event Action<PurchaseEventArgs> PurchaseCompleted;
        public event Action<PurchaseFailedEventArgs> PurchaseFailed;

        public void Init(string[] products)
        {
            //Init Unity Purchasing with products skus
            var module = StandardPurchasingModule.Instance();
            _configurationBuilder = ConfigurationBuilder.Instance(module);
            products.ForEach(p => _configurationBuilder.products.Add(Controller.CreateProduct(p, ProductType.Consumable)));
            var gp = _configurationBuilder.Configure<IGooglePlayConfiguration>();
            gp.SetPublicKey(Settings.instance.androidPublicKey);
            UnityPurchasing.Initialize(this, _configurationBuilder);
        }

        void IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _store = controller;
            _storeExt = extensions;

            var appleExt = _storeExt.GetExtension<IAppleExtensions>();
            appleExt.RegisterPurchaseDeferredListener(OnDeferred);

            if (Initialized != null) {
                Initialized();
            }
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            if (InitializeFailed != null) {
                InitializeFailed(error);
            }
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
        {
            if (PurchaseFailed != null) {
                PurchaseFailed(new PurchaseFailedEventArgs(product, reason));
            }
        }

        PurchaseProcessingResult IStoreListener.ProcessPurchase(PurchaseEventArgs e)
        {
            //Report purchase to GOW
            Gow.ReportPurchase(e);
            if (PurchaseCompleted != null) {
                PurchaseCompleted(e);
            }
            return PurchaseProcessingResult.Complete;
        }

        private void OnDeferred(Product item) {
            LogUtils.Log("Purchase deferred: " + item.definition.id);
        }

        public void Buy(string productId) {
            //Buy product over UnityPurchasing
            var product = _store.products.WithID(productId);
            _store.InitiatePurchase(product, null);
        }
    }

}