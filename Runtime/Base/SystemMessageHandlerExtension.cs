using System;

public static class SystemMessageHandlerExtension
{
    public static void AddListener(this ISystemMessageHandler handler, 
        string keyMessage,
        Action<string> onMessage)
    {
        if (handler.MessageListeners.ContainsKey(keyMessage) == false)
            handler.MessageListeners[keyMessage] = onMessage;
        else
            handler.MessageListeners[keyMessage] += onMessage;
    }
    
    public static void RemoveListener(this ISystemMessageHandler handler, string keyMessage, Action<string> onMessage)
    {
        if (handler.MessageListeners.ContainsKey(keyMessage) == false) return;
        handler.MessageListeners[keyMessage] -= onMessage;
    }
    
    public static void OnCallMessage(this ISystemMessageHandler handler, string keyMessage, string message)
    {
        if (handler.MessageListeners.ContainsKey(keyMessage))
        {
            handler.MessageListeners[keyMessage].Invoke(message);
        }
    }
}