using UnityEngine;

namespace NativePopups
{
    public class EditorPopupsService
    {
        public void Initialize() => MessageHandler.ResponseReceived +=
            (k, r) => GameObject.Destroy(PopupsFactory.EditorPopupLayout);
        
        public void Destroy() => MessageHandler.ResponseReceived -=
            (k, r) => GameObject.Destroy(PopupsFactory.EditorPopupLayout);
    }
}