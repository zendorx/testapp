#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.IStoreListener>
struct HashSet_1_t4166448528;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.CompoundStoreListener
struct  CompoundStoreListener_t3385788606  : public Il2CppObject
{
public:
	// System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.IStoreListener> GameOfWhales.CompoundStoreListener::_list
	HashSet_1_t4166448528 * ____list_0;

public:
	inline static int32_t get_offset_of__list_0() { return static_cast<int32_t>(offsetof(CompoundStoreListener_t3385788606, ____list_0)); }
	inline HashSet_1_t4166448528 * get__list_0() const { return ____list_0; }
	inline HashSet_1_t4166448528 ** get_address_of__list_0() { return &____list_0; }
	inline void set__list_0(HashSet_1_t4166448528 * value)
	{
		____list_0 = value;
		Il2CppCodeGenWriteBarrier(&____list_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
