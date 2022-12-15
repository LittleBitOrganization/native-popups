using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace NativePopups
{
    public class EditorPopup : MonoBehaviour
    {
        public List<ButtonPopup> Buttons { get; private set; }
        
        [SerializeField] private Text title;
        [SerializeField] private Text description;
        [SerializeField] private GameObject buttonsContainer;

        public void UpdateView(string title, string description, string[] buttonsTitles)
        {
            this.title.text = title;
            this.description.text = description;
            UpdateButtons(buttonsTitles);
        }

        private void UpdateButtons(string[] buttonsTitles)
        {
            Buttons = buttonsContainer.GetComponentsInChildren<ButtonPopup>().ToList();

            for (int i = 0; i < Buttons.Count; i++)
            {
                if (buttonsTitles[i] is not null)
                    Buttons[i].buttonText.text = buttonsTitles[i];
                else
                    Buttons[i].buttonText.text = "Nothing";
            }
        }
    }
}