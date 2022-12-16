using UnityEngine;
using UnityEngine.UI;

namespace NativePopups
{
    public class ButtonPopupLayout : MonoBehaviour
    {
        [field: SerializeField] public Text ButtonText { get; set; }
        [field: SerializeField] public Button Button { get; private set; }
        [field: SerializeField] public bool ResponseValue { get; private set; }
    }
}