
#import "GOWDefaultAlertDialog.h"
#import "GOWMessenger.h"
#import "GOWStoredSettings.h"
#import <AdSupport/ASIdentifierManager.h>
#import "GOWNotifications.h"
#import "GOWLogUtils.h"

void _gowShowDefaultDialog(const char * title, const char * message,  char * _Nullable buttonsOk, char * _Nullable buttonsCancel)
{
    GOWLog(@"buttonsOk = %s; buttonsCancel = %s", buttonsOk, buttonsCancel);
    if (buttonsOk == nil) {
        GOWLog(@"Cant show dialog without buttons");
        return;
    } else if (buttonsOk != nil && buttonsCancel == nil) {
        [GOWDefaultAlertDialog showDefaultDialog:[NSString stringWithUTF8String:title] message:[NSString stringWithUTF8String:message] okResponse:[NSString stringWithUTF8String:buttonsOk] cancelResponse:nil];
    } else {
        [GOWDefaultAlertDialog showDefaultDialog:[NSString stringWithUTF8String:title] message:[NSString stringWithUTF8String:message] okResponse:[NSString stringWithUTF8String:buttonsOk] cancelResponse:[NSString stringWithUTF8String:buttonsCancel]];
    }
}

void _gowRegisterForRemoteNotifications() {
    if( [NSClassFromString( @"GOWUnityIOSBridge" ) respondsToSelector:@selector(registerForRemoteNotification)] ) {
        GOWLog( @"GoW: register for remote notifications" );
        [NSClassFromString( @"GOWUnityIOSBridge" ) performSelector:@selector(registerForRemoteNotification)];
    }
    else
        GOWLog( @"GoW: Class 'GoWNotificationsAdditions' doesnt exist or respond" );
}

void _gowInit(const char * serverUrl, const char * gameKey, const char * gameId, const char * publicKey) {
    GOWLog(@"GOW.init : serverUrl=%s;gameKey=%s;gameId=%s;publicKey=%s;", serverUrl, gameKey, gameId, publicKey);
    [GOWStoredSettings setServer:[NSString stringWithUTF8String:serverUrl]];
    [GOWStoredSettings setGameKey:[NSString stringWithUTF8String:gameKey]];
    
    [GOWStoredSettings setAdvertisingId:[[[ASIdentifierManager sharedManager] advertisingIdentifier] UUIDString]];
}

void _gowRequestNotifications(BOOL * cleanAfter) {
    GOWLog(@"GOW.RequestNotifications : cleanAfter = %@", (cleanAfter) ? @"YES" : @"NO");
    [GoWMessenger sendCurrentNotification:[GOWNotifications current]];
    [GoWMessenger sendNotifications:[GOWNotifications all]];
}

void _gowRemoveNotification(const char * pushId) {
    GOWLog(@"Remove Notification: %s", pushId);
    [GOWNotifications removeBy:[NSString stringWithUTF8String:pushId]];
}

void _gowCancelNotification() {
    [GOWNotifications cancel];
}
