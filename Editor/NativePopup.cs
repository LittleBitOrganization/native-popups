namespace NativePopups
{
    public static class NativePopup
    {
        public static EditorPopupsService EditorPopupsService { get; private set; }
        public static string CurrentCallbackKey { get; private set; }

        private static PopupsFactory _popupsFactory = new PopupsFactory();
        
        public static void ShowOneButton(string title, string message, string buttonTitle, string callbackKey)
        {
            var editorPopupsService = _popupsFactory.GetPopup();
            editorPopupsService.ShowPopup(0, title, message, new []{buttonTitle});
            CurrentCallbackKey = callbackKey;
        }

        public static void ShowTwoButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string callbackKey)
        {
            var editorPopupsService = _popupsFactory.GetPopup();
            editorPopupsService.ShowPopup(0, title, message, new []{firstButtonTitle, secondButtonTitle});
            CurrentCallbackKey = callbackKey;
        }

        public static void ShowThreeButton(string title, string message, string firstButtonTitle, string secondButtonTitle, string thirdButtonTitle, string callbackKey)
        {
            var editorPopupsService = _popupsFactory.GetPopup();
            editorPopupsService.ShowPopup(0, title, message, new []{firstButtonTitle, secondButtonTitle, thirdButtonTitle});
            CurrentCallbackKey = callbackKey;
        }

        public static void ShareMessage(string message, string url = "")
        {
            
        }
    }
}