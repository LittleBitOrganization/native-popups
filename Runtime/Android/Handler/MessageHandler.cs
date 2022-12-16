using UnityEngine;

namespace NativePopups
{
    public static class MessageHandler
    {
        public static ISystemMessageHandler System { get; private set; }
    
        [RuntimeInitializeOnLoadMethod]
        private static void Initialize()
        {
            System = new JavaMessageHandler();
        
            new AndroidJavaClass("com.littlebit.popups.UnityBridge")
                .CallStatic("registerMessageHandler", System);
        }
    }

}
