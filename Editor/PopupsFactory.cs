using UnityEngine;

namespace NativePopups
{
    public class PopupsFactory
    {
        
        public EditorPopupsLayout Create(Transform root = null)
        {
            var go = GameObject.Instantiate(Resources.Load<GameObject>("EditorPopupCanvas"), root);
            var editorPopupLayout = go.GetComponentInChildren<EditorPopupsLayout>();
            
            return editorPopupLayout;
        }
    }
}