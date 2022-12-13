#import <Foundation/Foundation.h>

typedef void (*MonoPMessageDelegate)(const NSString* callbackKey, bool success);

static MonoPMessageDelegate _messageDelegate = NULL;

FOUNDATION_EXPORT void RegisterMessageHandler(MonoPMessageDelegate delegate)
{
    _messageDelegate = delegate;
}

void SendMessageToUnity(const NSString* callbackKey, bool success) {
    dispatch_async(dispatch_get_main_queue(), ^{
        if(_messageDelegate != NULL) {
            _messageDelegate(callbackKey, success);
        }
    });
}
