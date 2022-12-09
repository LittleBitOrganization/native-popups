using System;
using UnityEngine;

namespace iOS
{
    public class NativePopupCallbacks : MonoBehaviour
    {
        public static event Action Successed;

        public void SendCallback() => Successed?.Invoke();
    }
}