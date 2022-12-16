using System;
using UnityEngine;

namespace NativePopups
{
    public static class MessageHandler
    {
        public static event Action<string, bool> ResponseReceived;

        private static EditorPopupsService _currentEditorPopup;

        [RuntimeInitializeOnLoadMethod]
        private static void Initialize() => NativePopup.PopupShowed += SubcribeButtons;

        private static void SubcribeButtons(EditorPopupsService service)
        {
            _currentEditorPopup = service;
            _currentEditorPopup.CurrentPopup.Buttons
                .ForEach(b => b.Button.onClick.AddListener(() => SendResponse(b)));
        }

        private static void SendResponse(ButtonPopup button)
        {
            ResponseReceived?.Invoke(NativePopup.CurrentCallbackKey, button.ResponseValue);
            PopupsFactory.DeletePopup();
        }
    }
}