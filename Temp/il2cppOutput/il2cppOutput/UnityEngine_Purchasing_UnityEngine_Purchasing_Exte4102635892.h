﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityEngine.Purchasing.Extension.IPurchasingBinder
struct IPurchasingBinder_t2054654539;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Purchasing.Extension.AbstractPurchasingModule
struct  AbstractPurchasingModule_t4102635892  : public Il2CppObject
{
public:
	// UnityEngine.Purchasing.Extension.IPurchasingBinder UnityEngine.Purchasing.Extension.AbstractPurchasingModule::m_Binder
	Il2CppObject * ___m_Binder_0;

public:
	inline static int32_t get_offset_of_m_Binder_0() { return static_cast<int32_t>(offsetof(AbstractPurchasingModule_t4102635892, ___m_Binder_0)); }
	inline Il2CppObject * get_m_Binder_0() const { return ___m_Binder_0; }
	inline Il2CppObject ** get_address_of_m_Binder_0() { return &___m_Binder_0; }
	inline void set_m_Binder_0(Il2CppObject * value)
	{
		___m_Binder_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_Binder_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
