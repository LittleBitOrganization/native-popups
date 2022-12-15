using UnityEngine;

namespace NativePopups
{
    public class PopupsFactory
    {
        private EditorPopupsService _editorPopupService;
        
        public EditorPopupsService GetPopup()
        {
            GameObject popupGO = Resources.Load<GameObject>("EditorPopup.prefab");
            
            GameObject.Instantiate(popupGO);
            
            _editorPopupService = popupGO.GetComponent<EditorPopupsService>();
            
            return _editorPopupService;
        }

        public void DeletePopup() => GameObject.Destroy(_editorPopupService.gameObject);
    }
}