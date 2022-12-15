using System;

namespace NativePopups
{
    public static class MessageHandler
    {
        public static event Action<string, bool> ResponseReceived;
    }
}