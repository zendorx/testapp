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




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.GowNotification
struct  GowNotification_t3042362580  : public Il2CppObject
{
public:
	// System.String GameOfWhales.GowNotification::title
	String_t* ___title_0;
	// System.String GameOfWhales.GowNotification::message
	String_t* ___message_1;
	// System.String GameOfWhales.GowNotification::pushId
	String_t* ___pushId_2;

public:
	inline static int32_t get_offset_of_title_0() { return static_cast<int32_t>(offsetof(GowNotification_t3042362580, ___title_0)); }
	inline String_t* get_title_0() const { return ___title_0; }
	inline String_t** get_address_of_title_0() { return &___title_0; }
	inline void set_title_0(String_t* value)
	{
		___title_0 = value;
		Il2CppCodeGenWriteBarrier(&___title_0, value);
	}

	inline static int32_t get_offset_of_message_1() { return static_cast<int32_t>(offsetof(GowNotification_t3042362580, ___message_1)); }
	inline String_t* get_message_1() const { return ___message_1; }
	inline String_t** get_address_of_message_1() { return &___message_1; }
	inline void set_message_1(String_t* value)
	{
		___message_1 = value;
		Il2CppCodeGenWriteBarrier(&___message_1, value);
	}

	inline static int32_t get_offset_of_pushId_2() { return static_cast<int32_t>(offsetof(GowNotification_t3042362580, ___pushId_2)); }
	inline String_t* get_pushId_2() const { return ___pushId_2; }
	inline String_t** get_address_of_pushId_2() { return &___pushId_2; }
	inline void set_pushId_2(String_t* value)
	{
		___pushId_2 = value;
		Il2CppCodeGenWriteBarrier(&___pushId_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
