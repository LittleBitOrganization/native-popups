using System;
using UnityEngine;
using System.Runtime.InteropServices;

namespace NativePopups
{
    public static class MessageHandler
    {

        public static ISystemMessageHandler System { get; private set; }

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            RegisterObjectiveCMessageHandler();
        }

        private static void RegisterObjectiveCMessageHandler()
        {
            System = new ObjectiveCMessageHandler();
            RegisterMessageHandler(OnMessage);
        }

        [DllImport("__Internal")]
        private static extern void RegisterMessageHandler(MonoPMessageDelegate messageDelegate);
        
        
        [AOT.MonoPInvokeCallback(typeof(MonoPMessageDelegate))]
        private static void OnMessage(bool response)
        {
            int value = Convert.ToInt32(response);
            System.OnMessage(SystemPopup.CurrentCallbackKey, value.ToString());
        }

        private delegate void MonoPMessageDelegate(bool response);
    }
}