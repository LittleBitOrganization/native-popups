using System;
using System.Collections.Generic;
using UnityEngine;

public static class MessageHandler
{
    
    // Этот метод будет вызываться автоматически при инициализации Unity Engine в игре
    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    { 
        new AndroidJavaClass("com.littlebit.popups.UnityBridge")
            .CallStatic("registerMessageHandler", new JavaMessageHandler());
#if UNITY_ANDROID && !UNITY_EDITOR
      // Создаем инстанс JavaMessageHandler и передаем его
        new AndroidJavaClass("com.plugin.UnityBridge")
            .CallStatic("registerMessageHandler", new JavaMessageHandler());
#endif
    }
    
}

// Данный класс будет реализовывать Java Interface, который описан ниже
internal class JavaMessageHandler : AndroidJavaProxy
{
    private static readonly Dictionary<string, Action<string>> MessageListeners = new Dictionary<string, Action<string>>();
        
    public static void AddMessageListener(string message, Action<string> onMessage)
    {
        MessageListeners.Add(message, onMessage);
    }
    public JavaMessageHandler() : base("com.plugin.JavaMessageHandler") {}

    public void OnMessage(string message, string data) {

        if (MessageListeners.ContainsKey(message))
        {
            MessageListeners[message].Invoke(data);
        }
        Debug.Log(message);
        Debug.Log(data);
        // Переадресуем наше сообщение всем желающим
        //MessageRouter.RouteMessage(message, data);
    }
}