//
//  NSDate+GowExtention.m
//  gow
//
//  Created by Dmitry Burlakov on 26.09.16.
//  Copyright © 2016 GameOfWhales. All rights reserved.
//

#import "NSDate+GowExtention.h"

@implementation NSDate (GowExtention)

- (BOOL)isLaterThanOrEqualTo:(NSDate *)date {
    return !([self compare:date] == NSOrderedAscending);
}

- (BOOL)isEarlierThanOrEqualTo:(NSDate *)date {
    return !([self compare:date] == NSOrderedDescending);
}

- (BOOL)isLaterThan:(NSDate *)date {
    return ([self compare:date] == NSOrderedDescending);

}

- (BOOL)isEarlierThan:(NSDate *)date {
    return ([self compare:date] == NSOrderedAscending);
}

@end
