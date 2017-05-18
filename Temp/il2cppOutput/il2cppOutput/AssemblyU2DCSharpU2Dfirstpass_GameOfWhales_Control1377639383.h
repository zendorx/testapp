#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityEngine.Purchasing.PurchaseEventArgs
struct PurchaseEventArgs_t547992434;
// UnityEngine.Purchasing.Product
struct Product_t1203687971;
// GameOfWhales.SpecialOffers/Replacement
struct Replacement_t2058140272;
// GameOfWhales.Controller
struct Controller_t1521676454;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.Controller/<UnityEngine_Purchasing_IStoreListener_ProcessPurchase>c__AnonStorey6
struct  U3CUnityEngine_Purchasing_IStoreListener_ProcessPurchaseU3Ec__AnonStorey6_t1377639383  : public Il2CppObject
{
public:
	// UnityEngine.Purchasing.PurchaseEventArgs GameOfWhales.Controller/<UnityEngine_Purchasing_IStoreListener_ProcessPurchase>c__AnonStorey6::e
	PurchaseEventArgs_t547992434 * ___e_0;
	// UnityEngine.Purchasing.Product GameOfWhales.Controller/<UnityEngine_Purchasing_IStoreListener_ProcessPurchase>c__AnonStorey6::product
	Product_t1203687971 * ___product_1;
	// GameOfWhales.SpecialOffers/Replacement GameOfWhales.Controller/<UnityEngine_Purchasing_IStoreListener_ProcessPurchase>c__AnonStorey6::rep
	Replacement_t2058140272 * ___rep_2;
	// GameOfWhales.Controller GameOfWhales.Controller/<UnityEngine_Purchasing_IStoreListener_ProcessPurchase>c__AnonStorey6::$this
	Controller_t1521676454 * ___U24this_3;

public:
	inline static int32_t get_offset_of_e_0() { return static_cast<int32_t>(offsetof(U3CUnityEngine_Purchasing_IStoreListener_ProcessPurchaseU3Ec__AnonStorey6_t1377639383, ___e_0)); }
	inline PurchaseEventArgs_t547992434 * get_e_0() const { return ___e_0; }
	inline PurchaseEventArgs_t547992434 ** get_address_of_e_0() { return &___e_0; }
	inline void set_e_0(PurchaseEventArgs_t547992434 * value)
	{
		___e_0 = value;
		Il2CppCodeGenWriteBarrier(&___e_0, value);
	}

	inline static int32_t get_offset_of_product_1() { return static_cast<int32_t>(offsetof(U3CUnityEngine_Purchasing_IStoreListener_ProcessPurchaseU3Ec__AnonStorey6_t1377639383, ___product_1)); }
	inline Product_t1203687971 * get_product_1() const { return ___product_1; }
	inline Product_t1203687971 ** get_address_of_product_1() { return &___product_1; }
	inline void set_product_1(Product_t1203687971 * value)
	{
		___product_1 = value;
		Il2CppCodeGenWriteBarrier(&___product_1, value);
	}

	inline static int32_t get_offset_of_rep_2() { return static_cast<int32_t>(offsetof(U3CUnityEngine_Purchasing_IStoreListener_ProcessPurchaseU3Ec__AnonStorey6_t1377639383, ___rep_2)); }
	inline Replacement_t2058140272 * get_rep_2() const { return ___rep_2; }
	inline Replacement_t2058140272 ** get_address_of_rep_2() { return &___rep_2; }
	inline void set_rep_2(Replacement_t2058140272 * value)
	{
		___rep_2 = value;
		Il2CppCodeGenWriteBarrier(&___rep_2, value);
	}

	inline static int32_t get_offset_of_U24this_3() { return static_cast<int32_t>(offsetof(U3CUnityEngine_Purchasing_IStoreListener_ProcessPurchaseU3Ec__AnonStorey6_t1377639383, ___U24this_3)); }
	inline Controller_t1521676454 * get_U24this_3() const { return ___U24this_3; }
	inline Controller_t1521676454 ** get_address_of_U24this_3() { return &___U24this_3; }
	inline void set_U24this_3(Controller_t1521676454 * value)
	{
		___U24this_3 = value;
		Il2CppCodeGenWriteBarrier(&___U24this_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
