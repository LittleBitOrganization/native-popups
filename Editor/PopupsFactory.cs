using UnityEngine;

namespace NativePopups
{
    public static class PopupsFactory
    {
        private static EditorPopupsService _editorPopupService;
        
        public static EditorPopupsService GetPopup(GameObject root)
        {
            GameObject popupGO = Resources.Load<GameObject>("EditorPopup");
            
            GameObject.Instantiate(popupGO, root.transform);
            
            _editorPopupService = popupGO.GetComponent<EditorPopupsService>();
            
            return _editorPopupService;
        }

        public static void DeletePopup() => GameObject.Destroy(_editorPopupService.gameObject);
    }
}