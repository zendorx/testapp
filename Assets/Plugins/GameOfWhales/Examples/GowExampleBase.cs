using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameOfWhales {
    public class GowExampleBase : MonoBehaviour {
        [SerializeField]
        private LayoutGroup _layout;

        [SerializeField]
        private GowProductItemBase _itemSource;
        [SerializeField]
        private Text _coinsText;

        [SerializeField]
        protected GowProductInfo[] infos;

        private int _coins;

        private void Start()
        {
            _coins = 1000;

            foreach (Transform child in _layout.transform) {
                Destroy(child.gameObject);
            }
            InitStore();
            StartCoroutine(C_Consume());
        }

        protected virtual void InitStore()
        {

        }

        protected void Initialized() {
            foreach (Transform child in _layout.transform) {
                Destroy(child.gameObject);
            }
            foreach (var p in infos) {
                var b = Instantiate(_itemSource);
                b.info = p;
                b.transform.SetParent(_layout.transform);
                b.transform.localScale = Vector3.one;
            }
        }

        protected void AddCoins(int additional) {
            _coins += additional;
        }

        private IEnumerator C_Consume() {
            while (true) {
                _coinsText.text = _coins.ToString();
                yield return new WaitForSeconds(0.1f);
                _coins -= Mathf.CeilToInt(_coins * 0.01f);
                if (_coins < 0) {
                    _coins = 0;
                }
            }
        }

        public void SubscribeToNotifications() {
            //Subscribe to push notifications if not autosubscribe
            Gow.SubscribeToNotifications();
        }

        public void GetSpecialOffers() {
            //Get special offers from GOW
            Gow.GetSpecialOffers(error => { });
        }
    }
}