#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// GameOfWhales.SpecialOffers/Definition
struct Definition_t3840865879;
// System.String
struct String_t;
// UnityEngine.Purchasing.Product
struct Product_t1203687971;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.SpecialOffers/Replacement
struct  Replacement_t2058140272  : public Il2CppObject
{
public:
	// GameOfWhales.SpecialOffers/Definition GameOfWhales.SpecialOffers/Replacement::definition
	Definition_t3840865879 * ___definition_0;
	// System.String GameOfWhales.SpecialOffers/Replacement::sku
	String_t* ___sku_1;
	// UnityEngine.Purchasing.Product GameOfWhales.SpecialOffers/Replacement::product
	Product_t1203687971 * ___product_2;
	// System.Single GameOfWhales.SpecialOffers/Replacement::price
	float ___price_3;
	// System.String GameOfWhales.SpecialOffers/Replacement::originalSku
	String_t* ___originalSku_4;
	// UnityEngine.Purchasing.Product GameOfWhales.SpecialOffers/Replacement::originalProduct
	Product_t1203687971 * ___originalProduct_5;
	// System.Single GameOfWhales.SpecialOffers/Replacement::originalPrice
	float ___originalPrice_6;

public:
	inline static int32_t get_offset_of_definition_0() { return static_cast<int32_t>(offsetof(Replacement_t2058140272, ___definition_0)); }
	inline Definition_t3840865879 * get_definition_0() const { return ___definition_0; }
	inline Definition_t3840865879 ** get_address_of_definition_0() { return &___definition_0; }
	inline void set_definition_0(Definition_t3840865879 * value)
	{
		___definition_0 = value;
		Il2CppCodeGenWriteBarrier(&___definition_0, value);
	}

	inline static int32_t get_offset_of_sku_1() { return static_cast<int32_t>(offsetof(Replacement_t2058140272, ___sku_1)); }
	inline String_t* get_sku_1() const { return ___sku_1; }
	inline String_t** get_address_of_sku_1() { return &___sku_1; }
	inline void set_sku_1(String_t* value)
	{
		___sku_1 = value;
		Il2CppCodeGenWriteBarrier(&___sku_1, value);
	}

	inline static int32_t get_offset_of_product_2() { return static_cast<int32_t>(offsetof(Replacement_t2058140272, ___product_2)); }
	inline Product_t1203687971 * get_product_2() const { return ___product_2; }
	inline Product_t1203687971 ** get_address_of_product_2() { return &___product_2; }
	inline void set_product_2(Product_t1203687971 * value)
	{
		___product_2 = value;
		Il2CppCodeGenWriteBarrier(&___product_2, value);
	}

	inline static int32_t get_offset_of_price_3() { return static_cast<int32_t>(offsetof(Replacement_t2058140272, ___price_3)); }
	inline float get_price_3() const { return ___price_3; }
	inline float* get_address_of_price_3() { return &___price_3; }
	inline void set_price_3(float value)
	{
		___price_3 = value;
	}

	inline static int32_t get_offset_of_originalSku_4() { return static_cast<int32_t>(offsetof(Replacement_t2058140272, ___originalSku_4)); }
	inline String_t* get_originalSku_4() const { return ___originalSku_4; }
	inline String_t** get_address_of_originalSku_4() { return &___originalSku_4; }
	inline void set_originalSku_4(String_t* value)
	{
		___originalSku_4 = value;
		Il2CppCodeGenWriteBarrier(&___originalSku_4, value);
	}

	inline static int32_t get_offset_of_originalProduct_5() { return static_cast<int32_t>(offsetof(Replacement_t2058140272, ___originalProduct_5)); }
	inline Product_t1203687971 * get_originalProduct_5() const { return ___originalProduct_5; }
	inline Product_t1203687971 ** get_address_of_originalProduct_5() { return &___originalProduct_5; }
	inline void set_originalProduct_5(Product_t1203687971 * value)
	{
		___originalProduct_5 = value;
		Il2CppCodeGenWriteBarrier(&___originalProduct_5, value);
	}

	inline static int32_t get_offset_of_originalPrice_6() { return static_cast<int32_t>(offsetof(Replacement_t2058140272, ___originalPrice_6)); }
	inline float get_originalPrice_6() const { return ___originalPrice_6; }
	inline float* get_address_of_originalPrice_6() { return &___originalPrice_6; }
	inline void set_originalPrice_6(float value)
	{
		___originalPrice_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
