    #import "GoWMessenger.h"
#import "UnityAppController.h"
#import "GOWUnityIOSBridge.h"
#import "NSDictionary+GowExtention.h"
#import "GOWNotifications.h"
#import "GOWLogUtils.h"

@implementation GoWMessenger

+ (void) sendPushMessage
{
    GOWLog(@"sendPushMessage");
}

+ (void) sendDefaultDialogCallback:(NSString*)response
{
    NSMutableDictionary *jsonDictionary = [[NSMutableDictionary alloc] init];
    [jsonDictionary setObject:response forKey:@"response"];
    NSString *jsonResponse = [self getResponse:jsonDictionary];
    GOWLog(@"DefaultDialogCallback : %@", jsonResponse);
    [GOWUnityIOSBridge unitySend:"DefaultDialogCallback" param:[jsonResponse UTF8String]];
}

+ (void) sendToken:(NSString*)token
{
    [GOWUnityIOSBridge unitySend:"OnTokenRegistered" param:[token UTF8String]];
}

+ (NSString*) getResponse:(NSDictionary*)response
{
    NSError *jsonError;
    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:response options:NSJSONWritingPrettyPrinted error:&jsonError];
    return [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
}

+ (void) sendCurrentNotification:(NSDictionary*)notification
{
    if (notification != nil) {
        NSMutableDictionary *jsonDictionary = [[NSMutableDictionary alloc] init];
        [jsonDictionary setObject:notification forKey:@"currentPushMessage"];
        NSString *jsonResponse = [jsonDictionary jsonStringWithPrettyPrint:YES];
        GOWLog(@"OnCurrentPushMessage : %@", jsonResponse);
        [GOWUnityIOSBridge unitySend:"OnCurrentPushMessage" param:[jsonResponse UTF8String]];
    }
}

+ (void) sendNotifications:(NSArray<NSDictionary*>*)notifications
{
    NSMutableDictionary *jsonDictionary = [[NSMutableDictionary alloc] init];
    [jsonDictionary setObject:notifications forKey:@"notifications"];
    NSString *jsonResponse = [jsonDictionary jsonStringWithPrettyPrint:YES];
    GOWLog(@"OnPushMessages : %@", jsonResponse);
    [GOWUnityIOSBridge unitySend:"OnPushMessages" param:[jsonResponse UTF8String]];
}

@end
