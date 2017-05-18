using UnityEngine;

namespace GameOfWhales
{
    public class LogUtils
    {
        public enum LogLevel
        {
            Info,
            Warning,
            Error
        }

        private static void LogMessage(LogLevel level, object message, Object context)
        {
            if (level != LogLevel.Error && Settings.instance != null && !Settings.instance.loggingEnabled)
            {
                return;
            }
            if (level == LogLevel.Warning)
            {
                Debug.LogWarning(message, context);
            }
            else if (level == LogLevel.Error)
            {
                Debug.LogError(message, context);
            }
            else
            {
                Debug.Log(message, context);
            }
        }

        public static void Log(object message, Object context)
        {
            LogMessage(LogLevel.Info, message, context);
        }

        public static void Log(object message)
        {
            LogMessage(LogLevel.Info, message, null);
        }

        public static void LogWarning(object message, Object context)
        {
            LogMessage(LogLevel.Warning, message, context);
        }

        public static void LogWarning(object message)
        {
            LogMessage(LogLevel.Warning, message, null);
        }

        public static void LogError(object message, Object context)
        {
            LogMessage(LogLevel.Error, message, context);
        }

        public static void LogError(object message)
        {
            LogMessage(LogLevel.Error, message, null);
        }
    }
}