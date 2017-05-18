#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// GameOfWhales.GowProductInfo
struct GowProductInfo_t609051168;
// UnityEngine.UI.Text
struct Text_t356221433;
// UnityEngine.UI.Image
struct Image_t2042527209;
// UnityEngine.AudioClip
struct AudioClip_t1932558630;
// GameOfWhales.SpecialOffers/Replacement
struct Replacement_t2058140272;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.GowProductItemBase
struct  GowProductItemBase_t2148625802  : public MonoBehaviour_t1158329972
{
public:
	// GameOfWhales.GowProductInfo GameOfWhales.GowProductItemBase::info
	GowProductInfo_t609051168 * ___info_2;
	// UnityEngine.UI.Text GameOfWhales.GowProductItemBase::_coins
	Text_t356221433 * ____coins_3;
	// UnityEngine.UI.Text GameOfWhales.GowProductItemBase::_price
	Text_t356221433 * ____price_4;
	// UnityEngine.UI.Image GameOfWhales.GowProductItemBase::_icon
	Image_t2042527209 * ____icon_5;
	// UnityEngine.AudioClip GameOfWhales.GowProductItemBase::_tap
	AudioClip_t1932558630 * ____tap_6;
	// UnityEngine.UI.Image GameOfWhales.GowProductItemBase::_so
	Image_t2042527209 * ____so_7;
	// GameOfWhales.SpecialOffers/Replacement GameOfWhales.GowProductItemBase::replacement
	Replacement_t2058140272 * ___replacement_8;

public:
	inline static int32_t get_offset_of_info_2() { return static_cast<int32_t>(offsetof(GowProductItemBase_t2148625802, ___info_2)); }
	inline GowProductInfo_t609051168 * get_info_2() const { return ___info_2; }
	inline GowProductInfo_t609051168 ** get_address_of_info_2() { return &___info_2; }
	inline void set_info_2(GowProductInfo_t609051168 * value)
	{
		___info_2 = value;
		Il2CppCodeGenWriteBarrier(&___info_2, value);
	}

	inline static int32_t get_offset_of__coins_3() { return static_cast<int32_t>(offsetof(GowProductItemBase_t2148625802, ____coins_3)); }
	inline Text_t356221433 * get__coins_3() const { return ____coins_3; }
	inline Text_t356221433 ** get_address_of__coins_3() { return &____coins_3; }
	inline void set__coins_3(Text_t356221433 * value)
	{
		____coins_3 = value;
		Il2CppCodeGenWriteBarrier(&____coins_3, value);
	}

	inline static int32_t get_offset_of__price_4() { return static_cast<int32_t>(offsetof(GowProductItemBase_t2148625802, ____price_4)); }
	inline Text_t356221433 * get__price_4() const { return ____price_4; }
	inline Text_t356221433 ** get_address_of__price_4() { return &____price_4; }
	inline void set__price_4(Text_t356221433 * value)
	{
		____price_4 = value;
		Il2CppCodeGenWriteBarrier(&____price_4, value);
	}

	inline static int32_t get_offset_of__icon_5() { return static_cast<int32_t>(offsetof(GowProductItemBase_t2148625802, ____icon_5)); }
	inline Image_t2042527209 * get__icon_5() const { return ____icon_5; }
	inline Image_t2042527209 ** get_address_of__icon_5() { return &____icon_5; }
	inline void set__icon_5(Image_t2042527209 * value)
	{
		____icon_5 = value;
		Il2CppCodeGenWriteBarrier(&____icon_5, value);
	}

	inline static int32_t get_offset_of__tap_6() { return static_cast<int32_t>(offsetof(GowProductItemBase_t2148625802, ____tap_6)); }
	inline AudioClip_t1932558630 * get__tap_6() const { return ____tap_6; }
	inline AudioClip_t1932558630 ** get_address_of__tap_6() { return &____tap_6; }
	inline void set__tap_6(AudioClip_t1932558630 * value)
	{
		____tap_6 = value;
		Il2CppCodeGenWriteBarrier(&____tap_6, value);
	}

	inline static int32_t get_offset_of__so_7() { return static_cast<int32_t>(offsetof(GowProductItemBase_t2148625802, ____so_7)); }
	inline Image_t2042527209 * get__so_7() const { return ____so_7; }
	inline Image_t2042527209 ** get_address_of__so_7() { return &____so_7; }
	inline void set__so_7(Image_t2042527209 * value)
	{
		____so_7 = value;
		Il2CppCodeGenWriteBarrier(&____so_7, value);
	}

	inline static int32_t get_offset_of_replacement_8() { return static_cast<int32_t>(offsetof(GowProductItemBase_t2148625802, ___replacement_8)); }
	inline Replacement_t2058140272 * get_replacement_8() const { return ___replacement_8; }
	inline Replacement_t2058140272 ** get_address_of_replacement_8() { return &___replacement_8; }
	inline void set_replacement_8(Replacement_t2058140272 * value)
	{
		___replacement_8 = value;
		Il2CppCodeGenWriteBarrier(&___replacement_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
