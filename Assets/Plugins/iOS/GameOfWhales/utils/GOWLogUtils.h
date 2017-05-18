
@interface GOWLogUtils : NSObject
extern BOOL loggingEnabled;

#define __FILE_NAME__ [[[NSString stringWithUTF8String:__FILE__] lastPathComponent] UTF8String]

#if DEBUG

#define GOWLog( s, ... ) NSLog( @"%s:%d %s %@", \
__FILE_NAME__, \
__LINE__, \
__PRETTY_FUNCTION__, \
[NSString stringWithFormat:(s), ##__VA_ARGS__] )

#else

#define GOWLog( s, ... )

#endif

@end
