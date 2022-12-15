using System.Collections.Generic;
using UnityEngine;

namespace NativePopups
{
    public class EditorPopupsService : MonoBehaviour
    {
        public EditorPopup CurrentPopup { get; private set; }
        
        [SerializeField] private List<EditorPopup> popups;

        public void ShowPopup(int popupIndex, string title, string description, string[] buttonsTitles)
        {
            popups[popupIndex].gameObject.SetActive(true);
            popups[popupIndex].UpdateView(title, description, buttonsTitles);
            CurrentPopup = popups[popupIndex];
        }
    }
}