//
//  NSDictionary+GowExtention.m
//  gow
//
//  Created by Dmitry Burlakov on 26.09.16.
//  Copyright © 2016 GameOfWhales. All rights reserved.
//

#import "NSDictionary+GowExtention.h"
#import "GOWLogUtils.h"

@implementation NSDictionary (GowExtention)

+ (NSDictionary *)dictionaryWithJson:(NSString *)string {
    NSError *error;
    NSData *objectData = [string dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *json = [NSJSONSerialization JSONObjectWithData:objectData options:NSJSONReadingMutableContainers error:&error];
    return (!json ? nil : json);
}

- (NSString *)jsonStringWithPrettyPrint:(BOOL)prettyPrint {
    NSError *error;
    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:self
                                                       options:(NSJSONWritingOptions) (prettyPrint ? NSJSONWritingPrettyPrinted : 0)
                                                         error:&error];

    if (!jsonData) {
        GOWLog(@"jsonStringWithPrettyPrint: error: %@", error.localizedDescription);
        return @"{}";
    } else {
        return [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
    }
}

- (NSData *)jsonData {
    NSError *error;
    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:self
                                                       options:NSJSONWritingPrettyPrinted
                                                         error:&error];

    if (error) {
        GOWLog(@"jsonStringWithPrettyPrint: error: %@", error.localizedDescription);
    }
    return jsonData;
}
@end
