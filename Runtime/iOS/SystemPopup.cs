using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace NativePopups
{
    public static class SystemPopup
    {
        public static string CurrentCallbackKey;
        
        [DllImport("__Internal")]
        private static extern void _ShowOneButton(string key, string title, string message, string buttonTitle, string buttonCallback);
        
        [DllImport("__Internal")]
        private static extern void _ShowTwoButton(string key, string title, string message, string positiveButtonTitle, 
            string negativeButtonTitle, string positiveButtonCallback, string negativeButtonCallback);
        
        [DllImport("__Internal")]
        private static extern void _ShowThreeButton(string key, string title, string message, string firstButtonTitle, 
            string secondButtonTitle, string thirdButtonTitle, string firstButtonCallback, string secondButtonCallback, string thirdButtonCallback);

        public static void Show(string key, string settings)
        {
            PopupSettings settingsObject = JsonUtility.FromJson<PopupSettings>(settings);

            string title = settingsObject.title.text;
            string message = settingsObject.content.text;
            List<PopupSettings.ButtonSettings> buttonSettings = new List<PopupSettings.ButtonSettings>();

            if (!string.IsNullOrEmpty(settingsObject.buttonNegative.text))
                buttonSettings.Add(settingsObject.buttonNegative);
            if (!string.IsNullOrEmpty(settingsObject.buttonNeutral.text))
                buttonSettings.Add(settingsObject.buttonNeutral);
            if (!string.IsNullOrEmpty(settingsObject.buttonPositive.text))
                buttonSettings.Add(settingsObject.buttonPositive);
            
            if (buttonSettings.Count == 1)
                ShowOneButton(key, title, message, buttonSettings[0].text, buttonSettings[0].callbackMessage);
            else if (buttonSettings.Count == 2)
                ShowTwoButton(key, title, message, buttonSettings[1].text, buttonSettings[0].text,
                    buttonSettings[1].callbackMessage, buttonSettings[0].callbackMessage);
            else if (buttonSettings.Count == 3)
                ShowThreeButton(key, title, message, buttonSettings[0].text, buttonSettings[1].text, buttonSettings[2].text,
                    buttonSettings[0].callbackMessage, buttonSettings[1].callbackMessage, buttonSettings[2].callbackMessage);
        }

        public static void ShowOneButton(string callbackKey, string title, string message, string buttonTitle, string buttonCallback)
        {
            _ShowOneButton(callbackKey, title, message, buttonTitle, buttonCallback);
            CurrentCallbackKey = callbackKey;
        }

        public static void ShowTwoButton(string callbackKey, string title, string message, string positiveButtonTitle, 
            string negativeButtonTitle, string positiveButtonCallback, string negativeButtonCallback)
        {
            _ShowTwoButton(callbackKey, title, message, positiveButtonTitle, negativeButtonTitle, positiveButtonCallback, negativeButtonCallback);
            CurrentCallbackKey = callbackKey;
        }

        public static void ShowThreeButton(string callbackKey, string title, string message, string firstButtonTitle, 
            string secondButtonTitle, string thirdButtonTitle, string firstButtonCallback, string secondButtonCallback, string thirdButtonCallback)
        {
            _ShowThreeButton(callbackKey, title, message, firstButtonTitle, secondButtonTitle, thirdButtonTitle, firstButtonCallback, secondButtonCallback, thirdButtonCallback);
            CurrentCallbackKey = callbackKey;
        }
    }
}