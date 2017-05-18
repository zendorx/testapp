using System;
using System.Collections.Generic;
using UnityEngine.Purchasing;

namespace GameOfWhales
{
    /// <summary>
    /// Entry point for Game of Whales SDK.
    /// </summary>
    public static class Gow
    {
        /// <summary>
        /// When system is ready to use.
        /// </summary>
        public static event Action Initialized;

        /// <summary>
        /// When system initialization is failed.
        /// </summary>
        public static event Action<InitializationFailureReason> InitializeFailed;

        /// <summary>
        /// When purchasing is failed.
        /// </summary>
        public static event Action<PurchaseFailedEventArgs> PurchaseFailed;

        /// <summary>
        /// When purchasing completed
        /// </summary>
        public static event Action<PurchaseCompletedEventArgs> PurchaseCompleted;

        /// <summary>
        /// When replacement become obsolete
        /// </summary>
        public static event Action<ReplacementEventArgs> ReplacementObsolete;

        /// <summary>
        /// When definition become obsolete
        /// </summary>
        public static event Action<DefinitionEventArgs> DefinitionObsolete;

        /// <summary>
		/// When tapped push notification recieved. Action is called after notification processed complete
        /// </summary>
        public static event Action<GowNotification, Action<GowNotification>> CurrentNotificationRecieved;

		/// <summary>
		/// When not tapped notifications recieved. Action is called after notification processed complete for each notification
		/// </summary>
        public static event Action<GowNotification[], Action<GowNotification>> NotificationsRecieved;

        private static Controller _controller;

        static Gow()
        {
            Controller.Initialized += Controller_Initialized;
            Controller.InitializeFailed += Controller_InitializeFailed;
            Controller.PurchaseFailed += Controller_PurchaseFailed;
            Controller.PurchaseCompleted += Controller_PurchaseCompleted;
            Controller.ReplacementObsolete += Controller_ReplacementObsolete;
            Controller.DefinitionObsolete += Controller_DefinitionObsolete;
            Controller.CurrentNotificationRecieved += Controller_CurrentNotificationRecieved;
            Controller.NotificationsRecieved += Controller_NotificationsRecieved;
        }


        private static void Controller_DefinitionObsolete(DefinitionEventArgs e)
        {
            if (DefinitionObsolete != null)
            {
                DefinitionObsolete(e);
            }
        }

        private static void Controller_ReplacementObsolete(ReplacementEventArgs e)
        {
            if (ReplacementObsolete != null)
            {
                ReplacementObsolete(e);
            }
        }

        private static void Controller_Initialized()
        {
            if (Initialized != null)
            {
                Initialized();
            }
        }

        private static void Controller_PurchaseCompleted(PurchaseCompletedEventArgs e)
        {
            if (PurchaseCompleted != null)
            {
                PurchaseCompleted(e);
            }
        }


        private static void Controller_PurchaseFailed(PurchaseFailedEventArgs e)
        {
            if (PurchaseFailed != null)
            {
                PurchaseFailed(e);
            }
        }

        private static void Controller_InitializeFailed(InitializationFailureReason error)
        {
            if (InitializeFailed != null)
            {
                InitializeFailed(error);
            }
        }

        private static void Controller_CurrentNotificationRecieved(GowNotification notification,
            Action<GowNotification> notificationCallback)
        {
            if (CurrentNotificationRecieved != null)
            {
                CurrentNotificationRecieved(notification, notificationCallback);
            }
            else
            {
                Controller.instance.DefaultProcessCurrentNotification(notification);
            }
        }

        private static void Controller_NotificationsRecieved(GowNotification[] notifications,
            Action<GowNotification> notificationCallback)
        {
            if (NotificationsRecieved != null)
            {
                NotificationsRecieved(notifications, notificationCallback);
            }
            else
            {
                Controller.instance.DefaultProcessNotifications(notifications);
            }
        }

        /// <summary>
        /// Get store controller
        /// </summary>
        /// <returns>IStoreController</returns>
        public static IStoreController store
        {
            get { return Controller.instance.store; }
        }

        /// <summary>
        /// Is system is ready to use.
        /// </summary>
        /// <returns>True, when system is ready.</returns>
        public static bool IsReady
        {
            get { return Controller.instance.isReady; }
        }

        /// <summary>
        /// Initialize SDK functionality. Must be called first, before using other methods.
        /// Initialization takes some time. You should wait until system will ready.
        /// </summary>
        /// <param name="productIds">Optional array of ProductIds.</param>
        /// <param name="customStoreListener">Optional custom IStoreListener that processes purchasing related events.</param>
        public static void Init(string[] productIds = null, IStoreListener customStoreListener = null)
        {
            Controller.instance.Init(null, productIds, customStoreListener);
        }

        /// <summary>
        /// Initialize SDK functionality. Must be called first, before using other methods.
        /// Initialization takes some time. You should wait until system will ready.
        /// </summary>
        /// <param name="configurationBuilder">Unity IAP configuration.</param>
        /// <param name="customStoreListener">Optional custom IStoreListener that processes purchasing related events.</param>
        public static void Init(ConfigurationBuilder configurationBuilder, IStoreListener customStoreListener = null)
        {
            Controller.instance.Init(configurationBuilder, null, customStoreListener);
        }

        /// <summary>
        /// Initialize start of purchasing product.
        /// </summary>
        /// <param name="product">Product to buy.</param>
        public static void Buy(Product product)
        {
            Controller.instance.Buy(product);
        }

        /// <summary>
        /// Initialize start of purchasing product.
        /// </summary>
        /// <param name="productId">Product identifier to buy.</param>
        public static void Buy(string productId)
        {
            Controller.instance.Buy(productId);
        }

        /// <summary>
        /// Initialize start of purchasing special offer.
        /// </summary>
        /// <param name="replacement">Special offer to buy</param>
        public static void Buy(SpecialOffers.Replacement replacement)
        {
            Controller.instance.Buy(replacement);
        }

        /// <summary>
        /// Get definitions for all special offers
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SpecialOffers.Definition> GetDefinitions()
        {
            return Controller.instance.specialOffers.GetDefinitions();
        }

        /// <summary>
        /// Get special offer for product with best price.
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>A special offer with lowest price</returns>
        public static SpecialOffers.Replacement GetReplacement(Product product)
        {
            return Controller.instance.specialOffers.GetReplacement(product.definition.id);
        }

        /// <summary>
        /// Get special offer for product with best price.
        /// </summary>
        /// <param name="sku">Product identifier</param>
        /// <returns>A special offer with lowest price</returns>
        public static SpecialOffers.Replacement GetReplacement(string sku)
        {
            return Controller.instance.specialOffers.GetReplacement(sku);
        }

        /// <summary>
        /// Get special offer for product with best price.
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>A special offer with lowest price</returns>
        public static IEnumerable<SpecialOffers.Replacement> GetReplacements(Product product)
        {
            return Controller.instance.specialOffers.GetReplacements(product.definition.id);
        }

        /// <summary>
        /// Get special offer for product with best price.
        /// </summary>
        /// <param name="sku">Product identifier</param>
        /// <returns>A special offer with lowest price</returns>
        public static IEnumerable<SpecialOffers.Replacement> GetReplacements(string sku)
        {
            return Controller.instance.specialOffers.GetReplacements(sku);
        }

        /// <summary>
        /// Get all special offers
        /// </summary>
        /// <returns>A special offers replacements</returns>
        public static IEnumerable<SpecialOffers.Replacement> GetAllReplacements() {
            return Controller.instance.specialOffers.GetAllReplacements();
        }

        /// <summary>
        /// Retrieve special offers
        /// </summary>
        /// <param name="failed">Callback on failed</param>
        public static void GetSpecialOffers(Action<string> failed)
        {
            Controller.instance.GetSpecialOffers(failed);
        }

        /// <summary>
        /// Subcribe to notifications. Takes firebase token and send it to GoW. In iOS additionaly check permissions for subscribe for notifications
        /// </summary>
        public static void SubscribeToNotifications()
        {
            Controller.instance.SubscribeToNotifications();
        }

        #region Optional

        public static void ReportPurchase(PurchaseEventArgs e) {
            Controller.instance.ReportPurchase(e);
        }

        #endregion

        /// <summary>
        /// Is user included in segment
        /// </summary>
        /// <param name="segmentName">Segment name</param>
        /// <returns>True, if user has segment.</returns>
        public static bool InSegment(string segmentName)
        {
            return Controller.instance.segments.Contains(segmentName);
        }
    }
}