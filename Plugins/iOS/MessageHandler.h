#import <Foundation/Foundation.h>

typedef void (*MonoPMessageDelegate)(bool response);

static MonoPMessageDelegate _messageDelegate = NULL;

FOUNDATION_EXPORT void RegisterMessageHandler(MonoPMessageDelegate delegate)
{
    _messageDelegate = delegate;
}

void SendMessageToUnity(bool response) {
    dispatch_async(dispatch_get_main_queue(), ^{
        if(_messageDelegate != NULL) {
            _messageDelegate(response);
        }
    });
}