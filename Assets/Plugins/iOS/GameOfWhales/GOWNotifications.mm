#import "GOWNotifications.h"
#import "GOWDataStorage.h"
#import "GOWStoredSettings.h"
#import "GWClient+GOWUnityExtension.h"
#import "GOWMessenger.h"
#import "GOWLogUtils.h"

@implementation GOWNotifications

NSString* const NOTIFICATIONS_KEY = @"key_notifications";
NSString* const NOTIFICATIONS_LIST_KEY = @"key_notifications_list";
NSString* const NOTIFICATIONS_CURRENT_KEY = @"key_current_notification";
NSString* const NOTIFICATIONS_RECEIVED_KEY = @"key_received_notification";

NSString* const PUSH_ID_KEY = @"pushID";
NSString* const NOTIFICATION_ID_KEY = @"notificationID";
NSString* const NOTIFICATION_IMAGE_KEY = @"gow_img";

+ (GOWDataNode*) notificationsNode
{
    [GOWDataStorage init];
    return [GOWDataStorage nodeForKey:NOTIFICATIONS_KEY create:YES];
}

+ (void) recieved:(NSDictionary*)notificationData
{
    NSString* pushID = nil;
    if ([notificationData objectForKey:PUSH_ID_KEY] != nil) {
        pushID = [notificationData objectForKey:PUSH_ID_KEY];
        if (pushID && pushID.length > 0) {
            GWClient *client = [GWClient clientWithGameKey:[GOWStoredSettings getGameKey] playerId:[GOWStoredSettings getAdvertisingId]];
            void (^completition)(NSError*, NSDictionary*) = ^(NSError *error, NSDictionary *response) {
                if (error) {
                    GOWLog(@"GOW:XCODE:GOWNotifications:recieved:GWClient:pushSuccess:error:%@", error);
                }
                if (response) {
                    GOWLog(@"GOW:XCODE:GOWNotifications:recieved:GWClient:pushSuccess:response:%@", response);
                }
            };
            [client pushSuccess:pushID completition:completition];

            [self add:notificationData];
        }
    }
}

+ (void) clicked:(NSDictionary*)notificationData
{
    NSString *pushID = [notificationData objectForKey:PUSH_ID_KEY];
    if ([pushID length] != 0) {
        GWClient *client = [GWClient clientWithGameKey:[GOWStoredSettings getGameKey] playerId:[GOWStoredSettings getAdvertisingId]];
        void (^completition)(NSError*, NSDictionary*) = ^(NSError *error, NSDictionary *response) {
            if (error) {
                GOWLog(@"GOW:XCODE:GOWNotifications:recieved:GWClient:pushReacted:error:%@", error);
            }
            if (response) {
                GOWLog(@"GOW:XCODE:GOWNotifications:recieved:GWClient:pushReacted:response:%@", response);
            }
        };
        [client pushReacted:pushID completition:completition];
        [self removeBy:pushID];
        [self setCurrent:notificationData];
    }
}
+ (NSDictionary*) notificationsFor:(NSString*)pushID
{
    NSDictionary *current = [self current];
    if ([current objectForKey:PUSH_ID_KEY] != nil && [current objectForKey:PUSH_ID_KEY] == pushID) {
        return current;
    } else {
        NSDictionary *pushes = [[self notificationsNode] objectForKey:NOTIFICATIONS_LIST_KEY];
        return [pushes objectForKey:pushID];
    }
}

+ (void) add:(NSDictionary*)notificationData
{
    NSString *pushID = [notificationData objectForKey:PUSH_ID_KEY];
    NSMutableDictionary *pushes = [[[self notificationsNode] objectForKey:NOTIFICATIONS_LIST_KEY] mutableCopy];
    
    if (pushes == nil) {
        pushes = [[NSMutableDictionary alloc] init];
    }
    
    [pushes setValue:notificationData forKey:pushID];
    
    [[self notificationsNode] set:pushes forKey:NOTIFICATIONS_LIST_KEY];
    
    
    NSMutableArray *receivedPushes =[[[self notificationsNode] objectForKey:NOTIFICATIONS_RECEIVED_KEY] mutableCopy];
    
    if (receivedPushes == nil) {
        receivedPushes = [[NSMutableArray alloc] init];
    }
    
    if (![receivedPushes containsObject:pushID]) {
        [receivedPushes addObject:pushID];
    }
    
    [[self notificationsNode] set:receivedPushes forKey:NOTIFICATIONS_RECEIVED_KEY];
    
    [GOWDataStorage save];
}

+ (void) removeBy:(NSString*)pushID
{
    NSMutableArray *receivedPushes =[[[self notificationsNode] objectForKey:NOTIFICATIONS_RECEIVED_KEY] mutableCopy];
    
    if (receivedPushes == nil) {
        receivedPushes = [[NSMutableArray alloc] init];
    }
    
    bool contains = false;
    
    if ([receivedPushes containsObject:pushID]) {
        contains = true;
    }
    
    if (contains) {
        [receivedPushes removeObject:pushID];
    }
    
    NSDictionary *current = [self current];
    if ([current objectForKey:PUSH_ID_KEY] != nil && [[current objectForKey:PUSH_ID_KEY] isEqualToString:pushID]) {
        [self removeCurrent];
    } else {
        NSMutableDictionary *pushes = [[[self notificationsNode] objectForKey:NOTIFICATIONS_LIST_KEY] mutableCopy];
        if (pushes == nil) {
            pushes = [[NSMutableDictionary alloc] init];
        }
        if ([pushes objectForKey:pushID] != nil) {
            [pushes removeObjectForKey:pushID];
        }
        
        GOWLog(@"\n\n NOTIFICATIONS_LIST_KEY :\n%@", pushes);
        
        [[self notificationsNode] set:pushes forKey:NOTIFICATIONS_LIST_KEY];
    }
    [GOWDataStorage save];
}

+ (void) setCurrent:(NSDictionary*)notificationData
{
    [[self notificationsNode] set:notificationData forKey:NOTIFICATIONS_CURRENT_KEY];

    [GOWDataStorage save];
}

+ (void) removeCurrent
{
    [[self notificationsNode] remove:NOTIFICATIONS_CURRENT_KEY];

    [GOWDataStorage save];
}
+ (NSDictionary*) current
{
    return [self current:NO];
}

+ (NSDictionary*) current:(BOOL)cleanAfter
{
    NSDictionary *current = [[[self notificationsNode] objectForKey:NOTIFICATIONS_CURRENT_KEY] copy];
    if (cleanAfter) {
        [self removeCurrent];
    }
    return current;
}

+ (NSArray<NSDictionary*>*) all
{
    NSMutableArray<NSDictionary*> *allNotifications = [[NSMutableArray alloc] init];
    
    NSDictionary *pushes = [[self notificationsNode] objectForKey:NOTIFICATIONS_LIST_KEY];
    for (NSDictionary* notification : [pushes allValues]) {
        [allNotifications addObject:notification];
    }
    
    return allNotifications;
}
//+ (void) clean;
+ (void) cancel
{
    [UIApplication sharedApplication].applicationIconBadgeNumber = MAX([UIApplication sharedApplication].applicationIconBadgeNumber - 1, 0);
}

+ (void) resolveNotification:(NSDictionary*)notification
{
    if ([self alreadyResolved:notification deleteAfter:YES]) {
        GOWLog(@"Already resolved : %@", notification);
    } else {
        if ([[UIApplication sharedApplication] applicationState] == UIApplicationStateActive) {
            [GoWMessenger sendCurrentNotification:[GOWNotifications current]];
            [GoWMessenger sendNotifications:[GOWNotifications all]];
            [self alreadyResolved:notification deleteAfter:YES];
        } else if ([[UIApplication sharedApplication] applicationState] == UIApplicationStateInactive) {
            GOWLog(@"\nClicked notification = %@", notification);
            [GOWNotifications clicked:notification];
        }
    }
    [GOWDataStorage save];
    
}

+ (BOOL) alreadyResolved:(NSDictionary*)notification deleteAfter:(BOOL)deleteAfter
{
    NSString *pushID = [notification objectForKey:PUSH_ID_KEY];
    
    NSMutableArray *receivedPushes =[[[self notificationsNode] objectForKey:NOTIFICATIONS_RECEIVED_KEY] mutableCopy];
    
    if (receivedPushes == nil) {
        receivedPushes = [[NSMutableArray alloc] init];
    }
    
    bool contains = false;
    
    if ([receivedPushes containsObject:pushID]) {
        contains = true;
    }
    
    if (contains) {
        NSMutableDictionary *pushes = [[[self notificationsNode] objectForKey:NOTIFICATIONS_LIST_KEY] mutableCopy];
        if (pushes == nil) {
            pushes = [[NSMutableDictionary alloc] init];
        }
        
        if ([pushes objectForKey:pushID] != nil) {
            contains = false;
        }
    }
    
    if (contains && deleteAfter) {
        [receivedPushes removeObject:pushID];
        [[self notificationsNode] set:receivedPushes forKey:NOTIFICATIONS_RECEIVED_KEY];
        [GOWDataStorage save];
    }

    return contains;
}

@end
