using UnityEngine;

namespace NativePopups
{
    public static class PopupsFactory
    {
        public static GameObject EditorPopupLayout;
        
        public static EditorPopupsLayout GetPopup(GameObject root)
        {
            EditorPopupLayout = GameObject.Instantiate(Resources.Load<GameObject>("EditorPopup"), root.transform);
            
            var editorPopupLayout = EditorPopupLayout.GetComponent<EditorPopupsLayout>();
            
            return editorPopupLayout;
        }
    }
}