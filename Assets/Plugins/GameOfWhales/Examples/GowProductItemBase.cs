using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameOfWhales {
    public class GowProductItemBase : MonoBehaviour {
        public GowProductInfo info;


        [SerializeField]
        private Text _coins;
        [SerializeField]
        private Text _price;
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private AudioClip _tap;
        [SerializeField]
        private Image _so;

        protected SpecialOffers.Replacement replacement;

        void Start() {
            UpdateView();
        }

        void OnEnable() {
            Gow.ReplacementObsolete += Gow_ReplacementObsolete;
        }

        void OnDisable() {
            Gow.ReplacementObsolete -= Gow_ReplacementObsolete;
        }

        void Gow_ReplacementObsolete(ReplacementEventArgs obj) {
            if (info.name == obj.replacement.originalSku) {
                UpdateView();
            }
        }

        public void OnClick() {
            AudioSource.PlayClipAtPoint(_tap, Vector3.zero);

            Buy();
        }

        protected virtual void Buy() {}

        public void UpdateView() {
            if (!info)
                return;
            _coins.text = info.coins.ToString();
            _price.text = "$" + info.price.ToString();
            _icon.sprite = info.icon;
            _so.enabled = false;

            replacement = Gow.GetReplacement(info.name);
            if (replacement != null) {
                Debug.Log("Best price");
                _so.enabled = true;
                _price.text = "$" + replacement.price.ToString("#.##");
            }
        }
    }
}
