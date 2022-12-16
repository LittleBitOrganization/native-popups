using System;

[Serializable]
public class PopupSettings {

    public TextSettings title = new TextSettings();
    public TextSettings content = new TextSettings();
    public ButtonSettings buttonPositive = new ButtonSettings();
    public ButtonSettings buttonNegative = new ButtonSettings();
    public ButtonSettings buttonNeutral = new ButtonSettings();

    public PopupSettings() {

    }
        
    [Serializable]
    public class ButtonSettings {

        public string text;
        public string callbackMessage;

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
    
    public enum TypeResponse
    {
        Negative = 0,
        Positive = 1,
        Neutral = 2
    }

}