using UnityEngine;

public static class MessageHandler
{
    // Данный класс будет реализовывать Java Interface, который описан ниже
    private class JavaMessageHandler : AndroidJavaProxy
    {
        public JavaMessageHandler() : base("com.plugin.JavaMessageHandler") {}

        public void OnMessage(string message, string data) {
            Debug.Log(message);
            Debug.Log(data);
            // Переадресуем наше сообщение всем желающим
            //MessageRouter.RouteMessage(message, data);
        }
    }
   
    // Этот метод будет вызываться автоматически при инициализации Unity Engine в игре
    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        
        new AndroidJavaClass("com.plugin.UnityBridge")
            .CallStatic("registerMessageHandler", new JavaMessageHandler());
#if UNITY_ANDROID && !UNITY_EDITOR
      // Создаем инстанс JavaMessageHandler и передаем его
        new AndroidJavaClass("com.plugin.UnityBridge")
            .CallStatic("registerMessageHandler", new JavaMessageHandler());
#endif
    }
}