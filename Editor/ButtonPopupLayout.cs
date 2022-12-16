using System;
using UnityEngine;
using UnityEngine.UI;

namespace NativePopups
{
    public class ButtonPopupLayout : MonoBehaviour
    {
        [field: SerializeField] private Text ButtonText { get; set; }
        [field: SerializeField] private Button Button { get; set; }
        
        private string _responseValue;
        public void Init(string responseValue, string text)
        {
            Button.onClick.RemoveAllListeners();
            _responseValue = responseValue;
            ButtonText.text = text;
        }

        public void AddClickListener(Action<string> onCLick)
        {
            Button.onClick.AddListener(() =>
            {
                onCLick?.Invoke(_responseValue);
            });
        }
    }
}