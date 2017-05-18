#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_EventArgs3289624707.h"
#include "AssemblyU2DCSharpU2Dfirstpass_GameOfWhales_Purchas4238957100.h"

// UnityEngine.Purchasing.Product
struct Product_t1203687971;
// GameOfWhales.SpecialOffers/Replacement
struct Replacement_t2058140272;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.PurchaseCompletedEventArgs
struct  PurchaseCompletedEventArgs_t2175953647  : public EventArgs_t3289624707
{
public:
	// UnityEngine.Purchasing.Product GameOfWhales.PurchaseCompletedEventArgs::product
	Product_t1203687971 * ___product_1;
	// GameOfWhales.PurchaseCheckingState GameOfWhales.PurchaseCompletedEventArgs::checkingState
	int32_t ___checkingState_2;
	// GameOfWhales.SpecialOffers/Replacement GameOfWhales.PurchaseCompletedEventArgs::replacement
	Replacement_t2058140272 * ___replacement_3;
	// System.String GameOfWhales.PurchaseCompletedEventArgs::soPayload
	String_t* ___soPayload_4;
	// System.String GameOfWhales.PurchaseCompletedEventArgs::originReceipt
	String_t* ___originReceipt_5;

public:
	inline static int32_t get_offset_of_product_1() { return static_cast<int32_t>(offsetof(PurchaseCompletedEventArgs_t2175953647, ___product_1)); }
	inline Product_t1203687971 * get_product_1() const { return ___product_1; }
	inline Product_t1203687971 ** get_address_of_product_1() { return &___product_1; }
	inline void set_product_1(Product_t1203687971 * value)
	{
		___product_1 = value;
		Il2CppCodeGenWriteBarrier(&___product_1, value);
	}

	inline static int32_t get_offset_of_checkingState_2() { return static_cast<int32_t>(offsetof(PurchaseCompletedEventArgs_t2175953647, ___checkingState_2)); }
	inline int32_t get_checkingState_2() const { return ___checkingState_2; }
	inline int32_t* get_address_of_checkingState_2() { return &___checkingState_2; }
	inline void set_checkingState_2(int32_t value)
	{
		___checkingState_2 = value;
	}

	inline static int32_t get_offset_of_replacement_3() { return static_cast<int32_t>(offsetof(PurchaseCompletedEventArgs_t2175953647, ___replacement_3)); }
	inline Replacement_t2058140272 * get_replacement_3() const { return ___replacement_3; }
	inline Replacement_t2058140272 ** get_address_of_replacement_3() { return &___replacement_3; }
	inline void set_replacement_3(Replacement_t2058140272 * value)
	{
		___replacement_3 = value;
		Il2CppCodeGenWriteBarrier(&___replacement_3, value);
	}

	inline static int32_t get_offset_of_soPayload_4() { return static_cast<int32_t>(offsetof(PurchaseCompletedEventArgs_t2175953647, ___soPayload_4)); }
	inline String_t* get_soPayload_4() const { return ___soPayload_4; }
	inline String_t** get_address_of_soPayload_4() { return &___soPayload_4; }
	inline void set_soPayload_4(String_t* value)
	{
		___soPayload_4 = value;
		Il2CppCodeGenWriteBarrier(&___soPayload_4, value);
	}

	inline static int32_t get_offset_of_originReceipt_5() { return static_cast<int32_t>(offsetof(PurchaseCompletedEventArgs_t2175953647, ___originReceipt_5)); }
	inline String_t* get_originReceipt_5() const { return ___originReceipt_5; }
	inline String_t** get_address_of_originReceipt_5() { return &___originReceipt_5; }
	inline void set_originReceipt_5(String_t* value)
	{
		___originReceipt_5 = value;
		Il2CppCodeGenWriteBarrier(&___originReceipt_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
