using System;
using System.Collections.Generic;

internal class ObjectiveCMessageHandler : ISystemMessageHandler
{
    public Dictionary<string, Action<string>> MessageListeners { get; }
    
    public ObjectiveCMessageHandler()
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