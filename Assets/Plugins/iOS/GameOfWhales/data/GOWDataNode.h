
@interface GOWDataNode : NSObject

+ (GOWDataNode*)init:(NSString*)key;
+ (GOWDataNode*)init:(NSString*)key jsonString:(NSString*)jsonString;
- (GOWDataNode*)nodeForKey:(NSString*)childKey create:(BOOL*)create;
- (BOOL)isValid;
- (NSString*)nodeKey;
- (NSDictionary*)dictionary;
- (NSString*)stringForKey:(NSString*)key;
- (id)objectForKey:(NSString*)key;
- (NSData*)jsonForKey:(NSString*)key;
- (void)set:(id)value forKey:(NSString*)key;
- (void)remove:(NSString*)key;
- (void)save;

@end
