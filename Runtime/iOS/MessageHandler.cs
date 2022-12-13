using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace iOS
{
    public static class MessageHandler
    {
        public static event Action<string, bool> ResponseReceived;
        
        private delegate void MonoPMessageDelegate(string key, bool response);
        
        [AOT.MonoPInvokeCallback(typeof(MonoPMessageDelegate))]
        private static void OnMessage(string key, bool response) => ResponseReceived?.Invoke(key, response);
        
        [RuntimeInitializeOnLoadMethod]
        private static void Initialize() => RegisterMessageHandler(OnMessage);
        
        [DllImport("__Internal")]
        private static extern void RegisterMessageHandler(MonoPMessageDelegate messageDelegate);
    }
}