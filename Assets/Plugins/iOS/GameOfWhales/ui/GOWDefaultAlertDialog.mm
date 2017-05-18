#import "GOWDefaultAlertDialog.h"
#import "GOWMessenger.h"
#import "GOWLogUtils.h"

#define UIKitLocalizedString(key) [[NSBundle bundleWithIdentifier:@"com.apple.UIKit"] localizedStringForKey:key value:@"" table:nil]

@implementation GOWDefaultAlertDialog

+ (void) showDefaultDialog:(NSString*)title message:(NSString*)message okResponse:(NSString*)okResponse cancelResponse:(NSString*)cancelResponse
{
    UIAlertController* dialog = [UIAlertController alertControllerWithTitle:title message:message preferredStyle:UIAlertControllerStyleAlert];
    
    if ([okResponse length] > 0)
    {
        UIAlertAction* okAction = [UIAlertAction actionWithTitle:UIKitLocalizedString(@"Ok") style:UIAlertActionStyleDefault handler:^(UIAlertAction * action) {
            GOWLog(@"OK : %@", okResponse);
            [GoWMessenger sendDefaultDialogCallback:okResponse];
        }];
        
        [dialog addAction:okAction];
    }
    
    if ([cancelResponse length] > 0)
    {
        UIAlertAction* cancelAction = [UIAlertAction actionWithTitle:UIKitLocalizedString(@"Cancel") style:UIAlertActionStyleDefault handler:^(UIAlertAction * action) {
            GOWLog(@"CANCEL : %@", cancelResponse);
            [GoWMessenger sendDefaultDialogCallback:cancelResponse];
        }];
        
        [dialog addAction:cancelAction];
    }
    
    UIWindow *window = [[[UIApplication sharedApplication] delegate] window];
    UIViewController *controller = [window rootViewController];
    
    if ( controller.presentedViewController && !controller.presentedViewController.isBeingDismissed ) {
        controller = controller.presentedViewController;
    }
    
    [controller presentViewController:dialog animated:YES completion:nil];
}

@end
