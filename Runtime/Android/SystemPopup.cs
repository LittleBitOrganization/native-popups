using System;
using UnityEngine;

namespace NativePopups
{
    public static class SystemPopup
    {
        public static void Show(string key, string settings)
        {
            new AndroidJavaClass("com.littlebit.popups.PopupManager")
                .CallStatic("ShowPopupFromUnity", key, settings);
        }

        // public static void ShowTwoButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string callbackKey)
        // {
        //     OpenSettingsData openSettingsData = new OpenSettingsData();
        //     openSettingsData.content.text = message;
        //     openSettingsData.title.text = title;
        //     
        //     openSettingsData.buttonNegative.text = firstButtonTitle;
        //     openSettingsData.buttonNegative.callbackMessage = false;
        //     
        //     openSettingsData.buttonPositive.text = secondButtonTitle;
        //     openSettingsData.buttonPositive.callbackMessage = true;
        //
        //     var json = JsonUtility.ToJson(openSettingsData, true);
        //
        //     Debug.LogError(json);
        //     
        //     
        //     
        //     void OnClick(string response)
        //     {
        //         JavaMessageHandler.RemoveMessageListener(callbackKey, OnClick);
        //     }
        //
        //     JavaMessageHandler.AddMessageListener(callbackKey, OnClick);
        // }
    }
    
    
}