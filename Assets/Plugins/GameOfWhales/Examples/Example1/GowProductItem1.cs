using UnityEngine;
using UnityEngine.UI;

namespace GameOfWhales
{
    public class GowProductItem1 : GowProductItemBase
    {
        protected override void Buy() {
            if (replacement != null) {
                //buy over GOW if its special offer product
                Gow.Buy(replacement);
            } else {
                //buy over GOW if its regular product
                Gow.Buy(info.name);
            }
        }
    }
}