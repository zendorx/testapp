#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.String
struct String_t;
// System.Action
struct Action_t3226471752;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.DeviceInfo/DialogRequests
struct  DialogRequests_t204562422  : public Il2CppObject
{
public:
	// System.String GameOfWhales.DeviceInfo/DialogRequests::id
	String_t* ___id_0;
	// System.String GameOfWhales.DeviceInfo/DialogRequests::title
	String_t* ___title_1;
	// System.String GameOfWhales.DeviceInfo/DialogRequests::message
	String_t* ___message_2;
	// System.Action GameOfWhales.DeviceInfo/DialogRequests::onOk
	Action_t3226471752 * ___onOk_3;
	// System.Action GameOfWhales.DeviceInfo/DialogRequests::onCancel
	Action_t3226471752 * ___onCancel_4;

public:
	inline static int32_t get_offset_of_id_0() { return static_cast<int32_t>(offsetof(DialogRequests_t204562422, ___id_0)); }
	inline String_t* get_id_0() const { return ___id_0; }
	inline String_t** get_address_of_id_0() { return &___id_0; }
	inline void set_id_0(String_t* value)
	{
		___id_0 = value;
		Il2CppCodeGenWriteBarrier(&___id_0, value);
	}

	inline static int32_t get_offset_of_title_1() { return static_cast<int32_t>(offsetof(DialogRequests_t204562422, ___title_1)); }
	inline String_t* get_title_1() const { return ___title_1; }
	inline String_t** get_address_of_title_1() { return &___title_1; }
	inline void set_title_1(String_t* value)
	{
		___title_1 = value;
		Il2CppCodeGenWriteBarrier(&___title_1, value);
	}

	inline static int32_t get_offset_of_message_2() { return static_cast<int32_t>(offsetof(DialogRequests_t204562422, ___message_2)); }
	inline String_t* get_message_2() const { return ___message_2; }
	inline String_t** get_address_of_message_2() { return &___message_2; }
	inline void set_message_2(String_t* value)
	{
		___message_2 = value;
		Il2CppCodeGenWriteBarrier(&___message_2, value);
	}

	inline static int32_t get_offset_of_onOk_3() { return static_cast<int32_t>(offsetof(DialogRequests_t204562422, ___onOk_3)); }
	inline Action_t3226471752 * get_onOk_3() const { return ___onOk_3; }
	inline Action_t3226471752 ** get_address_of_onOk_3() { return &___onOk_3; }
	inline void set_onOk_3(Action_t3226471752 * value)
	{
		___onOk_3 = value;
		Il2CppCodeGenWriteBarrier(&___onOk_3, value);
	}

	inline static int32_t get_offset_of_onCancel_4() { return static_cast<int32_t>(offsetof(DialogRequests_t204562422, ___onCancel_4)); }
	inline Action_t3226471752 * get_onCancel_4() const { return ___onCancel_4; }
	inline Action_t3226471752 ** get_address_of_onCancel_4() { return &___onCancel_4; }
	inline void set_onCancel_4(Action_t3226471752 * value)
	{
		___onCancel_4 = value;
		Il2CppCodeGenWriteBarrier(&___onCancel_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
