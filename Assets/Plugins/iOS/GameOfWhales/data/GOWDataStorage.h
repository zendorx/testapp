#import "GOWDataNode.h"

@interface GOWDataStorage : NSObject

extern NSString* const GOW_DATA_KEY;
extern NSMutableDictionary<NSString *, NSString *>* appPreferences;
extern NSMutableDictionary<NSString *, GOWDataNode *>* children;

+ (GOWDataStorage*) sharedInstance;
+ (void) init;
+ (GOWDataNode*) nodeForKey:(NSString*)childKey create:(BOOL)create;
+ (void) removeNode:(NSString*)key;
+ (void) save;

@end
