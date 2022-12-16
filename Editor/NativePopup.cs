using System;
using UnityEngine;

namespace NativePopups
{
    public static class NativePopup
    {
        public static event Action<EditorPopupsService> PopupShowed;
        
        public static string CurrentCallbackKey { get; private set; }

        public static GameObject Root;

        public static void ShowOneButton(string title, string message, string buttonTitle, string callbackKey)
        {
            var editorPopupsService = PopupsFactory.GetPopup(Root);
            editorPopupsService.ShowPopup(0, title, message, new []{buttonTitle});
            CurrentCallbackKey = callbackKey;
            PopupShowed?.Invoke(editorPopupsService);
        }

        public static void ShowTwoButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string callbackKey)
        {
            var editorPopupsService = PopupsFactory.GetPopup(Root);
            editorPopupsService.ShowPopup(1, title, message, new []{firstButtonTitle, secondButtonTitle});
            CurrentCallbackKey = callbackKey;
            PopupShowed?.Invoke(editorPopupsService);
        }

        public static void ShowThreeButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string thirdButtonTitle, string callbackKey)
        {
            var editorPopupsService = PopupsFactory.GetPopup(Root);
            editorPopupsService.ShowPopup(2, title, message, new []{firstButtonTitle, secondButtonTitle, thirdButtonTitle});
            CurrentCallbackKey = callbackKey;
            PopupShowed?.Invoke(editorPopupsService);
        }

        public static void ShareMessage(string message, string url = "")
        {
            
        }
    }
}