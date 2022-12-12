using UnityEngine;
using System;

namespace Android
{
	public static class NativePopup 
	{
		public static event Action<string> PressedPositiveEvent;
		public static event Action<string> PressedNegativeEvent;
		public static event Action<string> PressedNeutralEvent;
	
		private static AndroidJavaObject _javaObject;
		private static AndroidJavaClass _javaClass;

		public static void Initialize()
		{
			_javaClass = new AndroidJavaClass("com.werplay.androidutilities.CallActivity"); 
			_javaObject = _javaClass.CallStatic<AndroidJavaObject>("getInstance");
			_javaObject.Call("setObjectName", "AndroidNativePopup");
		}

		public static void ShowDialogBoxWithThreeButtons(
			string title, 
			string message, 
			string positiveButtonText, 
			string negativeButtonText, 
			string neutralButtonText,
			string iconName, 
			string tag) 
			=> _javaObject.Call(
				"dialogBoxWithThreeButtons", 
				title, 
				message, 
				positiveButtonText, 
				negativeButtonText, 
				neutralButtonText, 
				iconName, 
				tag);

		public static void ShowDialogBoxWithTwoButtons(
			string title, 
			string message, 
			string positiveButtonText, 
			string negativeButtonText, 
			string iconName, 
			string tag) 
			=> _javaObject.Call(
				"dialogBoxWithTwoButtons", 
				title, 
				message, 
				positiveButtonText, 
				negativeButtonText, 
				iconName, 
				tag);

		public static void ShowDialogBoxWithOneButton(
			string title, 
			string message, 
			string positiveButtonText, 
			string iconName, 
			string tag) 
			=> _javaObject.Call(
				"dialogBoxWithOneButton", 
				title, 
				message, 
				positiveButtonText, 
				iconName, 
				tag);

		public static void ShowToastLong(string message) => _javaObject.Call("toastLong", message);

		public static void ShowToastShort(string message) => _javaObject.Call("toastShort", message);

		public static void PressedPositive(string tag) => PressedPositiveEvent?.Invoke(tag);

		public static void PressedNegative(string tag) => PressedNegativeEvent?.Invoke(tag);

		public static void PressedNeutral(string tag) => PressedNeutralEvent?.Invoke(tag);
	}
}