using System.Runtime.InteropServices;
using Unity.Plastic.Newtonsoft.Json.Serialization;
using UnityEngine;

namespace iOS
{
    public static class MessageHandler
    {
        public static event Action<string, bool> ResponseReceived;
        
        // Этот делегат задает сигнатуру нашего экспортируемого метода
        private delegate void MonoPMessageDelegate(string key, bool success);

        // Этот метод реализует вышеописанный делегат и говорит компилятору,
        // что он будет вызываться извне
        [AOT.MonoPInvokeCallback(typeof(MonoPMessageDelegate))]
        private static void OnMessage(string key, bool success) => ResponseReceived?.Invoke(key, success);

        // Этот метод будет вызываться автоматически при инициализации Unity Engine в игре
        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            // Передаем ссылку на наш экспортируемый метод в нативный код
            RegisterMessageHandler(OnMessage);
        }

        // Нативная функция, которая получает ссылку на наш экспортируемый метод
        [DllImport("__Internal")]
        private static extern void RegisterMessageHandler(MonoPMessageDelegate messageDelegate);
    }
}