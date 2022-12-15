using System;
using UnityEngine;
using System.Runtime.InteropServices;

namespace NativePopups
{
    public static class MessageHandler
    {
        public static event Action<string, bool> ResponseReceived;

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize() => RegisterMessageHandler(OnMessage);
        
        [DllImport("__Internal")]
        private static extern void RegisterMessageHandler(MonoPMessageDelegate messageDelegate);
        
        [AOT.MonoPInvokeCallback(typeof(MonoPMessageDelegate))]
        private static void OnMessage(bool response) => ResponseReceived?.Invoke(NativePopup.CurrentCallbackKey, response);

        private delegate void MonoPMessageDelegate(bool response);
    }
}