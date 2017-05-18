using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameOfWhales
{
    public class GowExample1 : GowExampleBase
    {

        protected override void InitStore() {
            //Init GOW with products
            Gow.Initialized += Initialized;
            var products = infos.Select(i => i.name).ToArray();
            Gow.Init(products);
        }

        void OnEnable()
        {
            Gow.PurchaseCompleted += Gow_PurchaseCompleted;
        }

        void OnDisable()
        {
            Gow.PurchaseCompleted -= Gow_PurchaseCompleted;
        }

        void Gow_PurchaseCompleted(PurchaseCompletedEventArgs obj)
        {
            //Add "coins" when purchase is completed;
            infos.Where(i => i.name == obj.product.definition.id)
                .ForEach(i =>
                {
                    AddCoins(i.coins);
                    Debug.Log("Add coins:" + i.coins);
                    if (obj.replacement != null)
                    {
                        Debug.Log("Bought by action:" + obj.replacement.definition.title);
                    }
                });
        }
    }
}