using System;
using UnityEngine;

using JsonObject = System.Collections.Generic.Dictionary<string, object>;
using GoWMiniJSON = GameOfWhales.Json.MiniJSON;

using GameOfWhales.Json;

namespace GameOfWhales
{
    public class GowDataStorage
    {
        private static string GOW_DATA = "GOW_DATA";

        private static GowDataStorage _instance;

        private JsonObject _gowData;

        public GowDataStorage()
        {
            var line = PlayerPrefs.GetString(GOW_DATA, null);

            if (string.IsNullOrEmpty(line))
            {
                _gowData = new JsonObject();
            }
            else
            {
                try
                {
                    _gowData = (JsonObject)GoWMiniJSON.Deserialize(line);
                }
                catch (Exception e)
                {
                    LogUtils.LogError(e.Message);
                    LogUtils.LogError(e.StackTrace);
                    _gowData = new JsonObject();
                }
            }
        }

        public static GowDataStorage instance
        {
            get
            {
                if (_instance == null) {
                    _instance = new GowDataStorage();
                }
                return _instance;
            }
        }
        
        public string userId
        {
            get
            {
                return _gowData.Get<String>("userId", null);
            }
            set
            {
                _gowData.Set("userId", value);
                SaveData();
            }
        }

        private void SaveData()
        {
            PlayerPrefs.SetString(GOW_DATA, GoWMiniJSON.Serialize(_gowData));
            PlayerPrefs.Save(); 
        }
    }
}
