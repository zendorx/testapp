#import <Foundation/Foundation.h>
#include "AppDelegateListener.h"

@interface GOWUnityIOSBridge : NSObject<AppDelegateListener>

+ (GOWUnityIOSBridge*)sharedInstance;

+ (void)registerForRemoteNotification;

+ (void)unitySend:(const char *)methodName param:(const char *)param;

+ (NSString*)checkFirebaseToken;

@end
