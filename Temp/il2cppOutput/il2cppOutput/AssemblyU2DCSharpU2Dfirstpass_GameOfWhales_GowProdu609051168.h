#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_ScriptableObject1975622470.h"

// UnityEngine.Sprite
struct Sprite_t309593783;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.GowProductInfo
struct  GowProductInfo_t609051168  : public ScriptableObject_t1975622470
{
public:
	// System.Single GameOfWhales.GowProductInfo::price
	float ___price_2;
	// UnityEngine.Sprite GameOfWhales.GowProductInfo::icon
	Sprite_t309593783 * ___icon_3;
	// System.Int32 GameOfWhales.GowProductInfo::coins
	int32_t ___coins_4;

public:
	inline static int32_t get_offset_of_price_2() { return static_cast<int32_t>(offsetof(GowProductInfo_t609051168, ___price_2)); }
	inline float get_price_2() const { return ___price_2; }
	inline float* get_address_of_price_2() { return &___price_2; }
	inline void set_price_2(float value)
	{
		___price_2 = value;
	}

	inline static int32_t get_offset_of_icon_3() { return static_cast<int32_t>(offsetof(GowProductInfo_t609051168, ___icon_3)); }
	inline Sprite_t309593783 * get_icon_3() const { return ___icon_3; }
	inline Sprite_t309593783 ** get_address_of_icon_3() { return &___icon_3; }
	inline void set_icon_3(Sprite_t309593783 * value)
	{
		___icon_3 = value;
		Il2CppCodeGenWriteBarrier(&___icon_3, value);
	}

	inline static int32_t get_offset_of_coins_4() { return static_cast<int32_t>(offsetof(GowProductInfo_t609051168, ___coins_4)); }
	inline int32_t get_coins_4() const { return ___coins_4; }
	inline int32_t* get_address_of_coins_4() { return &___coins_4; }
	inline void set_coins_4(int32_t value)
	{
		___coins_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
