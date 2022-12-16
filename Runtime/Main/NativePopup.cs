using System;
using NativePopups;
using UnityEngine;

public class NativePopup : INativePopup
{
    private readonly PopupSettings _settings;
    private Action _positiveButtonClick;
    private Action _negativeButtonClick;
    private Action _neutralButtonClick;
    
    
    public NativePopup()
    {
        _settings = new PopupSettings();
    }

    public NativePopup AddPositiveButton(string text, Action onClick)
    {
        _positiveButtonClick = onClick;
        _settings.buttonPositive.text = text;
        _settings.buttonPositive.callbackMessage = ((int)PopupSettings.TypeResponse.Positive).ToString();
        return this;
    }
    
    public NativePopup AddNegativeButton(string text, Action onClick)
    {
        _negativeButtonClick = onClick;
        _settings.buttonNegative.text = text;
        _settings.buttonNegative.callbackMessage = ((int)PopupSettings.TypeResponse.Negative).ToString();
        return this;
    }
    
    public NativePopup AddNeutralButton(string text, Action onClick)
    {
        _neutralButtonClick = onClick;
        _settings.buttonNeutral.text = text;
        _settings.buttonNeutral.callbackMessage = ((int)PopupSettings.TypeResponse.Neutral).ToString();
        return this;
    }

    public NativePopup SetTitle(string text)
    {
        _settings.title.text = text;
        return this;
    }

    public NativePopup SetContent(string text)
    {
        _settings.content.text = text;
        return this;
    }

    public void Show()
    {
        var settings = JsonUtility.ToJson(_settings, true);

        void OnCallResponse(string value)
        {
            var intValue = Convert.ToInt32(value);
            PopupSettings.TypeResponse typeResponse = (PopupSettings.TypeResponse)intValue;
            if(typeResponse == PopupSettings.TypeResponse.Positive)
                _positiveButtonClick?.Invoke();
            else if(typeResponse == PopupSettings.TypeResponse.Neutral) 
                _neutralButtonClick?.Invoke();
            else if(typeResponse == PopupSettings.TypeResponse.Negative) 
                _negativeButtonClick?.Invoke();
            
            MessageHandler.System.RemoveMessageListener("alert", OnCallResponse);
        }

        MessageHandler.System.AddMessageListener("alert", OnCallResponse);
        NativePopups.SystemPopup.Show("alert", settings);
        
        
        
    }
}


