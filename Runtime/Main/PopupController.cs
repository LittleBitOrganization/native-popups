using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public class PopupController : MonoBehaviour
    {
        [SerializeField] private Button showOneButton;
        [SerializeField] private Button showTwoButton;
        [SerializeField] private Button showThreeButton;
        [SerializeField] private TextMeshProUGUI result;

        private void Awake() => Subscribe();

        private void Subscribe()
        {
            showOneButton.onClick.AddListener(() =>
            {
                NativePopupFactory nativePopupFactory = new NativePopupFactory();
                nativePopupFactory.Create()
                    .SetContent("Abcdefsfgsd klgd gdsk;l gsdkg lsdk")
                    .SetTitle("New Title")
                    .AddPositiveButton("Ok", () =>
                    {
                        Debug.LogError("Click Ok in Controller");
                        result.text = "Result : Positive";
                    })
                    .Show();

            });
            
            showTwoButton.onClick.AddListener(() =>
            {
                NativePopupFactory nativePopupFactory = new NativePopupFactory();
                nativePopupFactory.Create()
                    .SetContent("Abcdefsfgsd klgd gdsk;l gsdkg lsdk")
                    .SetTitle("New Title")
                    .AddPositiveButton("Ok", () =>
                    {
                        Debug.LogError("Click Ok in Controller");
                        result.text = "Result : Positive";
                    })
                    .AddNegativeButton("Not Now", () =>
                    {
                        Debug.LogError("Click Now Now in Controller");
                        result.text = "Result : Negative";
                    })
                    .Show();

            });
            
            showThreeButton.onClick.AddListener(() =>
            {
                NativePopupFactory nativePopupFactory = new NativePopupFactory();
                nativePopupFactory.Create()
                    .SetContent("Abcdefsfgsd klgd gdsk;l gsdkg lsdk")
                    .SetTitle("New Title")
                    .AddPositiveButton("Ok", () =>
                    {
                        Debug.LogError("Click Ok in Controller");
                        result.text = "Result : Positive";
                    })
                    .AddNegativeButton("Not Now", () =>
                    {
                        Debug.LogError("Click Now Now in Controller");
                        result.text = "Result : Negative";
                    })
                    .AddNeutralButton("Neutral", () =>
                    {
                        Debug.LogError("Neutral");
                        result.text = "Result : Neutral";
                    })
                    .Show();

            });
        }
    }
}