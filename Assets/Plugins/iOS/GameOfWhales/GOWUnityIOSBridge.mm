#import "GOWUnityIOSBridge.h"
#import "UnityAppController.h"
#import <UserNotifications/UserNotifications.h>
#import "GOWMessenger.h"
#import "GOWNotifications.h"
#import "GOWLogUtils.h"

//@import Firebase;
#import "Firebase.h"

void UnitySendMessage( const char * className, const char * methodName, const char * param );

@implementation GOWUnityIOSBridge

+ (void)load
{
    GOWLog(@"GOW:XCODE: load");
    UnityRegisterAppDelegateListener( [self sharedInstance] );
    
    [[NSNotificationCenter defaultCenter] addObserver:[self sharedInstance]
                                             selector:@selector(applicationDidFinishLaunchingNotification:)
                                                 name:UIApplicationDidFinishLaunchingNotification object:nil];
    
}

+ (GOWUnityIOSBridge*)sharedInstance
{
    static GOWUnityIOSBridge *sharedInstance;
    static dispatch_once_t onceToken;
    dispatch_once( &onceToken, ^{
        sharedInstance = [[self alloc] init];
    });
    
    GOWLog(@"GOW: Shared instance: %@", sharedInstance);
    
    return sharedInstance;
}

+ (void)unitySend:(const char *)methodName param:(const char*)param
{
    UnitySendMessage("GameOfWhales", methodName, param);
}

- (void)applicationDidFinishLaunchingNotification:(NSNotification*)note
{
    if( note.userInfo )
    {
        NSDictionary *remoteNotificationDictionary = [note.userInfo objectForKey:UIApplicationLaunchOptionsRemoteNotificationKey];
        if( remoteNotificationDictionary )
        {
            GOWLog( @"launched with remote notification: %@", remoteNotificationDictionary );
            double delayInSeconds = 5.0;
            dispatch_time_t popTime = dispatch_time( DISPATCH_TIME_NOW, (int64_t)(delayInSeconds * NSEC_PER_SEC) );
            dispatch_after( popTime, dispatch_get_main_queue(), ^
                           {
                               [self processNotification:remoteNotificationDictionary isLaunchNotification:YES];
                           });
        }
    }
}

- (void)didFinishLaunching:(NSNotification*)notification
{
    GOWLog(@"GOW:Plugin Started 2: %@", [notification userInfo]);
    
    [[NSNotificationCenter defaultCenter] addObserver:self selector:@selector(onTokenRefresh)name:kFIRInstanceIDTokenRefreshNotification object:nil];

    [FIRApp configure];
}

- (void)processNotification:(NSDictionary*)dict isLaunchNotification:(BOOL)isLaunchNotification
{
    GOWLog(@"handleNotification");
}

- (void)didRegisterForRemoteNotificationsWithDeviceToken:(NSNotification*)notification
{
    GOWLog(@"Something %@", [notification userInfo]);
    
    [GOWUnityIOSBridge checkFirebaseToken];
}

- (void)didFailToRegisterForRemoteNotificationsWithError:(NSNotification*)notification
{
    NSError *error = (NSError*)notification.userInfo;
    GOWLog( @"didFailToRegisterForRemoteNotificationsWithError. Error : %@", error );
    UnitySendMessage( "GameOfWhales", "OnTokenRegisterFailed", error.localizedDescription.UTF8String );
}

//For interactive notification only
- (void)application:(UIApplication *)application handleActionWithIdentifier:(NSString *)identifier forRemoteNotification:(NSDictionary *)userInfo completionHandler:(void(^)())completionHandler
{
    //handle the actions
    if ([identifier isEqualToString:@"declineAction"]){
    }
    else if ([identifier isEqualToString:@"answerAction"]){
    }
}

+ (void) registerForRemoteNotification
{
    UIUserNotificationType allNotificationTypes =
        (UIUserNotificationTypeSound | UIUserNotificationTypeAlert | UIUserNotificationTypeBadge);
    UIUserNotificationSettings *settings =
        [UIUserNotificationSettings settingsForTypes:allNotificationTypes categories:nil];
    GOWLog(@"registerForRemoteNotification : Register for remote notifications settings %@", settings);
    [[UIApplication sharedApplication] registerUserNotificationSettings:settings];
}

- (void)onTokenRefresh {
    [GOWUnityIOSBridge checkFirebaseToken];
}

+ (NSString*)checkFirebaseToken
{
    NSString *fcmToken = [[FIRInstanceID instanceID] token];
    
    GOWLog(@"GOW:XCODE:checkFirebaseToken:Token=%@", fcmToken);
    
    if ([fcmToken length] != 0) {
        [GoWMessenger sendToken:fcmToken];
        return fcmToken;
    }
    
    return nil;
}

- (void)didReceiveRemoteNotification:(NSNotification*)notification
{
    GOWLog(@"didReceiveRemoteNotification 2 : received notifications = %@", notification);
}

@end

@interface UnityAppController(GoW)
@end

@implementation UnityAppController(GoW)

- (void)applicationWillFinishLaunching:(NSNotification *)notification
{
    GOWLog(@"applicationWillFinishLaunching");
}

- (void)applicationDidEnterBackground:(UIApplication*)application
{
    
}

- (void)application:(UIApplication*)application didRegisterUserNotificationSettings:(UIUserNotificationSettings*)notificationSettings
{
    [[UIApplication sharedApplication] registerForRemoteNotifications];
}

- (void)application:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)userInfo fetchCompletionHandler:(void (^)(UIBackgroundFetchResult result))handler
{
    GOWLog(@"didReceiveRemoteNotification : received notifications = %@", userInfo);
    
    NSDictionary *saved = [GOWNotifications notificationsFor:[userInfo objectForKey:PUSH_ID_KEY]];
    
    if (saved == nil && ![GOWNotifications alreadyResolved:userInfo deleteAfter:NO]) {
        GOWLog(@"\nReceived notification = %@", userInfo);
        [GOWNotifications recieved:userInfo];
    }
    
    [GOWNotifications resolveNotification:userInfo];
    
    if (handler)
    {
        handler(UIBackgroundFetchResultNoData);
    }
}

// Receive displayed notifications for iOS 10 devices.
#if defined(__IPHONE_10_0) && __IPHONE_OS_VERSION_MAX_ALLOWED >= __IPHONE_10_0
- (void)userNotificationCenter:(UNUserNotificationCenter *)center
       willPresentNotification:(UNNotification *)notification
         withCompletionHandler:(void (^)(UNNotificationPresentationOptions))completionHandler {
    // Print message ID.
    NSDictionary *userInfo = notification.request.content.userInfo;
    GOWLog(@"Message ID: %@", userInfo[@"gcm.message_id"]);
    
    // Print full message.
    GOWLog(@"%@", userInfo);
}
#endif

@end
