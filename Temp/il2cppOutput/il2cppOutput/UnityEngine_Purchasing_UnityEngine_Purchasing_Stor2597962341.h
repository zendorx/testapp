﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityEngine.Purchasing.AnalyticsReporter
struct AnalyticsReporter_t3513180421;
// UnityEngine.Purchasing.IStoreListener
struct IStoreListener_t1538020378;
// UnityEngine.Purchasing.IExtensionProvider
struct IExtensionProvider_t2460996543;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Purchasing.StoreListenerProxy
struct  StoreListenerProxy_t2597962341  : public Il2CppObject
{
public:
	// UnityEngine.Purchasing.AnalyticsReporter UnityEngine.Purchasing.StoreListenerProxy::m_Analytics
	AnalyticsReporter_t3513180421 * ___m_Analytics_0;
	// UnityEngine.Purchasing.IStoreListener UnityEngine.Purchasing.StoreListenerProxy::m_ForwardTo
	Il2CppObject * ___m_ForwardTo_1;
	// UnityEngine.Purchasing.IExtensionProvider UnityEngine.Purchasing.StoreListenerProxy::m_Extensions
	Il2CppObject * ___m_Extensions_2;

public:
	inline static int32_t get_offset_of_m_Analytics_0() { return static_cast<int32_t>(offsetof(StoreListenerProxy_t2597962341, ___m_Analytics_0)); }
	inline AnalyticsReporter_t3513180421 * get_m_Analytics_0() const { return ___m_Analytics_0; }
	inline AnalyticsReporter_t3513180421 ** get_address_of_m_Analytics_0() { return &___m_Analytics_0; }
	inline void set_m_Analytics_0(AnalyticsReporter_t3513180421 * value)
	{
		___m_Analytics_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_Analytics_0, value);
	}

	inline static int32_t get_offset_of_m_ForwardTo_1() { return static_cast<int32_t>(offsetof(StoreListenerProxy_t2597962341, ___m_ForwardTo_1)); }
	inline Il2CppObject * get_m_ForwardTo_1() const { return ___m_ForwardTo_1; }
	inline Il2CppObject ** get_address_of_m_ForwardTo_1() { return &___m_ForwardTo_1; }
	inline void set_m_ForwardTo_1(Il2CppObject * value)
	{
		___m_ForwardTo_1 = value;
		Il2CppCodeGenWriteBarrier(&___m_ForwardTo_1, value);
	}

	inline static int32_t get_offset_of_m_Extensions_2() { return static_cast<int32_t>(offsetof(StoreListenerProxy_t2597962341, ___m_Extensions_2)); }
	inline Il2CppObject * get_m_Extensions_2() const { return ___m_Extensions_2; }
	inline Il2CppObject ** get_address_of_m_Extensions_2() { return &___m_Extensions_2; }
	inline void set_m_Extensions_2(Il2CppObject * value)
	{
		___m_Extensions_2 = value;
		Il2CppCodeGenWriteBarrier(&___m_Extensions_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
