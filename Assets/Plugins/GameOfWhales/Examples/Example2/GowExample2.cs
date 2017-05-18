using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

namespace GameOfWhales
{
    public class GowExample2 : GowExampleBase
    {
        [SerializeField]
        GowExampleStoreListener _storeController;

        private static GowExample2 _instance;

        public static GowExample2 instance {
            get {
                return _instance;
            }
        }

        private void Awake() {
            _instance = this;
        }

        private void OnEnable()
        {
            _storeController.PurchaseCompleted += OnPurchaseComplete;
        }

        private void OnDisable()
        {
            _storeController.PurchaseCompleted -= OnPurchaseComplete;
        }

        protected override void InitStore() {
            //Init Unity Purchasing and subscribe to events
            _storeController.Initialized += UnityPurchasingInitialized;
            Gow.Initialized += Initialized;
            _storeController.Init(infos.Select(i => i.name).ToArray());
        }

        private void OnPurchaseComplete(PurchaseEventArgs e) {
            //Add "coins" when purchase is completed;
            infos.Where(i => i.name == e.purchasedProduct.definition.id)
                .ForEach(i => {
                    AddCoins(i.coins);
                    Debug.Log("Add coins:" + i.coins);
                });
        }

        private void UnityPurchasingInitialized() {
            //Init Gow
            Gow.Init();
        }

        public void Buy(string product) {
            //Buy product;
            _storeController.Buy(product);
        }
    }
}