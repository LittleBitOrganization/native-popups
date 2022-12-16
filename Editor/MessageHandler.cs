using System;
using System.Collections.Generic;
using UnityEngine;

namespace NativePopups
{
    public static class MessageHandler
    {
        public static ISystemMessageHandler System { get; private set; }
    
        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            System = new UnityMessageHandler();
        }
     
        public static void OnMessage(string key, string value)
        {
            System.OnMessage(key, value);
        }
    }
    
    public class UnityMessageHandler : ISystemMessageHandler
    {
        public Dictionary<string, Action<string>> MessageListeners { get; }
    
        public UnityMessageHandler()
        {
            MessageListeners = new Dictionary<string, Action<string>>();
        }
    
        public void AddMessageListener(string keyMessage, Action<string> onMessage)
        {
            this.AddListener(keyMessage, onMessage);
        }
    
        public void RemoveMessageListener(string keyMessage, Action<string> onMessage)
        {
            this.RemoveListener(keyMessage, onMessage);
        }
    
        public void OnMessage(string keyMessage, string message)
        {
            this.OnCallMessage(keyMessage, message);
        }

    
    }
}