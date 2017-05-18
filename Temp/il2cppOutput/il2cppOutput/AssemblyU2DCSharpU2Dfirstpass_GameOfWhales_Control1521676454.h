#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// GameOfWhales.Controller
struct Controller_t1521676454;
// System.Action`1<UnityEngine.Purchasing.InitializationFailureReason>
struct Action_1_t2755832024;
// System.Action`1<GameOfWhales.PurchaseFailedEventArgs>
struct Action_1_t4063725997;
// System.Action
struct Action_t3226471752;
// System.Action`1<GameOfWhales.PurchaseCompletedEventArgs>
struct Action_1_t1977753029;
// System.Action`1<GameOfWhales.ReplacementEventArgs>
struct Action_1_t2987281605;
// System.Action`1<GameOfWhales.DefinitionEventArgs>
struct Action_1_t3277373282;
// System.Action`2<GameOfWhales.GowNotification[],System.Action`1<GameOfWhales.GowNotification>>
struct Action_2_t2503511010;
// System.Action`2<GameOfWhales.GowNotification,System.Action`1<GameOfWhales.GowNotification>>
struct Action_2_t1004845231;
// System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>
struct List_1_t1311596400;
// GameOfWhales.SpecialOffers
struct SpecialOffers_t365073028;
// GameOfWhales.Client
struct Client_t2240167957;
// GameOfWhales.DeviceInfo
struct DeviceInfo_t3954376236;
// UnityEngine.Purchasing.IStoreController
struct IStoreController_t92554892;
// UnityEngine.Purchasing.IExtensionProvider
struct IExtensionProvider_t2460996543;
// System.Collections.Generic.HashSet`1<System.String>
struct HashSet_1_t362681087;
// UnityEngine.Purchasing.ProductDefinition[]
struct ProductDefinitionU5BU5D_t113193325;
// GameOfWhales.CompoundStoreListener
struct CompoundStoreListener_t3385788606;
// UnityEngine.Purchasing.ConfigurationBuilder
struct ConfigurationBuilder_t1298400415;
// System.Func`2<GameOfWhales.GowNotification,System.Boolean>
struct Func_2_t2239710315;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.Controller
struct  Controller_t1521676454  : public MonoBehaviour_t1158329972
{
public:
	// System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition> GameOfWhales.Controller::_definitions
	List_1_t1311596400 * ____definitions_11;
	// GameOfWhales.SpecialOffers GameOfWhales.Controller::_specialOffers
	SpecialOffers_t365073028 * ____specialOffers_12;
	// GameOfWhales.Client GameOfWhales.Controller::_client
	Client_t2240167957 * ____client_13;
	// GameOfWhales.DeviceInfo GameOfWhales.Controller::_device
	DeviceInfo_t3954376236 * ____device_14;
	// UnityEngine.Purchasing.IStoreController GameOfWhales.Controller::_store
	Il2CppObject * ____store_15;
	// UnityEngine.Purchasing.IExtensionProvider GameOfWhales.Controller::_storeExt
	Il2CppObject * ____storeExt_16;
	// System.Collections.Generic.HashSet`1<System.String> GameOfWhales.Controller::_segments
	HashSet_1_t362681087 * ____segments_17;
	// UnityEngine.Purchasing.ProductDefinition[] GameOfWhales.Controller::_productDefs
	ProductDefinitionU5BU5D_t113193325* ____productDefs_18;
	// System.Action GameOfWhales.Controller::_applicationQuit
	Action_t3226471752 * ____applicationQuit_19;
	// GameOfWhales.CompoundStoreListener GameOfWhales.Controller::_compoundStoreListener
	CompoundStoreListener_t3385788606 * ____compoundStoreListener_20;
	// UnityEngine.Purchasing.ConfigurationBuilder GameOfWhales.Controller::_configurationBuilder
	ConfigurationBuilder_t1298400415 * ____configurationBuilder_21;
	// System.Boolean GameOfWhales.Controller::<isReady>k__BackingField
	bool ___U3CisReadyU3Ek__BackingField_22;
	// System.Boolean GameOfWhales.Controller::<isLogged>k__BackingField
	bool ___U3CisLoggedU3Ek__BackingField_23;
	// System.Boolean GameOfWhales.Controller::<nowLogging>k__BackingField
	bool ___U3CnowLoggingU3Ek__BackingField_24;

public:
	inline static int32_t get_offset_of__definitions_11() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ____definitions_11)); }
	inline List_1_t1311596400 * get__definitions_11() const { return ____definitions_11; }
	inline List_1_t1311596400 ** get_address_of__definitions_11() { return &____definitions_11; }
	inline void set__definitions_11(List_1_t1311596400 * value)
	{
		____definitions_11 = value;
		Il2CppCodeGenWriteBarrier(&____definitions_11, value);
	}

	inline static int32_t get_offset_of__specialOffers_12() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ____specialOffers_12)); }
	inline SpecialOffers_t365073028 * get__specialOffers_12() const { return ____specialOffers_12; }
	inline SpecialOffers_t365073028 ** get_address_of__specialOffers_12() { return &____specialOffers_12; }
	inline void set__specialOffers_12(SpecialOffers_t365073028 * value)
	{
		____specialOffers_12 = value;
		Il2CppCodeGenWriteBarrier(&____specialOffers_12, value);
	}

	inline static int32_t get_offset_of__client_13() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ____client_13)); }
	inline Client_t2240167957 * get__client_13() const { return ____client_13; }
	inline Client_t2240167957 ** get_address_of__client_13() { return &____client_13; }
	inline void set__client_13(Client_t2240167957 * value)
	{
		____client_13 = value;
		Il2CppCodeGenWriteBarrier(&____client_13, value);
	}

	inline static int32_t get_offset_of__device_14() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ____device_14)); }
	inline DeviceInfo_t3954376236 * get__device_14() const { return ____device_14; }
	inline DeviceInfo_t3954376236 ** get_address_of__device_14() { return &____device_14; }
	inline void set__device_14(DeviceInfo_t3954376236 * value)
	{
		____device_14 = value;
		Il2CppCodeGenWriteBarrier(&____device_14, value);
	}

	inline static int32_t get_offset_of__store_15() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ____store_15)); }
	inline Il2CppObject * get__store_15() const { return ____store_15; }
	inline Il2CppObject ** get_address_of__store_15() { return &____store_15; }
	inline void set__store_15(Il2CppObject * value)
	{
		____store_15 = value;
		Il2CppCodeGenWriteBarrier(&____store_15, value);
	}

	inline static int32_t get_offset_of__storeExt_16() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ____storeExt_16)); }
	inline Il2CppObject * get__storeExt_16() const { return ____storeExt_16; }
	inline Il2CppObject ** get_address_of__storeExt_16() { return &____storeExt_16; }
	inline void set__storeExt_16(Il2CppObject * value)
	{
		____storeExt_16 = value;
		Il2CppCodeGenWriteBarrier(&____storeExt_16, value);
	}

	inline static int32_t get_offset_of__segments_17() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ____segments_17)); }
	inline HashSet_1_t362681087 * get__segments_17() const { return ____segments_17; }
	inline HashSet_1_t362681087 ** get_address_of__segments_17() { return &____segments_17; }
	inline void set__segments_17(HashSet_1_t362681087 * value)
	{
		____segments_17 = value;
		Il2CppCodeGenWriteBarrier(&____segments_17, value);
	}

	inline static int32_t get_offset_of__productDefs_18() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ____productDefs_18)); }
	inline ProductDefinitionU5BU5D_t113193325* get__productDefs_18() const { return ____productDefs_18; }
	inline ProductDefinitionU5BU5D_t113193325** get_address_of__productDefs_18() { return &____productDefs_18; }
	inline void set__productDefs_18(ProductDefinitionU5BU5D_t113193325* value)
	{
		____productDefs_18 = value;
		Il2CppCodeGenWriteBarrier(&____productDefs_18, value);
	}

	inline static int32_t get_offset_of__applicationQuit_19() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ____applicationQuit_19)); }
	inline Action_t3226471752 * get__applicationQuit_19() const { return ____applicationQuit_19; }
	inline Action_t3226471752 ** get_address_of__applicationQuit_19() { return &____applicationQuit_19; }
	inline void set__applicationQuit_19(Action_t3226471752 * value)
	{
		____applicationQuit_19 = value;
		Il2CppCodeGenWriteBarrier(&____applicationQuit_19, value);
	}

	inline static int32_t get_offset_of__compoundStoreListener_20() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ____compoundStoreListener_20)); }
	inline CompoundStoreListener_t3385788606 * get__compoundStoreListener_20() const { return ____compoundStoreListener_20; }
	inline CompoundStoreListener_t3385788606 ** get_address_of__compoundStoreListener_20() { return &____compoundStoreListener_20; }
	inline void set__compoundStoreListener_20(CompoundStoreListener_t3385788606 * value)
	{
		____compoundStoreListener_20 = value;
		Il2CppCodeGenWriteBarrier(&____compoundStoreListener_20, value);
	}

	inline static int32_t get_offset_of__configurationBuilder_21() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ____configurationBuilder_21)); }
	inline ConfigurationBuilder_t1298400415 * get__configurationBuilder_21() const { return ____configurationBuilder_21; }
	inline ConfigurationBuilder_t1298400415 ** get_address_of__configurationBuilder_21() { return &____configurationBuilder_21; }
	inline void set__configurationBuilder_21(ConfigurationBuilder_t1298400415 * value)
	{
		____configurationBuilder_21 = value;
		Il2CppCodeGenWriteBarrier(&____configurationBuilder_21, value);
	}

	inline static int32_t get_offset_of_U3CisReadyU3Ek__BackingField_22() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ___U3CisReadyU3Ek__BackingField_22)); }
	inline bool get_U3CisReadyU3Ek__BackingField_22() const { return ___U3CisReadyU3Ek__BackingField_22; }
	inline bool* get_address_of_U3CisReadyU3Ek__BackingField_22() { return &___U3CisReadyU3Ek__BackingField_22; }
	inline void set_U3CisReadyU3Ek__BackingField_22(bool value)
	{
		___U3CisReadyU3Ek__BackingField_22 = value;
	}

	inline static int32_t get_offset_of_U3CisLoggedU3Ek__BackingField_23() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ___U3CisLoggedU3Ek__BackingField_23)); }
	inline bool get_U3CisLoggedU3Ek__BackingField_23() const { return ___U3CisLoggedU3Ek__BackingField_23; }
	inline bool* get_address_of_U3CisLoggedU3Ek__BackingField_23() { return &___U3CisLoggedU3Ek__BackingField_23; }
	inline void set_U3CisLoggedU3Ek__BackingField_23(bool value)
	{
		___U3CisLoggedU3Ek__BackingField_23 = value;
	}

	inline static int32_t get_offset_of_U3CnowLoggingU3Ek__BackingField_24() { return static_cast<int32_t>(offsetof(Controller_t1521676454, ___U3CnowLoggingU3Ek__BackingField_24)); }
	inline bool get_U3CnowLoggingU3Ek__BackingField_24() const { return ___U3CnowLoggingU3Ek__BackingField_24; }
	inline bool* get_address_of_U3CnowLoggingU3Ek__BackingField_24() { return &___U3CnowLoggingU3Ek__BackingField_24; }
	inline void set_U3CnowLoggingU3Ek__BackingField_24(bool value)
	{
		___U3CnowLoggingU3Ek__BackingField_24 = value;
	}
};

struct Controller_t1521676454_StaticFields
{
public:
	// GameOfWhales.Controller GameOfWhales.Controller::_instance
	Controller_t1521676454 * ____instance_2;
	// System.Action`1<UnityEngine.Purchasing.InitializationFailureReason> GameOfWhales.Controller::InitializeFailed
	Action_1_t2755832024 * ___InitializeFailed_3;
	// System.Action`1<GameOfWhales.PurchaseFailedEventArgs> GameOfWhales.Controller::PurchaseFailed
	Action_1_t4063725997 * ___PurchaseFailed_4;
	// System.Action GameOfWhales.Controller::Initialized
	Action_t3226471752 * ___Initialized_5;
	// System.Action`1<GameOfWhales.PurchaseCompletedEventArgs> GameOfWhales.Controller::PurchaseCompleted
	Action_1_t1977753029 * ___PurchaseCompleted_6;
	// System.Action`1<GameOfWhales.ReplacementEventArgs> GameOfWhales.Controller::ReplacementObsolete
	Action_1_t2987281605 * ___ReplacementObsolete_7;
	// System.Action`1<GameOfWhales.DefinitionEventArgs> GameOfWhales.Controller::DefinitionObsolete
	Action_1_t3277373282 * ___DefinitionObsolete_8;
	// System.Action`2<GameOfWhales.GowNotification[],System.Action`1<GameOfWhales.GowNotification>> GameOfWhales.Controller::NotificationsRecieved
	Action_2_t2503511010 * ___NotificationsRecieved_9;
	// System.Action`2<GameOfWhales.GowNotification,System.Action`1<GameOfWhales.GowNotification>> GameOfWhales.Controller::CurrentNotificationRecieved
	Action_2_t1004845231 * ___CurrentNotificationRecieved_10;
	// System.Func`2<GameOfWhales.GowNotification,System.Boolean> GameOfWhales.Controller::<>f__am$cache0
	Func_2_t2239710315 * ___U3CU3Ef__amU24cache0_25;

public:
	inline static int32_t get_offset_of__instance_2() { return static_cast<int32_t>(offsetof(Controller_t1521676454_StaticFields, ____instance_2)); }
	inline Controller_t1521676454 * get__instance_2() const { return ____instance_2; }
	inline Controller_t1521676454 ** get_address_of__instance_2() { return &____instance_2; }
	inline void set__instance_2(Controller_t1521676454 * value)
	{
		____instance_2 = value;
		Il2CppCodeGenWriteBarrier(&____instance_2, value);
	}

	inline static int32_t get_offset_of_InitializeFailed_3() { return static_cast<int32_t>(offsetof(Controller_t1521676454_StaticFields, ___InitializeFailed_3)); }
	inline Action_1_t2755832024 * get_InitializeFailed_3() const { return ___InitializeFailed_3; }
	inline Action_1_t2755832024 ** get_address_of_InitializeFailed_3() { return &___InitializeFailed_3; }
	inline void set_InitializeFailed_3(Action_1_t2755832024 * value)
	{
		___InitializeFailed_3 = value;
		Il2CppCodeGenWriteBarrier(&___InitializeFailed_3, value);
	}

	inline static int32_t get_offset_of_PurchaseFailed_4() { return static_cast<int32_t>(offsetof(Controller_t1521676454_StaticFields, ___PurchaseFailed_4)); }
	inline Action_1_t4063725997 * get_PurchaseFailed_4() const { return ___PurchaseFailed_4; }
	inline Action_1_t4063725997 ** get_address_of_PurchaseFailed_4() { return &___PurchaseFailed_4; }
	inline void set_PurchaseFailed_4(Action_1_t4063725997 * value)
	{
		___PurchaseFailed_4 = value;
		Il2CppCodeGenWriteBarrier(&___PurchaseFailed_4, value);
	}

	inline static int32_t get_offset_of_Initialized_5() { return static_cast<int32_t>(offsetof(Controller_t1521676454_StaticFields, ___Initialized_5)); }
	inline Action_t3226471752 * get_Initialized_5() const { return ___Initialized_5; }
	inline Action_t3226471752 ** get_address_of_Initialized_5() { return &___Initialized_5; }
	inline void set_Initialized_5(Action_t3226471752 * value)
	{
		___Initialized_5 = value;
		Il2CppCodeGenWriteBarrier(&___Initialized_5, value);
	}

	inline static int32_t get_offset_of_PurchaseCompleted_6() { return static_cast<int32_t>(offsetof(Controller_t1521676454_StaticFields, ___PurchaseCompleted_6)); }
	inline Action_1_t1977753029 * get_PurchaseCompleted_6() const { return ___PurchaseCompleted_6; }
	inline Action_1_t1977753029 ** get_address_of_PurchaseCompleted_6() { return &___PurchaseCompleted_6; }
	inline void set_PurchaseCompleted_6(Action_1_t1977753029 * value)
	{
		___PurchaseCompleted_6 = value;
		Il2CppCodeGenWriteBarrier(&___PurchaseCompleted_6, value);
	}

	inline static int32_t get_offset_of_ReplacementObsolete_7() { return static_cast<int32_t>(offsetof(Controller_t1521676454_StaticFields, ___ReplacementObsolete_7)); }
	inline Action_1_t2987281605 * get_ReplacementObsolete_7() const { return ___ReplacementObsolete_7; }
	inline Action_1_t2987281605 ** get_address_of_ReplacementObsolete_7() { return &___ReplacementObsolete_7; }
	inline void set_ReplacementObsolete_7(Action_1_t2987281605 * value)
	{
		___ReplacementObsolete_7 = value;
		Il2CppCodeGenWriteBarrier(&___ReplacementObsolete_7, value);
	}

	inline static int32_t get_offset_of_DefinitionObsolete_8() { return static_cast<int32_t>(offsetof(Controller_t1521676454_StaticFields, ___DefinitionObsolete_8)); }
	inline Action_1_t3277373282 * get_DefinitionObsolete_8() const { return ___DefinitionObsolete_8; }
	inline Action_1_t3277373282 ** get_address_of_DefinitionObsolete_8() { return &___DefinitionObsolete_8; }
	inline void set_DefinitionObsolete_8(Action_1_t3277373282 * value)
	{
		___DefinitionObsolete_8 = value;
		Il2CppCodeGenWriteBarrier(&___DefinitionObsolete_8, value);
	}

	inline static int32_t get_offset_of_NotificationsRecieved_9() { return static_cast<int32_t>(offsetof(Controller_t1521676454_StaticFields, ___NotificationsRecieved_9)); }
	inline Action_2_t2503511010 * get_NotificationsRecieved_9() const { return ___NotificationsRecieved_9; }
	inline Action_2_t2503511010 ** get_address_of_NotificationsRecieved_9() { return &___NotificationsRecieved_9; }
	inline void set_NotificationsRecieved_9(Action_2_t2503511010 * value)
	{
		___NotificationsRecieved_9 = value;
		Il2CppCodeGenWriteBarrier(&___NotificationsRecieved_9, value);
	}

	inline static int32_t get_offset_of_CurrentNotificationRecieved_10() { return static_cast<int32_t>(offsetof(Controller_t1521676454_StaticFields, ___CurrentNotificationRecieved_10)); }
	inline Action_2_t1004845231 * get_CurrentNotificationRecieved_10() const { return ___CurrentNotificationRecieved_10; }
	inline Action_2_t1004845231 ** get_address_of_CurrentNotificationRecieved_10() { return &___CurrentNotificationRecieved_10; }
	inline void set_CurrentNotificationRecieved_10(Action_2_t1004845231 * value)
	{
		___CurrentNotificationRecieved_10 = value;
		Il2CppCodeGenWriteBarrier(&___CurrentNotificationRecieved_10, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_25() { return static_cast<int32_t>(offsetof(Controller_t1521676454_StaticFields, ___U3CU3Ef__amU24cache0_25)); }
	inline Func_2_t2239710315 * get_U3CU3Ef__amU24cache0_25() const { return ___U3CU3Ef__amU24cache0_25; }
	inline Func_2_t2239710315 ** get_address_of_U3CU3Ef__amU24cache0_25() { return &___U3CU3Ef__amU24cache0_25; }
	inline void set_U3CU3Ef__amU24cache0_25(Func_2_t2239710315 * value)
	{
		___U3CU3Ef__amU24cache0_25 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
