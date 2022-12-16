using System;
using System.Collections.Generic;

public interface ISystemMessageHandler
{
    public Dictionary<string, Action<string>> MessageListeners { get; }
    public void AddMessageListener(string keyMessage, Action<string> onMessage);
    public void RemoveMessageListener(string keyMessage, Action<string> onMessage);
    public void OnMessage(string keyMessage, string message);

   
}