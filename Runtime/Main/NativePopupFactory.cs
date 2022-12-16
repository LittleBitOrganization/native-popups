public class NativePopupFactory
{
    public NativePopupFactory()
    {
        
    }

    public NativePopup Create()
    {
        return new NativePopup();
    }
}


public class S
{
    public S(NativePopupFactory factory)
    {
        // factory
        //     .Create()
        //     .AddPositiveButton()
        //     .SetTitle()
        //     .Show();
    }
}