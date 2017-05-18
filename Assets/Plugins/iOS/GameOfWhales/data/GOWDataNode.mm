#import "GOWDataNode.h"
#import "UnityAppController.h"
#import "NSDictionary+GowExtention.h"
#import "GOWLogUtils.h"

@implementation GOWDataNode {
    NSString *_nodeKey;
    NSMutableDictionary *jsonDictionary;
    NSMutableDictionary<NSString *, GOWDataNode *> *children;
}

+ (GOWDataNode*)init:(NSString*)key
{
    return [GOWDataNode init:key jsonString:nil];
}

+ (GOWDataNode*)init:(NSString*)key jsonString:(NSString*)jsonString
{
    GOWDataNode *node = [[GOWDataNode alloc] init];
    if (node) {
        node->_nodeKey = key;
        node->children = [[NSMutableDictionary alloc] init];
        if ([jsonString length] > 0) {
            node->jsonDictionary = [[NSDictionary dictionaryWithJson:jsonString] mutableCopy];
        } else {
            node->jsonDictionary = [[NSMutableDictionary alloc] init];
        }
    }
    GOWLog(@"\n\nNode %@ loaded: %@ (json:%@) isValid:%@\n\n", node->_nodeKey, node->jsonDictionary, jsonString, ([node isValid]) ? @"YES" : @"NO");
    return node;
}

- (GOWDataNode*)nodeForKey:(NSString*)childKey create:(BOOL*)create
{
    if ([children objectForKey:childKey]) {
        return [children objectForKey:childKey];
    }
    
    GOWDataNode *child = nil;
    
    if ([jsonDictionary objectForKey:childKey] != nil) {
        child = [GOWDataNode init:childKey jsonString:[((NSDictionary*) [jsonDictionary objectForKey:childKey]) jsonStringWithPrettyPrint:YES]];
    } else {
        if (create) {
            child = [GOWDataNode init:childKey];
        }
    }
    
    if (child && [child isValid]) {
        [children setValue:child forKey:childKey];
    }
    
    return child;
}

- (BOOL)isValid
{
    return jsonDictionary != nil;
}

- (NSString*)nodeKey
{
    return _nodeKey;
}

- (NSDictionary*)dictionary
{
    return jsonDictionary;
}

- (NSString*)stringForKey:(NSString*)key
{
    if ([self isValid] && [jsonDictionary objectForKey:key]) {
        return [jsonDictionary objectForKey:key];
    }
    
    return nil;
}

- (NSData*)jsonForKey:(NSString*)key
{
    if ([self isValid] && [jsonDictionary objectForKey:key]) {
        return [jsonDictionary objectForKey:key];
    }
    
    return nil;
}

- (id)objectForKey:(NSString*)key
{
    return [jsonDictionary objectForKey:key];
}

- (void)set:(id)value forKey:(NSString*)key
{
    [jsonDictionary setValue:value forKey:key];
    GOWLog(@"Node %@ set %@ with key %@ and result is %@", _nodeKey, value, key, jsonDictionary);
}

- (void)remove:(NSString*)key
{
    [jsonDictionary removeObjectForKey:key];
}

- (void)save
{
    for (NSString* key in children) {
        GOWDataNode* child = [children objectForKey:key];
        [child save];
        [jsonDictionary setObject:[child dictionary] forKey:key];
    }
    GOWLog(@"\n\nNode %@ saved: %@", _nodeKey, jsonDictionary);
}

@end
