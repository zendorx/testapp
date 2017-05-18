#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.List`1<GameOfWhales.SpecialOffers/Definition>
struct List_1_t3209987011;
// System.Collections.Generic.Dictionary`2<System.String,GameOfWhales.SpecialOffers/Replacement>
struct Dictionary_2_t3972919534;
// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<GameOfWhales.SpecialOffers/Replacement>>
struct Dictionary_2_t3342040666;
// System.Func`2<GameOfWhales.SpecialOffers/Replacement,System.Boolean>
struct Func_2_t2781681887;
// System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String,GameOfWhales.SpecialOffers/Replacement>,GameOfWhales.SpecialOffers/Replacement>
struct Func_2_t732552765;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.SpecialOffers
struct  SpecialOffers_t365073028  : public Il2CppObject
{
public:
	// System.Collections.Generic.List`1<GameOfWhales.SpecialOffers/Definition> GameOfWhales.SpecialOffers::_sos
	List_1_t3209987011 * ____sos_0;
	// System.Collections.Generic.Dictionary`2<System.String,GameOfWhales.SpecialOffers/Replacement> GameOfWhales.SpecialOffers::_best
	Dictionary_2_t3972919534 * ____best_1;
	// System.Collections.Generic.Dictionary`2<System.String,System.Collections.Generic.List`1<GameOfWhales.SpecialOffers/Replacement>> GameOfWhales.SpecialOffers::_replacements
	Dictionary_2_t3342040666 * ____replacements_2;

public:
	inline static int32_t get_offset_of__sos_0() { return static_cast<int32_t>(offsetof(SpecialOffers_t365073028, ____sos_0)); }
	inline List_1_t3209987011 * get__sos_0() const { return ____sos_0; }
	inline List_1_t3209987011 ** get_address_of__sos_0() { return &____sos_0; }
	inline void set__sos_0(List_1_t3209987011 * value)
	{
		____sos_0 = value;
		Il2CppCodeGenWriteBarrier(&____sos_0, value);
	}

	inline static int32_t get_offset_of__best_1() { return static_cast<int32_t>(offsetof(SpecialOffers_t365073028, ____best_1)); }
	inline Dictionary_2_t3972919534 * get__best_1() const { return ____best_1; }
	inline Dictionary_2_t3972919534 ** get_address_of__best_1() { return &____best_1; }
	inline void set__best_1(Dictionary_2_t3972919534 * value)
	{
		____best_1 = value;
		Il2CppCodeGenWriteBarrier(&____best_1, value);
	}

	inline static int32_t get_offset_of__replacements_2() { return static_cast<int32_t>(offsetof(SpecialOffers_t365073028, ____replacements_2)); }
	inline Dictionary_2_t3342040666 * get__replacements_2() const { return ____replacements_2; }
	inline Dictionary_2_t3342040666 ** get_address_of__replacements_2() { return &____replacements_2; }
	inline void set__replacements_2(Dictionary_2_t3342040666 * value)
	{
		____replacements_2 = value;
		Il2CppCodeGenWriteBarrier(&____replacements_2, value);
	}
};

struct SpecialOffers_t365073028_StaticFields
{
public:
	// System.Func`2<GameOfWhales.SpecialOffers/Replacement,System.Boolean> GameOfWhales.SpecialOffers::<>f__am$cache0
	Func_2_t2781681887 * ___U3CU3Ef__amU24cache0_3;
	// System.Func`2<System.Collections.Generic.KeyValuePair`2<System.String,GameOfWhales.SpecialOffers/Replacement>,GameOfWhales.SpecialOffers/Replacement> GameOfWhales.SpecialOffers::<>f__am$cache1
	Func_2_t732552765 * ___U3CU3Ef__amU24cache1_4;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_3() { return static_cast<int32_t>(offsetof(SpecialOffers_t365073028_StaticFields, ___U3CU3Ef__amU24cache0_3)); }
	inline Func_2_t2781681887 * get_U3CU3Ef__amU24cache0_3() const { return ___U3CU3Ef__amU24cache0_3; }
	inline Func_2_t2781681887 ** get_address_of_U3CU3Ef__amU24cache0_3() { return &___U3CU3Ef__amU24cache0_3; }
	inline void set_U3CU3Ef__amU24cache0_3(Func_2_t2781681887 * value)
	{
		___U3CU3Ef__amU24cache0_3 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_3, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__amU24cache1_4() { return static_cast<int32_t>(offsetof(SpecialOffers_t365073028_StaticFields, ___U3CU3Ef__amU24cache1_4)); }
	inline Func_2_t732552765 * get_U3CU3Ef__amU24cache1_4() const { return ___U3CU3Ef__amU24cache1_4; }
	inline Func_2_t732552765 ** get_address_of_U3CU3Ef__amU24cache1_4() { return &___U3CU3Ef__amU24cache1_4; }
	inline void set_U3CU3Ef__amU24cache1_4(Func_2_t732552765 * value)
	{
		___U3CU3Ef__amU24cache1_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache1_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
