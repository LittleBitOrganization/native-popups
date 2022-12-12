/* MessageHandler.mm */
#import <Foundation/Foundation.h>

// Объявляем новый тип для делегата, эквивалентный объявленному в Unity
typedef void (*MonoPMessageDelegate)(const char* message, const char* data);

// Создаем статическую ссылку на делегат.
// В больших проектах эту ссылку лучше хранить в каком-нибудь классе
static MonoPMessageDelegate _messageDelegate = NULL;

// Реализуем функцию регистрации, которую вызываем из Unity
FOUNDATION_EXPORT void RegisterMessageHandler(MonoPMessageDelegate delegate)
{
    _messageDelegate = delegate;
}

// Пишем какую-нибудь функцию, которая будет отправлять сообщения в Unity,
// используя статический делегат
void SendMessageToUnity(const char* message, const char* data) {
    dispatch_async(dispatch_get_main_queue(), ^{
        if(_messageDelegate != NULL) {
            _messageDelegate(message, data);
        }
    });
}