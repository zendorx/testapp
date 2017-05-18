#import "GWClient.h"

@interface GWClient(UnityPlugin)

- (void) pushSuccess:(NSString*)pushID completition:(JsonObjectBlock)completition;

- (void) pushReacted:(NSString*)pushID completition:(JsonObjectBlock)completition;

@end
