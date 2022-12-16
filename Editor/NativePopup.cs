using UnityEngine;

namespace NativePopups
{
    public static class NativePopup
    {
        public static string CurrentCallbackKey { get; private set; }

        public static GameObject Root;

        public static void ShowOneButton(string title, string message, string buttonTitle, string callbackKey)
        {
            var editorPopupsService = PopupsFactory.GetPopup(Root);
            editorPopupsService.ShowPopup(0, title, message, new []{buttonTitle});
            CurrentCallbackKey = callbackKey;
        }

        public static void ShowTwoButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string callbackKey)
        {
            var editorPopupsService = PopupsFactory.GetPopup(Root);
            editorPopupsService.ShowPopup(1, title, message, new []{firstButtonTitle, secondButtonTitle});
            CurrentCallbackKey = callbackKey;
        }

        public static void ShowThreeButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string thirdButtonTitle, string callbackKey)
        {
            var editorPopupsService = PopupsFactory.GetPopup(Root);
            editorPopupsService.ShowPopup(2, title, message, new []{firstButtonTitle, secondButtonTitle, thirdButtonTitle});
            CurrentCallbackKey = callbackKey;
        }

        public static void ShareMessage(string message, string url = "")
        {
            
        }
    }
}