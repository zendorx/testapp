#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharpU2Dfirstpass_GameOfWhales_GowProd2148625802.h"

// GameOfWhales.GowExampleStoreListener
struct GowExampleStoreListener_t2120321040;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.GowProductItem2
struct  GowProductItem2_t974293117  : public GowProductItemBase_t2148625802
{
public:
	// GameOfWhales.GowExampleStoreListener GameOfWhales.GowProductItem2::_storeController
	GowExampleStoreListener_t2120321040 * ____storeController_9;

public:
	inline static int32_t get_offset_of__storeController_9() { return static_cast<int32_t>(offsetof(GowProductItem2_t974293117, ____storeController_9)); }
	inline GowExampleStoreListener_t2120321040 * get__storeController_9() const { return ____storeController_9; }
	inline GowExampleStoreListener_t2120321040 ** get_address_of__storeController_9() { return &____storeController_9; }
	inline void set__storeController_9(GowExampleStoreListener_t2120321040 * value)
	{
		____storeController_9 = value;
		Il2CppCodeGenWriteBarrier(&____storeController_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
