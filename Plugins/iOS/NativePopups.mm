#import "UnityAppController.h"
#import <Foundation/Foundation.h>
#import "MessageHandler.h"
#import <UIKit/UIKit.h>

extern UIViewController *UnityGetGLViewController();

@interface NativePopups : NSObject

@end

@implementation NativePopups

+(void)showOneButton:(NSString*)title addMessage:(NSString*) message addButtonTitle:(NSString*) buttonTitle addCallbackKey:(NSString*) callbackKey addButtonCallback:(NSString*) buttonCallback
{
    UIAlertController *alert = [UIAlertController alertControllerWithTitle:title
                                                                   message:message preferredStyle:UIAlertControllerStyleAlert];
    
    UIAlertAction *defaultAction = [UIAlertAction actionWithTitle:buttonTitle style:UIAlertActionStyleDefault
                                                        handler:^(UIAlertAction *action){
                                                            SendMessageToUnity(callbackKey, buttonCallback);
                                                        }];
    
    [alert addAction:defaultAction];
    [UnityGetGLViewController() presentViewController:alert animated:YES completion:nil];
}

+(void)showTwoButton:(NSString*)title addMessage:(NSString*)message addPositiveButtonTitle:(NSString*) positiveButtonTitle addNegativeButtonTitle:(NSString*) negativeButtonTitle addCallbackKey:(NSString*) callbackKey addPositiveButtonCallback:(NSString*) positiveButtonCallback addNegativeButtonCallback:(NSString*) negativeButtonCallback
{
    UIAlertController *alert = [UIAlertController alertControllerWithTitle:title
                                                                   message:message preferredStyle:UIAlertControllerStyleAlert];
    
    UIAlertAction *okAction = [UIAlertAction actionWithTitle:positiveButtonTitle style:UIAlertActionStyleDefault
                                                         handler:^(UIAlertAction *action){
                                                             SendMessageToUnity(callbackKey, positiveButtonCallback);
                                                         }];
    
    UIAlertAction *cancelAction = [UIAlertAction actionWithTitle:negativeButtonTitle style:UIAlertActionStyleCancel 
                                                        handler:^(UIAlertAction *action){
                                                            SendMessageToUnity(callbackKey, negativeButtonCallback);
                                                        }];
    
    [alert addAction:okAction];
    [alert addAction:cancelAction];
    [UnityGetGLViewController() presentViewController:alert animated:YES completion:nil];
}

+(void)showThreeButton:(NSString*)title addMessage:(NSString*)message addFirstButtonTitle:(NSString*) firstButtonTitle addSecondButtonTitle:(NSString*) secondButtonTitle addThirdButtonTitle:(NSString*) thirdButtonTitle addCallbackKey:(NSString*) callbackKey addFirstButtonCallback:(NSString*) firstButtonCallback addSecondButtonCallback:(NSString*) secondButtonCallback addThirdButtonCallback:(NSString*) thirdButtonCallback
{
    UIAlertController *alert = [UIAlertController alertControllerWithTitle:title
                                                                   message:message preferredStyle:UIAlertControllerStyleAlert];
    
    UIAlertAction *okAction = [UIAlertAction actionWithTitle:firstButtonTitle style:UIAlertActionStyleDefault
                                                         handler:^(UIAlertAction *action){
                                                             SendMessageToUnity(callbackKey, firstButtonCallback);
                                                         }];
                                                         
    UIAlertAction *neutralAction = [UIAlertAction actionWithTitle:secondButtonTitle style:UIAlertActionStyleDefault 
                                                         handler:^(UIAlertAction *action){
                                                             SendMessageToUnity(callbackKey, secondButtonCallback);
                                                         }];
    
    UIAlertAction *cancelAction = [UIAlertAction actionWithTitle:thirdButtonTitle style:UIAlertActionStyleCancel 
                                                        handler:^(UIAlertAction *action){
                                                            SendMessageToUnity(callbackKey, thirdButtonCallback);
                                                        }];
    
    [alert addAction:okAction];
    [alert addAction:neutralAction];
    [alert addAction:cancelAction];
    [UnityGetGLViewController() presentViewController:alert animated:YES completion:nil];
}

@end

extern "C"
{
    void _ShowOneButton(const char *callbackKey, const char *title, const char *message, const char *buttonTitle, const char *buttonCallback)
    {
        [NativePopups showOneButton:[NSString stringWithUTF8String:title] 
        addMessage:[NSString stringWithUTF8String:message] 
        addButtonTitle:[NSString stringWithUTF8String:buttonTitle]
        addCallbackKey:[NSString stringWithUTF8String:callbackKey]
        addButtonCallback:[NSString stringWithUTF8String:buttonCallback]];
    }
    
    void _ShowTwoButton(const char *callbackKey, const char *title, const char *message, const char *positiveButtonTitle, const char *negativeButtonTitle, const char *positiveButtonCallback, const char *negativeButtonCallback)
    {
        [NativePopups showTwoButton:[NSString stringWithUTF8String:title] 
        addMessage:[NSString stringWithUTF8String:message] 
        addPositiveButtonTitle:[NSString stringWithUTF8String:positiveButtonTitle] 
        addNegativeButtonTitle:[NSString stringWithUTF8String:negativeButtonTitle]
        addCallbackKey:[NSString stringWithUTF8String:callbackKey]
        addPositiveButtonCallback:[NSString stringWithUTF8String:positiveButtonCallback]
        addNegativeButtonCallback:[NSString stringWithUTF8String:negativeButtonCallback]];
    }
    
    void _ShowThreeButton(const char *callbackKey, const char *title, const char *message, const char *firstButtonTitle, const char *secondButtonTitle, const char *thirdButtonTitle, const char *firstButtonCallback, const char *secondButtonCallback, const char *thirdButtonCallback)
    {
        [NativePopups showThreeButton:[NSString stringWithUTF8String:title] 
        addMessage:[NSString stringWithUTF8String:message] 
        addFirstButtonTitle:[NSString stringWithUTF8String:firstButtonTitle] 
        addSecondButtonTitle:[NSString stringWithUTF8String:secondButtonTitle] 
        addThirdButtonTitle:[NSString stringWithUTF8String:thirdButtonTitle]
        addCallbackKey:[NSString stringWithUTF8String:callbackKey]
        addFirstButtonCallback:[NSString stringWithUTF8String:firstButtonCallback]
        addSecondButtonCallback:[NSString stringWithUTF8String:secondButtonCallback]
        addThirdButtonCallback:[NSString stringWithUTF8String:thirdButtonCallback]];
    }
}
