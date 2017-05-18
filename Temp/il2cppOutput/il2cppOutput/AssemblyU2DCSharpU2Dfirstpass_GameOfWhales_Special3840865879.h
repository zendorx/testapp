#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_DateTime693205669.h"

// System.String
struct String_t;
// System.Collections.Generic.Dictionary`2<System.String,System.String>
struct Dictionary_2_t3943999495;
// System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String,System.Object>,System.String>
struct Func_2_t1883580443;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.SpecialOffers/Definition
struct  Definition_t3840865879  : public Il2CppObject
{
public:
	// System.String GameOfWhales.SpecialOffers/Definition::id
	String_t* ___id_0;
	// System.String GameOfWhales.SpecialOffers/Definition::title
	String_t* ___title_1;
	// System.String GameOfWhales.SpecialOffers/Definition::description
	String_t* ___description_2;
	// System.Collections.Generic.Dictionary`2<System.String,System.String> GameOfWhales.SpecialOffers/Definition::skus
	Dictionary_2_t3943999495 * ___skus_3;
	// System.DateTime GameOfWhales.SpecialOffers/Definition::activatedAt
	DateTime_t693205669  ___activatedAt_4;
	// System.DateTime GameOfWhales.SpecialOffers/Definition::dateTo
	DateTime_t693205669  ___dateTo_5;
	// System.Single GameOfWhales.SpecialOffers/Definition::activation
	float ___activation_6;
	// System.DateTime GameOfWhales.SpecialOffers/Definition::finishAt
	DateTime_t693205669  ___finishAt_7;
	// System.String GameOfWhales.SpecialOffers/Definition::soPayload
	String_t* ___soPayload_8;

public:
	inline static int32_t get_offset_of_id_0() { return static_cast<int32_t>(offsetof(Definition_t3840865879, ___id_0)); }
	inline String_t* get_id_0() const { return ___id_0; }
	inline String_t** get_address_of_id_0() { return &___id_0; }
	inline void set_id_0(String_t* value)
	{
		___id_0 = value;
		Il2CppCodeGenWriteBarrier(&___id_0, value);
	}

	inline static int32_t get_offset_of_title_1() { return static_cast<int32_t>(offsetof(Definition_t3840865879, ___title_1)); }
	inline String_t* get_title_1() const { return ___title_1; }
	inline String_t** get_address_of_title_1() { return &___title_1; }
	inline void set_title_1(String_t* value)
	{
		___title_1 = value;
		Il2CppCodeGenWriteBarrier(&___title_1, value);
	}

	inline static int32_t get_offset_of_description_2() { return static_cast<int32_t>(offsetof(Definition_t3840865879, ___description_2)); }
	inline String_t* get_description_2() const { return ___description_2; }
	inline String_t** get_address_of_description_2() { return &___description_2; }
	inline void set_description_2(String_t* value)
	{
		___description_2 = value;
		Il2CppCodeGenWriteBarrier(&___description_2, value);
	}

	inline static int32_t get_offset_of_skus_3() { return static_cast<int32_t>(offsetof(Definition_t3840865879, ___skus_3)); }
	inline Dictionary_2_t3943999495 * get_skus_3() const { return ___skus_3; }
	inline Dictionary_2_t3943999495 ** get_address_of_skus_3() { return &___skus_3; }
	inline void set_skus_3(Dictionary_2_t3943999495 * value)
	{
		___skus_3 = value;
		Il2CppCodeGenWriteBarrier(&___skus_3, value);
	}

	inline static int32_t get_offset_of_activatedAt_4() { return static_cast<int32_t>(offsetof(Definition_t3840865879, ___activatedAt_4)); }
	inline DateTime_t693205669  get_activatedAt_4() const { return ___activatedAt_4; }
	inline DateTime_t693205669 * get_address_of_activatedAt_4() { return &___activatedAt_4; }
	inline void set_activatedAt_4(DateTime_t693205669  value)
	{
		___activatedAt_4 = value;
	}

	inline static int32_t get_offset_of_dateTo_5() { return static_cast<int32_t>(offsetof(Definition_t3840865879, ___dateTo_5)); }
	inline DateTime_t693205669  get_dateTo_5() const { return ___dateTo_5; }
	inline DateTime_t693205669 * get_address_of_dateTo_5() { return &___dateTo_5; }
	inline void set_dateTo_5(DateTime_t693205669  value)
	{
		___dateTo_5 = value;
	}

	inline static int32_t get_offset_of_activation_6() { return static_cast<int32_t>(offsetof(Definition_t3840865879, ___activation_6)); }
	inline float get_activation_6() const { return ___activation_6; }
	inline float* get_address_of_activation_6() { return &___activation_6; }
	inline void set_activation_6(float value)
	{
		___activation_6 = value;
	}

	inline static int32_t get_offset_of_finishAt_7() { return static_cast<int32_t>(offsetof(Definition_t3840865879, ___finishAt_7)); }
	inline DateTime_t693205669  get_finishAt_7() const { return ___finishAt_7; }
	inline DateTime_t693205669 * get_address_of_finishAt_7() { return &___finishAt_7; }
	inline void set_finishAt_7(DateTime_t693205669  value)
	{
		___finishAt_7 = value;
	}

	inline static int32_t get_offset_of_soPayload_8() { return static_cast<int32_t>(offsetof(Definition_t3840865879, ___soPayload_8)); }
	inline String_t* get_soPayload_8() const { return ___soPayload_8; }
	inline String_t** get_address_of_soPayload_8() { return &___soPayload_8; }
	inline void set_soPayload_8(String_t* value)
	{
		___soPayload_8 = value;
		Il2CppCodeGenWriteBarrier(&___soPayload_8, value);
	}
};

struct Definition_t3840865879_StaticFields
{
public:
	// System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String,System.Object>,System.String> GameOfWhales.SpecialOffers/Definition::<>f__am$cache0
	Func_2_t1883580443 * ___U3CU3Ef__amU24cache0_9;
	// System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String,System.Object>,System.String> GameOfWhales.SpecialOffers/Definition::<>f__am$cache1
	Func_2_t1883580443 * ___U3CU3Ef__amU24cache1_10;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_9() { return static_cast<int32_t>(offsetof(Definition_t3840865879_StaticFields, ___U3CU3Ef__amU24cache0_9)); }
	inline Func_2_t1883580443 * get_U3CU3Ef__amU24cache0_9() const { return ___U3CU3Ef__amU24cache0_9; }
	inline Func_2_t1883580443 ** get_address_of_U3CU3Ef__amU24cache0_9() { return &___U3CU3Ef__amU24cache0_9; }
	inline void set_U3CU3Ef__amU24cache0_9(Func_2_t1883580443 * value)
	{
		___U3CU3Ef__amU24cache0_9 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_9, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache1_10() { return static_cast<int32_t>(offsetof(Definition_t3840865879_StaticFields, ___U3CU3Ef__amU24cache1_10)); }
	inline Func_2_t1883580443 * get_U3CU3Ef__amU24cache1_10() const { return ___U3CU3Ef__amU24cache1_10; }
	inline Func_2_t1883580443 ** get_address_of_U3CU3Ef__amU24cache1_10() { return &___U3CU3Ef__amU24cache1_10; }
	inline void set_U3CU3Ef__amU24cache1_10(Func_2_t1883580443 * value)
	{
		___U3CU3Ef__amU24cache1_10 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache1_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
