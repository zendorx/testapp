
typedef void (^ OkDelegate)();
typedef void (^ CancelDelegate)();

@interface GOWDefaultAlertDialog : NSObject

+ (void) showDefaultDialog:(NSString*)title message:(NSString*)message okResponse:(NSString*)okResponse cancelResponse:(NSString*)cancelResponse;

@end
