using UnityEngine;
using UnityEngine.UI;

namespace NativePopups
{
    public class ButtonPopup : MonoBehaviour
    {
        public Text buttonText;
        [field: SerializeField] public bool ResponseValue { get; private set; }
    }
}