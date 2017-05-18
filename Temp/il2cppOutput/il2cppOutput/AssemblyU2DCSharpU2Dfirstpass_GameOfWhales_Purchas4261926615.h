#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_EventArgs3289624707.h"
#include "UnityEngine_Purchasing_UnityEngine_Purchasing_Purc1322959839.h"

// UnityEngine.Purchasing.Product
struct Product_t1203687971;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.PurchaseFailedEventArgs
struct  PurchaseFailedEventArgs_t4261926615  : public EventArgs_t3289624707
{
public:
	// UnityEngine.Purchasing.Product GameOfWhales.PurchaseFailedEventArgs::product
	Product_t1203687971 * ___product_1;
	// UnityEngine.Purchasing.PurchaseFailureReason GameOfWhales.PurchaseFailedEventArgs::reason
	int32_t ___reason_2;

public:
	inline static int32_t get_offset_of_product_1() { return static_cast<int32_t>(offsetof(PurchaseFailedEventArgs_t4261926615, ___product_1)); }
	inline Product_t1203687971 * get_product_1() const { return ___product_1; }
	inline Product_t1203687971 ** get_address_of_product_1() { return &___product_1; }
	inline void set_product_1(Product_t1203687971 * value)
	{
		___product_1 = value;
		Il2CppCodeGenWriteBarrier(&___product_1, value);
	}

	inline static int32_t get_offset_of_reason_2() { return static_cast<int32_t>(offsetof(PurchaseFailedEventArgs_t4261926615, ___reason_2)); }
	inline int32_t get_reason_2() const { return ___reason_2; }
	inline int32_t* get_address_of_reason_2() { return &___reason_2; }
	inline void set_reason_2(int32_t value)
	{
		___reason_2 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
