//
//  NSDate+GowExtention.h
//  gow
//
//  Created by Dmitry Burlakov on 26.09.16.
//  Copyright © 2016 GameOfWhales. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface NSDate (GowExtention)
- (BOOL)isLaterThanOrEqualTo:(NSDate *)date;

- (BOOL)isEarlierThanOrEqualTo:(NSDate *)date;

- (BOOL)isLaterThan:(NSDate *)date;

- (BOOL)isEarlierThan:(NSDate *)date;
@end
