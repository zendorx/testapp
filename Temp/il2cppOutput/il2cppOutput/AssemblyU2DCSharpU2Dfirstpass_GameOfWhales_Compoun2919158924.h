#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityEngine.Purchasing.IStoreController
struct IStoreController_t92554892;
// UnityEngine.Purchasing.IExtensionProvider
struct IExtensionProvider_t2460996543;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.CompoundStoreListener/<UnityEngine_Purchasing_IStoreListener_OnInitialized>c__AnonStorey2
struct  U3CUnityEngine_Purchasing_IStoreListener_OnInitializedU3Ec__AnonStorey2_t2919158924  : public Il2CppObject
{
public:
	// UnityEngine.Purchasing.IStoreController GameOfWhales.CompoundStoreListener/<UnityEngine_Purchasing_IStoreListener_OnInitialized>c__AnonStorey2::controller
	Il2CppObject * ___controller_0;
	// UnityEngine.Purchasing.IExtensionProvider GameOfWhales.CompoundStoreListener/<UnityEngine_Purchasing_IStoreListener_OnInitialized>c__AnonStorey2::extensions
	Il2CppObject * ___extensions_1;

public:
	inline static int32_t get_offset_of_controller_0() { return static_cast<int32_t>(offsetof(U3CUnityEngine_Purchasing_IStoreListener_OnInitializedU3Ec__AnonStorey2_t2919158924, ___controller_0)); }
	inline Il2CppObject * get_controller_0() const { return ___controller_0; }
	inline Il2CppObject ** get_address_of_controller_0() { return &___controller_0; }
	inline void set_controller_0(Il2CppObject * value)
	{
		___controller_0 = value;
		Il2CppCodeGenWriteBarrier(&___controller_0, value);
	}

	inline static int32_t get_offset_of_extensions_1() { return static_cast<int32_t>(offsetof(U3CUnityEngine_Purchasing_IStoreListener_OnInitializedU3Ec__AnonStorey2_t2919158924, ___extensions_1)); }
	inline Il2CppObject * get_extensions_1() const { return ___extensions_1; }
	inline Il2CppObject ** get_address_of_extensions_1() { return &___extensions_1; }
	inline void set_extensions_1(Il2CppObject * value)
	{
		___extensions_1 = value;
		Il2CppCodeGenWriteBarrier(&___extensions_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
