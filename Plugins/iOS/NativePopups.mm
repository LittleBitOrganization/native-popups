#import "UnityAppController.h"
#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

extern UIViewController *UnityGetGLViewController();

@interface NativePopups : NSObject

@end

@implementation NativePopups

+(void)showOneButton:(NSString*)title addMessage:(NSString*) message addButtonTitle:(NSString*) buttonTitle
{
    UIAlertController *alert = [UIAlertController alertControllerWithTitle:title
                                                                   message:message preferredStyle:UIAlertControllerStyleAlert];
    
    UIAlertAction *defaultAction = [UIAlertAction actionWithTitle:@buttonTitle style:UIAlertActionStyleDefault handler:nil];
    
    [alert addAction:defaultAction];
    [UnityGetGLViewController() presentViewController:alert animated:YES completion:nil];
}

+(void)showTwoButton:(NSString*)title addMessage:(NSString*)message addFirstButtonTitle:(NSString*) firstButtonTitle addSecondButtonTitle:(NSString*) secondButtonTitle addCallBack:(NSString*)callback
{
    UIAlertController *alert = [UIAlertController alertControllerWithTitle:title
                                                                   message:message preferredStyle:UIAlertControllerStyleAlert];
    
    UIAlertAction *okAction = [UIAlertAction actionWithTitle:@"OK" style:UIAlertActionStyleDefault
                                                     handler:^(UIAlertAction *action){
                                                         UnitySendMessage("NativePopupCallbacks", [callback UTF8String], "");
                                                     }];
    
    UIAlertAction *cancelAction = [UIAlertAction actionWithTitle:@"Cancel" style:UIAlertActionStyleCancel handler:nil];
    
    [alert addAction:okAction];
    [alert addAction:cancelAction];
    [UnityGetGLViewController() presentViewController:alert animated:YES completion:nil];
}

+(void)shareView:(NSString *)message addUrl:(NSString *)url
{
    NSURL *postUrl = [NSURL URLWithString:url];
    NSArray *postItems=@[message,postUrl];
    UIActivityViewController *controller = [[UIActivityViewController alloc] initWithActivityItems:postItems applicationActivities:nil];
    
    //if iPhone
    if (UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPhone) {
        [UnityGetGLViewController() presentViewController:controller animated:YES completion:nil];
    }
    //if iPad
    else {
        UIPopoverPresentationController *popOver = controller.popoverPresentationController;
        if(popOver){
            popOver.sourceView = controller.view;
            popOver.sourceRect = CGRectMake(UnityGetGLViewController().view.frame.size.width/2, UnityGetGLViewController().view.frame.size.height/4, 0, 0);
            [UnityGetGLViewController() presentViewController:controller animated:YES completion:nil];
        }
    }
}

@end

extern "C"
{
    void _ShowOneButton(const char *title, const char *message, const char *buttonTitle)
    {
        [NativePopups showOneButton:[NSString stringWithUTF8String:title] addMessage:[NSString stringWithUTF8String:message] addButtonTitle:[NSString stringWithUTF8String:buttonTitle]];
    }
    
    void _ShowTwoButton(const char *title, const char *message, const char *firstButtonTitle, const char *secondButtonTitle, const char *callBack)
    {
        [NativePopups showTwoButton:[NSString stringWithUTF8String:title] addMessage:[NSString stringWithUTF8String:message] addFirstButtonTitle:[NSString stringWithUTF8String:firstButtonTitle] addSecondButtonTitle:[NSString stringWithUTF8String:secondButtonTitle]  addCallBack:[NSString stringWithUTF8String:callBack]];
    }
    
    void _ShareMessage(const char *message, const char *url)
    {
        [NativePopups shareView:[NSString stringWithUTF8String:message] addUrl:[NSString stringWithUTF8String:url]];
    }
}
