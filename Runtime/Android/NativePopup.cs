using System;
using UnityEngine;

namespace NativePopups
{
    public static class NativePopup
    {
        public static void ShowOneButton(string title, string message, string buttonTitle, string callbackKey)
        {
            
        }

        public static void ShowTwoButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string callbackKey)
        {
            OpenSettingsData openSettingsData = new OpenSettingsData();
            openSettingsData.content.text = message;
            openSettingsData.title.text = title;
            
            openSettingsData.buttonNegative.text = firstButtonTitle;
            openSettingsData.buttonNegative.callbackMessage = false;
            
            openSettingsData.buttonPositive.text = secondButtonTitle;
            openSettingsData.buttonPositive.callbackMessage = true;

            var json = JsonUtility.ToJson(openSettingsData, true);

            Debug.LogError(json);
            
            new AndroidJavaClass("com.littlebit.popups.PopupManager")
                .CallStatic("ShowPopupFromUnity", "Alert", json);
            
            void OnClick(string response)
            {
                JavaMessageHandler.RemoveMessageListener(callbackKey, OnClick);
            }

            JavaMessageHandler.AddMessageListener(callbackKey, OnClick);
        }


        public static void ShowThreeButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string thirdButtonTitle, string callbackKey)
        {
            
        }

        public static void ShareMessage(string message, string url = "")
        {
            
        }
        
    }
    
    [Serializable]
    public class OpenSettingsData {

        public TextSettings title = new TextSettings();
        public TextSettings content = new TextSettings();
        public ButtonSettings buttonPositive = new ButtonSettings();
        public ButtonSettings buttonNegative = new ButtonSettings();
        public ButtonSettings buttonNeutral = new ButtonSettings();

        public OpenSettingsData() {

        }
        
        [Serializable]
        public class ButtonSettings {

            public string text;
            public bool callbackMessage;

            public ButtonSettings() {
                text = null;
            }
            
        }

        [Serializable]
        public class TextSettings {
            public string text;

            public TextSettings() {
                text = null;
            }
        }

    }
}