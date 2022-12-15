using System.Runtime.InteropServices;

namespace NativePopups
{
    public static class NativePopup
    {
        public static string CurrentCallbackKey;
        
        [DllImport("__Internal")]
        private static extern void _ShowOneButton(string title, string message, string buttonTitle);
        
        [DllImport("__Internal")]
        private static extern void _ShowTwoButton(string title, string message, string firstButtonTitle, string secondButtonTitle);
        
        [DllImport("__Internal")]
        private static extern void _ShowThreeButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string thirdButtonTitle);

        [DllImport("__Internal")]
        private static extern void _ShareMessage(string message, string url);

        public static void ShowOneButton(string title, string message, string buttonTitle, string callbackKey)
        {
            _ShowOneButton(title, message, buttonTitle);
            CurrentCallbackKey = callbackKey;
        }

        public static void ShowTwoButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string callbackKey)
        {
            _ShowTwoButton(title, message, firstButtonTitle, secondButtonTitle);
            CurrentCallbackKey = callbackKey;
        }

        public static void ShowThreeButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string thirdButtonTitle, string callbackKey)
        {
            _ShowThreeButton(title, message, firstButtonTitle, secondButtonTitle, thirdButtonTitle);
            CurrentCallbackKey = callbackKey;
        }

        public static void ShareMessage(string message, string url = "") => _ShareMessage(message, url);
    }
}