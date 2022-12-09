using UnityEngine;
using UnityEngine.UI;

namespace iOS
{
    public class UIBindings : MonoBehaviour
    {
        [SerializeField] private Button showAlertButton;

        private void Start()  
        {
            showAlertButton.onClick.AddListener(ShowBasicAlert);
        }

        private void ShowBasicAlert() 
            => NativePopup.ShowAlert("Basic Alert", "Hello this is a basic alert !");
    }
}