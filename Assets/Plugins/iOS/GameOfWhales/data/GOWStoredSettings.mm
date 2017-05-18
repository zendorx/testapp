#import "GOWStoredSettings.h"

@implementation GOWStoredSettings

NSString* const GOW_SETTINGS_KEY = @"settings";
NSString* const GAME_KEY = @"gow_key";
NSString* const IDFA_KEY = @"advertisingID";
NSString* const SERVER_KEY = @"server";

+ (GOWDataNode*) getSettings
{
    [GOWDataStorage init];
    return [GOWDataStorage nodeForKey:GOW_SETTINGS_KEY create:true];
}

+ (NSString*) getGameKey
{
    return [[self getSettings] stringForKey:GAME_KEY];
}

+ (void) setGameKey:(NSString*)gameKey
{
    [[self getSettings] set:gameKey forKey:GAME_KEY];
    [GOWDataStorage save];
}

+ (NSString*) getAdvertisingId
{
    return [[self getSettings] stringForKey:IDFA_KEY];
}

+ (void) setAdvertisingId:(NSString*)advertisingId
{
    [[self getSettings] set:advertisingId forKey:IDFA_KEY];
    [GOWDataStorage save];
}

+ (NSString*) getServer
{
    return [[self getSettings] stringForKey:SERVER_KEY];
}

+ (void) setServer:(NSString*)server
{
    [[self getSettings] set:server forKey:SERVER_KEY];
    [GOWDataStorage save];
}

@end
