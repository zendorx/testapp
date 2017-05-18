//
//  GWClient.m
//  gow
//
//  Created by Dmitry Burlakov on 26.09.16.
//  Copyright © 2016 GameOfWhales. All rights reserved.
//

#import "GWClient.h"
#import "NSDictionary+GowExtention.h"
#import "GOWStoredSettings.h"
#import "GOWLogUtils.h"

//NSString * const SERVER_ADDRESS = @"http://liara.gameofwhales.com:8080";
//NSString *const SERVER_ADDRESS = @"http://localhost:8080";

@implementation GWClient


+ (id)clientWithGameKey:(nonnull NSString *)gameKey playerId:(nonnull NSString *)playerId {
    return [[GWClient alloc] initWithGameKey:gameKey playerId:playerId];
}

- (id)initWithGameKey:(nonnull NSString *)gameKey playerId:(nonnull NSString *)playerId {
    if (self = [super init]) {
        self.gameKey = gameKey;
        self.playerId = playerId;
    }
    return self;
}

- (void)postCommand:(nonnull NSString *)command withArgs:(nullable NSDictionary *)commandArgs completion:(nullable JsonObjectBlock)completion {

    if (!commandArgs) {
        commandArgs = [NSDictionary dictionary];
    }
    
    NSMutableDictionary *args = [commandArgs mutableCopy];
    
    args[@"game"] = [self.gameKey description];
    args[@"user"] = [self.playerId description];
    
    NSString *data = [args jsonStringWithPrettyPrint:false];

    GOWLog(@"postCommand %@ %@", command, data);

    NSURL *url = [NSURL URLWithString:[NSString stringWithFormat:@"%@/%@", [GOWStoredSettings getServer], command]];

    NSMutableURLRequest *request = [NSMutableURLRequest requestWithURL:url];
    [request setHTTPMethod:@"POST"];
    [request setValue:@"application/json" forHTTPHeaderField:@"Content-type"];
    [request setValue:[NSString stringWithFormat:@"%lu", (unsigned long)[data length]] forHTTPHeaderField:@"Content-length"];

    [request setHTTPBody:[data dataUsingEncoding:NSUTF8StringEncoding]];

    NSURLSession *session = [NSURLSession sharedSession];
    NSURLSessionDataTask *task = [session dataTaskWithRequest:request
                                            completionHandler:
                                                    ^(NSData *data, NSURLResponse *response, NSError *error) {
                                                        if (error){
                                                            GOWLog(@"GOW:XCODE:Client:%@/%@\r\n/%@\r\nERROR:%@", [GOWStoredSettings getServer], command, [args jsonStringWithPrettyPrint:false], error);
                                                            completion(error, nil);
                                                        } else {
                                                            NSError *serializationError;
                                                            NSMutableDictionary * json = [NSJSONSerialization
                                                                                          JSONObjectWithData:data options:kNilOptions error:&serializationError
                                                                                          ];
                                                            GOWLog(@"GOW:XCODE:Client:%@/%@\r\n/%@\r\nRESPONSE:%@", [GOWStoredSettings getServer], command, [args jsonStringWithPrettyPrint:false], json);
                                                            completion(error, json);
                                                        }
                                                    }];

    [task resume];
}

- (void)loginWithTimezone:(nonnull NSTimeZone *)timezone
                  version:(nonnull NSString *)version
               completion:(nullable JsonObjectBlock)completion {

    NSMutableDictionary *args = [NSMutableDictionary dictionary];
    args[@"game"] = self.gameKey;
    args[@"user"] = self.playerId;
    args[@"timezone"] = [timezone abbreviation];
    args[@"version"] = version;
    args[@"platform"] = @"ios";
    [self postCommand:@"sdk.login" withArgs:args completion:completion];
}

- (void)logoutWithPlayTime:(NSTimeInterval)seconds completion:(nullable JsonObjectBlock)completion {
    NSMutableDictionary *args = [NSMutableDictionary dictionary];
    args[@"game"] = self.gameKey;
    args[@"user"] = self.playerId;
    args[@"seconds"] = @(seconds);
    [self postCommand:@"sdk.logout" withArgs:args completion:completion];
}

- (void)tokenWithDeviceToken:(nonnull NSString *)deviceToken completion:(nullable JsonObjectBlock)completion {
    NSMutableDictionary *args = [NSMutableDictionary dictionary];
    args[@"game"] = self.gameKey;
    args[@"user"] = self.playerId;
    args[@"token"] = deviceToken;
    [self postCommand:@"sdk.token" withArgs:args completion:completion];
}

- (void)receiptWithCurrency:(nonnull NSString *)currency price:(nonnull NSNumber *)price transactionId:(nonnull NSString *)transactionId receipt:(nonnull NSString *)receipt specialOffer:(nonnull NSString *)specialOffer originalSku:(nonnull NSString *)originalSku completion:(nullable JsonObjectBlock)completion {
    NSMutableDictionary *args = [NSMutableDictionary dictionary];
    args[@"game"] = self.gameKey;
    args[@"user"] = self.playerId;
    args[@"currency"] = currency;
    args[@"price"] = price;
    args[@"receipt"] = receipt;
    args[@"transactionId"] = transactionId;
    if (specialOffer) {
        args[@"so"] = specialOffer;
        args[@"originalSku"] = originalSku;
    }
    [self postCommand:@"sdk.receipt" withArgs:args completion:completion];
}

@end
