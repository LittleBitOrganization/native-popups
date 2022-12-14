using System;
using UnityEngine;

public class Example
{
    public class ResultData
    {
        public bool Success;
        public string ValueStr;
        public int ValueInt;
    }

    public static void ShowMessagePopup() {
        new AndroidJavaClass("com.plugin.Example").CallStatic("ShowMessagePopup");
    }
}
