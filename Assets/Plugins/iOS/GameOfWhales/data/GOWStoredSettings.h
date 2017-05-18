#import "GOWDataNode.h"
#import "GOWDataStorage.h"

@interface GOWStoredSettings : NSObject

extern NSString* const GOW_SETTINGS_KEY;
extern NSString* const GAME_KEY;
extern NSString* const IDFA_KEY;
extern NSString* const SERVER_KEY;

+ (GOWDataNode*) getSettings;
+ (NSString*) getGameKey;
+ (void) setGameKey:(NSString*)gameKey;
+ (NSString*) getAdvertisingId;
+ (void) setAdvertisingId:(NSString*)advertisingId;
+ (NSString*) getServer;
+ (void) setServer:(NSString*)server;


@end
