//
//  NSDictionary+GowExtention.h
//  gow
//
//  Created by Dmitry Burlakov on 26.09.16.
//  Copyright © 2016 GameOfWhales. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface NSDictionary (GowExtention)
+ (NSDictionary *)dictionaryWithJson:(NSString *)json;

- (NSString *)jsonStringWithPrettyPrint:(BOOL)prettyPrint;

- (NSData *)jsonData;
@end
