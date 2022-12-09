using System.Runtime.InteropServices;
using UnityEngine;

namespace iOS
{
    public class NativePopup : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void _ShowAlert(string title, string message);

        public static void ShowAlert(string title, string message) => _ShowAlert(title, message);
    }
}