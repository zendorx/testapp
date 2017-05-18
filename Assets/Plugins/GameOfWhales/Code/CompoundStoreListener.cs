using System.Collections.Generic;
using UnityEngine.Purchasing;

namespace GameOfWhales
{
    /// <summary>
    /// Compound store listener class. Delegate all calls to inner list of other IStoreListener.
    /// Using to provide custom store listener functionality.
    /// </summary>
    public class CompoundStoreListener : IStoreListener
    {
        private readonly HashSet<IStoreListener> _list = new HashSet<IStoreListener>();

        #region IStoreListener implementation

        void IStoreListener.OnInitializeFailed(InitializationFailureReason error)
        {
            _list.ForEach(l => l.OnInitializeFailed(error));
        }

        PurchaseProcessingResult IStoreListener.ProcessPurchase(PurchaseEventArgs e)
        {
            PurchaseProcessingResult result = PurchaseProcessingResult.Pending;
            foreach (var l in _list)
            {
                if (l.ProcessPurchase(e) == PurchaseProcessingResult.Complete)
                {
                    result = PurchaseProcessingResult.Complete;
                }
            }
            return result;
        }

        void IStoreListener.OnPurchaseFailed(Product i, PurchaseFailureReason p)
        {
            _list.ForEach(l => l.OnPurchaseFailed(i, p));
        }

        void IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _list.ForEach(l => l.OnInitialized(controller, extensions));
        }

        #endregion

        public void AddStoreListener(IStoreListener listener)
        {
            _list.Add(listener);
        }

        public void RemoveStoreListener(IStoreListener listener)
        {
            _list.Remove(listener);
        }

        public void Clear()
        {
            _list.Clear();
        }
    }
}