#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.Purchasing.ConfigurationBuilder
struct ConfigurationBuilder_t1298400415;
// UnityEngine.Purchasing.IStoreController
struct IStoreController_t92554892;
// UnityEngine.Purchasing.IExtensionProvider
struct IExtensionProvider_t2460996543;
// System.Action
struct Action_t3226471752;
// System.Action`1<UnityEngine.Purchasing.InitializationFailureReason>
struct Action_1_t2755832024;
// System.Action`1<UnityEngine.Purchasing.PurchaseEventArgs>
struct Action_1_t349791816;
// System.Action`1<GameOfWhales.PurchaseFailedEventArgs>
struct Action_1_t4063725997;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.GowExampleStoreListener
struct  GowExampleStoreListener_t2120321040  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Purchasing.ConfigurationBuilder GameOfWhales.GowExampleStoreListener::_configurationBuilder
	ConfigurationBuilder_t1298400415 * ____configurationBuilder_2;
	// UnityEngine.Purchasing.IStoreController GameOfWhales.GowExampleStoreListener::_store
	Il2CppObject * ____store_3;
	// UnityEngine.Purchasing.IExtensionProvider GameOfWhales.GowExampleStoreListener::_storeExt
	Il2CppObject * ____storeExt_4;
	// System.Action GameOfWhales.GowExampleStoreListener::Initialized
	Action_t3226471752 * ___Initialized_5;
	// System.Action`1<UnityEngine.Purchasing.InitializationFailureReason> GameOfWhales.GowExampleStoreListener::InitializeFailed
	Action_1_t2755832024 * ___InitializeFailed_6;
	// System.Action`1<UnityEngine.Purchasing.PurchaseEventArgs> GameOfWhales.GowExampleStoreListener::PurchaseCompleted
	Action_1_t349791816 * ___PurchaseCompleted_7;
	// System.Action`1<GameOfWhales.PurchaseFailedEventArgs> GameOfWhales.GowExampleStoreListener::PurchaseFailed
	Action_1_t4063725997 * ___PurchaseFailed_8;

public:
	inline static int32_t get_offset_of__configurationBuilder_2() { return static_cast<int32_t>(offsetof(GowExampleStoreListener_t2120321040, ____configurationBuilder_2)); }
	inline ConfigurationBuilder_t1298400415 * get__configurationBuilder_2() const { return ____configurationBuilder_2; }
	inline ConfigurationBuilder_t1298400415 ** get_address_of__configurationBuilder_2() { return &____configurationBuilder_2; }
	inline void set__configurationBuilder_2(ConfigurationBuilder_t1298400415 * value)
	{
		____configurationBuilder_2 = value;
		Il2CppCodeGenWriteBarrier(&____configurationBuilder_2, value);
	}

	inline static int32_t get_offset_of__store_3() { return static_cast<int32_t>(offsetof(GowExampleStoreListener_t2120321040, ____store_3)); }
	inline Il2CppObject * get__store_3() const { return ____store_3; }
	inline Il2CppObject ** get_address_of__store_3() { return &____store_3; }
	inline void set__store_3(Il2CppObject * value)
	{
		____store_3 = value;
		Il2CppCodeGenWriteBarrier(&____store_3, value);
	}

	inline static int32_t get_offset_of__storeExt_4() { return static_cast<int32_t>(offsetof(GowExampleStoreListener_t2120321040, ____storeExt_4)); }
	inline Il2CppObject * get__storeExt_4() const { return ____storeExt_4; }
	inline Il2CppObject ** get_address_of__storeExt_4() { return &____storeExt_4; }
	inline void set__storeExt_4(Il2CppObject * value)
	{
		____storeExt_4 = value;
		Il2CppCodeGenWriteBarrier(&____storeExt_4, value);
	}

	inline static int32_t get_offset_of_Initialized_5() { return static_cast<int32_t>(offsetof(GowExampleStoreListener_t2120321040, ___Initialized_5)); }
	inline Action_t3226471752 * get_Initialized_5() const { return ___Initialized_5; }
	inline Action_t3226471752 ** get_address_of_Initialized_5() { return &___Initialized_5; }
	inline void set_Initialized_5(Action_t3226471752 * value)
	{
		___Initialized_5 = value;
		Il2CppCodeGenWriteBarrier(&___Initialized_5, value);
	}

	inline static int32_t get_offset_of_InitializeFailed_6() { return static_cast<int32_t>(offsetof(GowExampleStoreListener_t2120321040, ___InitializeFailed_6)); }
	inline Action_1_t2755832024 * get_InitializeFailed_6() const { return ___InitializeFailed_6; }
	inline Action_1_t2755832024 ** get_address_of_InitializeFailed_6() { return &___InitializeFailed_6; }
	inline void set_InitializeFailed_6(Action_1_t2755832024 * value)
	{
		___InitializeFailed_6 = value;
		Il2CppCodeGenWriteBarrier(&___InitializeFailed_6, value);
	}

	inline static int32_t get_offset_of_PurchaseCompleted_7() { return static_cast<int32_t>(offsetof(GowExampleStoreListener_t2120321040, ___PurchaseCompleted_7)); }
	inline Action_1_t349791816 * get_PurchaseCompleted_7() const { return ___PurchaseCompleted_7; }
	inline Action_1_t349791816 ** get_address_of_PurchaseCompleted_7() { return &___PurchaseCompleted_7; }
	inline void set_PurchaseCompleted_7(Action_1_t349791816 * value)
	{
		___PurchaseCompleted_7 = value;
		Il2CppCodeGenWriteBarrier(&___PurchaseCompleted_7, value);
	}

	inline static int32_t get_offset_of_PurchaseFailed_8() { return static_cast<int32_t>(offsetof(GowExampleStoreListener_t2120321040, ___PurchaseFailed_8)); }
	inline Action_1_t4063725997 * get_PurchaseFailed_8() const { return ___PurchaseFailed_8; }
	inline Action_1_t4063725997 ** get_address_of_PurchaseFailed_8() { return &___PurchaseFailed_8; }
	inline void set_PurchaseFailed_8(Action_1_t4063725997 * value)
	{
		___PurchaseFailed_8 = value;
		Il2CppCodeGenWriteBarrier(&___PurchaseFailed_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
