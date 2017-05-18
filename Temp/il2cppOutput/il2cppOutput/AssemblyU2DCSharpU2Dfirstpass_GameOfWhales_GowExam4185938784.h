#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.UI.LayoutGroup
struct LayoutGroup_t3962498969;
// GameOfWhales.GowProductItemBase
struct GowProductItemBase_t2148625802;
// UnityEngine.UI.Text
struct Text_t356221433;
// GameOfWhales.GowProductInfo[]
struct GowProductInfoU5BU5D_t1502294369;
// System.Action`1<System.String>
struct Action_1_t1831019615;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.GowExampleBase
struct  GowExampleBase_t4185938784  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.UI.LayoutGroup GameOfWhales.GowExampleBase::_layout
	LayoutGroup_t3962498969 * ____layout_2;
	// GameOfWhales.GowProductItemBase GameOfWhales.GowExampleBase::_itemSource
	GowProductItemBase_t2148625802 * ____itemSource_3;
	// UnityEngine.UI.Text GameOfWhales.GowExampleBase::_coinsText
	Text_t356221433 * ____coinsText_4;
	// GameOfWhales.GowProductInfo[] GameOfWhales.GowExampleBase::infos
	GowProductInfoU5BU5D_t1502294369* ___infos_5;
	// System.Int32 GameOfWhales.GowExampleBase::_coins
	int32_t ____coins_6;

public:
	inline static int32_t get_offset_of__layout_2() { return static_cast<int32_t>(offsetof(GowExampleBase_t4185938784, ____layout_2)); }
	inline LayoutGroup_t3962498969 * get__layout_2() const { return ____layout_2; }
	inline LayoutGroup_t3962498969 ** get_address_of__layout_2() { return &____layout_2; }
	inline void set__layout_2(LayoutGroup_t3962498969 * value)
	{
		____layout_2 = value;
		Il2CppCodeGenWriteBarrier(&____layout_2, value);
	}

	inline static int32_t get_offset_of__itemSource_3() { return static_cast<int32_t>(offsetof(GowExampleBase_t4185938784, ____itemSource_3)); }
	inline GowProductItemBase_t2148625802 * get__itemSource_3() const { return ____itemSource_3; }
	inline GowProductItemBase_t2148625802 ** get_address_of__itemSource_3() { return &____itemSource_3; }
	inline void set__itemSource_3(GowProductItemBase_t2148625802 * value)
	{
		____itemSource_3 = value;
		Il2CppCodeGenWriteBarrier(&____itemSource_3, value);
	}

	inline static int32_t get_offset_of__coinsText_4() { return static_cast<int32_t>(offsetof(GowExampleBase_t4185938784, ____coinsText_4)); }
	inline Text_t356221433 * get__coinsText_4() const { return ____coinsText_4; }
	inline Text_t356221433 ** get_address_of__coinsText_4() { return &____coinsText_4; }
	inline void set__coinsText_4(Text_t356221433 * value)
	{
		____coinsText_4 = value;
		Il2CppCodeGenWriteBarrier(&____coinsText_4, value);
	}

	inline static int32_t get_offset_of_infos_5() { return static_cast<int32_t>(offsetof(GowExampleBase_t4185938784, ___infos_5)); }
	inline GowProductInfoU5BU5D_t1502294369* get_infos_5() const { return ___infos_5; }
	inline GowProductInfoU5BU5D_t1502294369** get_address_of_infos_5() { return &___infos_5; }
	inline void set_infos_5(GowProductInfoU5BU5D_t1502294369* value)
	{
		___infos_5 = value;
		Il2CppCodeGenWriteBarrier(&___infos_5, value);
	}

	inline static int32_t get_offset_of__coins_6() { return static_cast<int32_t>(offsetof(GowExampleBase_t4185938784, ____coins_6)); }
	inline int32_t get__coins_6() const { return ____coins_6; }
	inline int32_t* get_address_of__coins_6() { return &____coins_6; }
	inline void set__coins_6(int32_t value)
	{
		____coins_6 = value;
	}
};

struct GowExampleBase_t4185938784_StaticFields
{
public:
	// System.Action`1<System.String> GameOfWhales.GowExampleBase::<>f__am$cache0
	Action_1_t1831019615 * ___U3CU3Ef__amU24cache0_7;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_7() { return static_cast<int32_t>(offsetof(GowExampleBase_t4185938784_StaticFields, ___U3CU3Ef__amU24cache0_7)); }
	inline Action_1_t1831019615 * get_U3CU3Ef__amU24cache0_7() const { return ___U3CU3Ef__amU24cache0_7; }
	inline Action_1_t1831019615 ** get_address_of_U3CU3Ef__amU24cache0_7() { return &___U3CU3Ef__amU24cache0_7; }
	inline void set_U3CU3Ef__amU24cache0_7(Action_1_t1831019615 * value)
	{
		___U3CU3Ef__amU24cache0_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
