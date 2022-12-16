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
    }
}

// Данный класс будет реализовывать Java Interface, который описан ниже
internal class JavaMessageHandler : AndroidJavaProxy
{
    private static readonly Dictionary<string, Action<string>> MessageListeners =
        new Dictionary<string, Action<string>>();
    
    public JavaMessageHandler() : base("com.littlebit.popups.MessageHandler.JavaMessageHandler")
    {
    }

    public static void AddMessageListener(string keyMessage, Action<string> onMessage)
    {
        if (MessageListeners.ContainsKey(keyMessage) == false)
            MessageListeners[keyMessage] = onMessage;
        else
            MessageListeners[keyMessage] += onMessage;
    }

    public static void RemoveMessageListener(string keyMessage, Action<string> onMessage)
    {
        if (MessageListeners.ContainsKey(keyMessage) == false) return;
        MessageListeners[keyMessage] -= onMessage;
    }
    
    public void OnMessage(string keyMessage, string message)
    {
        if (MessageListeners.ContainsKey(keyMessage))
        {
            MessageListeners[keyMessage].Invoke(message);
        }
    }
}