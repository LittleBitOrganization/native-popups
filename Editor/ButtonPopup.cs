using System;
using UnityEngine;
using UnityEngine.UI;

namespace NativePopups
{
    public class ButtonPopup : MonoBehaviour
    {
        public Text buttonText;
        [field: SerializeField] public Button Button { get; private set; }
        [field: SerializeField] public bool ResponseValue { get; private set; }
    }
}