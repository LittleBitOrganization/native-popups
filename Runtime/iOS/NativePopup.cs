using System.Runtime.InteropServices;

namespace iOS
{
    public static class NativePopup
    {
        [DllImport("__Internal")]
        private static extern void _ShowOneButton(string title, string message, string buttonTitle, string callbackKey);
        
        [DllImport("__Internal")]
        private static extern void _ShowTwoButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string callbackKey);

        [DllImport("__Internal")]
        private static extern void _ShareMessage(string message, string url);

        public static void ShowOneButton(string title, string message, string buttonTitle, string callbackKey) 
            => _ShowOneButton(title, message, buttonTitle, callbackKey);
        
        public static void ShowTwoButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string callbackKey) 
            => _ShowTwoButton(title, message, firstButtonTitle, secondButtonTitle, callbackKey);

        public static void ShareMessage(string message, string url = "") => _ShareMessage(message, url);
    }
}