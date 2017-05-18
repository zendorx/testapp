#import "GOWDataStorage.h"
#import "NSDictionary+GowExtention.h"
#import "GOWLogUtils.h"

@implementation GOWDataStorage

NSString* const GOW_DATA_KEY = @"gow_data";
NSMutableDictionary<NSString *, NSString *>* appPreferences;
NSMutableDictionary<NSString *, GOWDataNode *>* children;

+ (GOWDataStorage*) sharedInstance
{
    static GOWDataStorage *sharedInstance;
    static dispatch_once_t onceToken;
    dispatch_once( &onceToken, ^{
        sharedInstance = [[self alloc] init];
    });
    
    return sharedInstance;
}

+ (void) init
{
    if (appPreferences == nil) {
        NSUserDefaults *preferences = [NSUserDefaults standardUserDefaults];
        
        GOWLog(@"prefeences:dictionary:%@", [preferences dictionaryRepresentation]);
        
        appPreferences = [[preferences dictionaryForKey:GOW_DATA_KEY] mutableCopy];
        
        if (appPreferences == nil) {
            appPreferences = [[NSMutableDictionary alloc] init];
        }
    }
    
    if (children == nil) {
        children = [[NSMutableDictionary alloc] init];
    }
}

+ (GOWDataNode*) nodeForKey:(NSString*)childKey create:(BOOL)create;
{
    if (children == nil || appPreferences == nil) {
        GOWLog(@"GOW : DataStorage not inited");
        return nil;
    }
    
    if ([children objectForKey:childKey] != nil) {
        return [children objectForKey:childKey];
    }
    if (create) {
        return [self createDataNode:childKey];
    }
    return nil;
}

+ (GOWDataNode*) createDataNode:(NSString*)key
{
    NSString* nodeJsonString = [[NSString alloc] init];
    if ([appPreferences objectForKey:key] != nil) {
        nodeJsonString = [appPreferences objectForKey:key];
    }
    GOWDataNode *child = [GOWDataNode init:key jsonString:nodeJsonString];
    if ([child isValid]) {
        [children setValue:child forKey:key];
    }
    return child;
}

+ (void) removeNode:(NSString*)key
{
    if (children == nil || appPreferences == nil) {
        GOWLog(@"GOW : DataStorage not inited");
        return;
    }
    if([children objectForKey:key]) {
        [children removeObjectForKey:key];
    }
}

+ (void) save {
    if (children == nil || appPreferences == nil) {
        GOWLog(@"GOW : DataStorage not inited");
        return;
    }
    
    for (GOWDataNode *child in [children allValues]) {
        [child save];
        
        GOWLog(@"save:appPreferences:child:%@:%@", [child nodeKey], [child dictionary]);
        
        [appPreferences setObject:[[NSString alloc] initWithData:[[child dictionary] jsonData] encoding:NSUTF8StringEncoding] forKey:[child nodeKey]];
    }
    
    GOWLog(@"save:appPreferences:%@", appPreferences);
    
    NSUserDefaults *preferences = [NSUserDefaults standardUserDefaults];
    
    [preferences setObject:appPreferences forKey:GOW_DATA_KEY];
    
    [preferences synchronize];
    
    GOWLog(@"save:prefeences:dictionary:%@", [preferences dictionaryRepresentation]);
}

@end
