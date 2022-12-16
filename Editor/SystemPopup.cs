using System.Collections.Generic;
using UnityEngine;

namespace NativePopups
{
    public static class SystemPopup
    {
        public static void Show(string key, string settings)
        {
            Debug.LogError("Show:\n" + settings);
            PopupsFactory popupsFactory = new PopupsFactory();
            var popupsLayout = popupsFactory.Create();
            var settingsData = JsonUtility.FromJson<PopupSettings>(settings);

            List<PopupSettings.ButtonSettings> buttonsText = new List<PopupSettings.ButtonSettings>();
            
            if (string.IsNullOrEmpty(settingsData.buttonNegative.text) == false)
                buttonsText.Add(settingsData.buttonNegative); 
            if (string.IsNullOrEmpty(settingsData.buttonPositive.text) == false)
                buttonsText.Add(settingsData.buttonPositive);
            if (string.IsNullOrEmpty(settingsData.buttonNeutral.text) == false)
                buttonsText.Add(settingsData.buttonNeutral);

            string title = "";
            string content = "";
            
            if (string.IsNullOrEmpty(settingsData.title.text) == false)
            {
                title = settingsData.title.text;
            }

            if (string.IsNullOrEmpty(settingsData.content.text) == false)
            {
                content = settingsData.content.text;
            }
            popupsLayout.ShowPopup(key, buttonsText.Count, title, content, buttonsText.ToArray());
        }
       
    }
}