using UnityEngine;

namespace GameOfWhales
{
    public class Settings : ScriptableObject
    {
        public const string settingsResourceName = "GameOfWhales.Settings";
        public const string controllerName = "GameOfWhales";
        public const string siteUrl = "http://api.gameofwhales.com";
        public const int port = 8080;

        [SerializeField] private string _token;
        [SerializeField] private string _email;
        [SerializeField] private string _selectedStudioId;
        [SerializeField] private string _selectedStudioName;
        [SerializeField] private string _selectedGameId;
        [SerializeField] private string _selectedGameName;
        [SerializeField] private string _selectedGameCategory;
        [SerializeField] private bool _autoConfirmPurchase = true;
        [SerializeField] private bool _autoConfirmPurchaseWhenError;
        [SerializeField] private bool _autoSubscribeToNotifications = true;

        public static string serverUrl
        {
            get { return string.Format("{0}:{1}", siteUrl, port); }
        }

        private static Settings _instance;

        public static Settings instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = (Settings) Resources.Load(settingsResourceName, typeof(Settings));
                }
                return _instance;
            }
        }

        public static void Check()
        {
            if (!instance)
            {
                throw new UnityException(
                    "Settings required. Press menu item 'Assets->Game of whales->Settings' and fill settings.");
            }
        }


        public string gameKey;
        public string androidGameId;
        public string androidPublicKey;

        public bool loggingEnabled;

        public string token
        {
            get { return _token; }
            set { _token = value; }
        }

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string selectedStudioId
        {
            get { return _selectedStudioId; }
            set { _selectedStudioId = value; }
        }

        public string selectedStudioName
        {
            get { return _selectedStudioName; }
            set { _selectedStudioName = value; }
        }

        public string selectedGameId
        {
            get { return _selectedGameId; }
            set { _selectedGameId = value; }
        }

        public string selectedGameName
        {
            get { return _selectedGameName; }
            set { _selectedGameName = value; }
        }

        public string selectedGameCategory
        {
            get { return _selectedGameCategory; }
            set { _selectedGameCategory = value; }
        }

        public bool autoConfirmPurchase
        {
            get { return _autoConfirmPurchase; }
            set { _autoConfirmPurchase = value; }
        }

        public bool autoConfirmPurchaseWhenError
        {
            get { return _autoConfirmPurchaseWhenError; }
            set { _autoConfirmPurchaseWhenError = value; }
        }

        public bool autoSubscribeToNotifications
        {
            get { return _autoSubscribeToNotifications; }
            set { _autoSubscribeToNotifications = value; }
        }
    }
}