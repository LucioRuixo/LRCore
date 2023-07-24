using UnityEngine;

namespace LRCore
{
    public static class Logger
    {
        public static void Log(object source, string message) => Debug.Log($"{source} | {message}");

        public static void LogWarning(object source, string message) => Debug.LogWarning($"{source} | {message}");

        public static void LogError(object source, string message) => Debug.LogError($"{source} | {message}");
    }
}