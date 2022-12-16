using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace NativePopups
{
    public class EditorPopupsLayout : MonoBehaviour
    {
        
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private GameObject buttonsContainer;
        private List<ButtonPopupLayout> _buttons;

        
        public void ShowPopup(
            string key, 
            int popupIndex, 
            string title, 
            string description, 
            PopupSettings.ButtonSettings[] buttonsTitles)
        {
            _title.text = title;
            _description.text = description;
            gameObject.SetActive(true);

            UpdateButtons(key, buttonsTitles);
        }


        private void UpdateButtons(string key, PopupSettings.ButtonSettings[] buttonsTitles)
        {
            Debug.LogError("ButtonSettings:" + buttonsTitles.Length);
            _buttons = buttonsContainer.GetComponentsInChildren<ButtonPopupLayout>(true).ToList();
            for (int i = 0; i < _buttons.Count; i++)
            {
                if (i < buttonsTitles.Length)
                {
                    _buttons[i].gameObject.SetActive(true);
                    _buttons[i].Init(buttonsTitles[i].callbackMessage, buttonsTitles[i].text);
                    _buttons[i].AddClickListener((response) =>
                    {
                        MessageHandler.System.OnMessage(key, response);
                        Destroy();
                    });
                }
                else
                {
                    _buttons[i].gameObject.SetActive(false);
                    _buttons[i].Init("Nothing", "Nothing");
                }
            }
        }
        
        
        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}