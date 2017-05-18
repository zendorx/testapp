//
//  GWClient.h
//  gow
//
//  Created by Dmitry Burlakov on 26.09.16.
//  Copyright © 2016 GameOfWhales. All rights reserved.
//

#import <Foundation/Foundation.h>

typedef void (^JsonObjectBlock)(NSError *error, NSDictionary *json);

@interface GWClient : NSObject {
    NSString *gameKey;
}

@property(nonatomic, copy) NSString *gameKey;
@property(nonatomic, copy) NSString *playerId;

+ (id)clientWithGameKey:(nonnull NSString *)gameKey
               playerId:(nonnull NSString *)playerId;

- (void)postCommand:(nonnull NSString *)command withArgs:(nullable NSDictionary *)args completion:(nullable JsonObjectBlock)completion;

- (id)initWithGameKey:(nonnull NSString *)gameKey
             playerId:(nonnull NSString *)playerId;

- (void)loginWithTimezone:(nonnull NSTimeZone *)timezone
                  version:(nonnull NSString *)version
               completion:(nullable JsonObjectBlock)completion;

- (void)logoutWithPlayTime:(NSTimeInterval)seconds
                completion:(nullable JsonObjectBlock)completion;

- (void)tokenWithDeviceToken:(nonnull NSString *)deviceToken
                  completion:(nullable JsonObjectBlock)completion;

- (void)receiptWithCurrency:(nonnull NSString *)currency
                      price:(nonnull NSNumber *)price
              transactionId:(nonnull NSString *)transactionId
                    receipt:(nonnull NSString *)receipt
               specialOffer:(nonnull NSString *)specialOffer
                originalSku:(nonnull NSString *)originalSku
                 completion:(nullable JsonObjectBlock)completion;
@end

#pragma clang diagnostic pop
