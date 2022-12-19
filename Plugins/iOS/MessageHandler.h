#import <Foundation/Foundation.h>

typedef void (*MonoPMessageDelegate)(const NSString* key, const NSString* data);

static MonoPMessageDelegate _messageDelegate = NULL;

FOUNDATION_EXPORT void RegisterMessageHandler(MonoPMessageDelegate messageDelegate)
{
    _messageDelegate = messageDelegate;
}

void SendMessageToUnity(const NSString* key, const NSString* data) {
    dispatch_async(dispatch_get_main_queue(), ^{
        if(_messageDelegate != NULL) {
            _messageDelegate(key, data);
        }
    });
}