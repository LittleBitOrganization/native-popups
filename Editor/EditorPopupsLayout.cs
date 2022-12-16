using UnityEngine;

namespace NativePopups
{
    public class EditorPopupsLayout : MonoBehaviour
    {
        public EditorPopupLayout CurrentPopupLayout { get; private set; }
        
        [SerializeField] private EditorPopupLayout[] popups;

        private EditorPopupsService _editorPopupsService;

        private void OnEnable()
        {
            _editorPopupsService = new EditorPopupsService();
            _editorPopupsService.Initialize();
        }

        private void OnDisable() => _editorPopupsService.Destroy();

        public void ShowPopup(int popupIndex, string title, string description, string[] buttonsTitles)
        {
            popups[popupIndex].gameObject.SetActive(true);
            popups[popupIndex].UpdateView(title, description, buttonsTitles);
            CurrentPopupLayout = popups[popupIndex];
        }
    }
}