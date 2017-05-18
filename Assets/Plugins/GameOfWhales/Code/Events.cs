using System;
using UnityEngine.Purchasing;

namespace GameOfWhales
{
    public class PurchaseFailedEventArgs : EventArgs
    {
        /// <summary>
        /// Purchasing product
        /// </summary>
        public readonly Product product;

        /// <summary>
        /// Failed reason
        /// </summary>
        public readonly PurchaseFailureReason reason;

        public PurchaseFailedEventArgs(Product product, PurchaseFailureReason reason)
        {
            this.product = product;
            this.reason = reason;
        }
    }

    public enum PurchaseCheckingState
    {
        /// <summary>
        /// Purchase is legal
        /// </summary>
        Legal,

        /// <summary>
        /// Purchase is not legal
        /// </summary>
        NotLegal,

        /// <summary>
        /// Server cant check a purchase at this moment.
        /// </summary>
        Error
    }

    public class PurchaseCompletedEventArgs : EventArgs
    {
        /// <summary>
        /// Purchasing product
        /// </summary>
        public readonly Product product;

        /// <summary>
        /// Server checking state
        /// </summary>
        public readonly PurchaseCheckingState checkingState;

        public readonly SpecialOffers.Replacement replacement;

        public readonly string soPayload;
        public readonly string originReceipt;

        public PurchaseCompletedEventArgs(Product product, PurchaseCheckingState checkingState,
            SpecialOffers.Replacement replacement, string soPayload = null, string originReceipt = null)
        {
            this.product = product;
            this.checkingState = checkingState;
            this.replacement = replacement;
            this.soPayload = soPayload;
            this.originReceipt = originReceipt;
        }
    }

    public class ReplacementEventArgs : EventArgs
    {
        public readonly SpecialOffers.Replacement replacement;

        public ReplacementEventArgs(SpecialOffers.Replacement replacement)
        {
            this.replacement = replacement;
        }
    }

    public class DefinitionEventArgs : EventArgs
    {
        public readonly SpecialOffers.Definition definition;

        public DefinitionEventArgs(SpecialOffers.Definition definition)
        {
            this.definition = definition;
        }
    }
}