
@interface GOWNotifications : NSObject

extern NSString* const NOTIFICATIONS_KEY;
extern NSString* const NOTIFICATIONS_LIST_KEY;
extern NSString* const NOTIFICATIONS_CURRENT_KEY;

extern NSString* const PUSH_ID_KEY;
extern NSString* const NOTIFICATION_ID_KEY;
extern NSString* const NOTIFICATION_IMAGE_KEY;

+ (void) recieved:(NSDictionary*)notificationData;
+ (void) clicked:(NSDictionary*)notificationData;
+ (NSDictionary*) notificationsFor:(NSString*)pushID;
+ (void) add:(NSDictionary*)notificationData;
+ (void) removeBy:(NSString*)pushID;
+ (void) setCurrent:(NSDictionary*)notificationData;
+ (void) removeCurrent;
+ (NSDictionary*) current;
+ (NSDictionary*) current:(BOOL)cleanAfter;
+ (NSArray<NSDictionary*>*) all;
//+ (void) clean;
+ (void) cancel;
+ (void) resolveNotification:(NSDictionary*)notification;
+ (BOOL) alreadyResolved:(NSDictionary*)notification deleteAfter:(BOOL)deleteAfter;

@end
