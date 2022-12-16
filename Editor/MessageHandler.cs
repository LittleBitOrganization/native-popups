using System;

namespace NativePopups
{
    public static class MessageHandler
    {
        public static event Action<string, bool> ResponseReceived;

        public static void SendResponse(ButtonPopupLayout button) 
            => ResponseReceived?.Invoke(NativePopup.CurrentCallbackKey, button.ResponseValue);
    }
}