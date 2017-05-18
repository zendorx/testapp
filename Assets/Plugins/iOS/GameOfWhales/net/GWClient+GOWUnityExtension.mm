#import "GWClient+GOWUnityExtension.h"

@implementation GWClient(UnityPlugin)

- (void) pushSuccess:(NSString*)pushID completition:(JsonObjectBlock)completition
{
    [self push:pushID success:YES reacted:NO completition:completition];
}

- (void) pushReacted:(NSString*)pushID completition:(JsonObjectBlock)completition
{
    [self push:pushID success:NO reacted:YES completition:completition];
}

- (void) push:(NSString*)pushID success:(BOOL)success reacted:(BOOL)reacted completition:(JsonObjectBlock)completition
{
    NSMutableDictionary *args = [NSMutableDictionary dictionary];
    args[@"game"] = self.gameKey;
    args[@"user"] = self.playerId;
    if (success) {
        args[@"delivered"] = [NSArray arrayWithObjects:pushID, nil];
    } else {
        args[@"delivered"] = [NSArray array];
    }
    if (reacted) {
        args[@"reacted"] = [NSArray arrayWithObjects:pushID, nil];
    } else {
        args[@"reacted"] = [NSArray array];
    }
    [self postCommand:@"sdk.push" withArgs:args completion:completition];
}

@end
