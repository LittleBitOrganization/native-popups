using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace NativePopups
{
    public class EditorPopupLayout : MonoBehaviour
    {
        public List<ButtonPopupLayout> Buttons { get; private set; }
        
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
            Buttons = buttonsContainer.GetComponentsInChildren<ButtonPopupLayout>().ToList();

            for (int i = 0; i < Buttons.Count; i++)
            {
                if (buttonsTitles[i] is not null)
                    Buttons[i].ButtonText.text = buttonsTitles[i];
                else
                    Buttons[i].ButtonText.text = "Nothing";
            }
        }
    }
}