using UnityEngine;
using UnityEngine.UI;

namespace NativePopups
{
    public class ButtonPopupHandler : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private ButtonPopupLayout buttonPopupLayout;

        private void OnEnable() => button.onClick.AddListener(SendClick);

        private void OnDisable() => button.onClick.RemoveListener(SendClick);

        private void SendClick() => MessageHandler.SendResponse(buttonPopupLayout);
    }
}