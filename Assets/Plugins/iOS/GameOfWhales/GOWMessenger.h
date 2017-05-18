
@interface GoWMessenger : NSObject

+ (void) sendPushMessage;

+ (void) sendDefaultDialogCallback:(NSString*)response;

+ (void) sendToken:(NSString*)token;

+ (void) sendCurrentNotification:(NSDictionary*)notification;

+ (void) sendNotifications:(NSArray<NSDictionary*>*)notifications;

@end
