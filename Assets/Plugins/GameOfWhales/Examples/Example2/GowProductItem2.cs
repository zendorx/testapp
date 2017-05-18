using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameOfWhales {
    public class GowProductItem2 : GowProductItemBase {

        private GowExampleStoreListener _storeController;

        protected override void Buy() {
            GowExample2.instance.Buy(info.name);
        }
    }
}
