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
// GameOfWhales.GowDataStorage
struct GowDataStorage_t167176880;
// System.Collections.Generic.Dictionary`2<System.String,System.Object>
struct Dictionary_2_t309261261;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.GowDataStorage
struct  GowDataStorage_t167176880  : public Il2CppObject
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Object> GameOfWhales.GowDataStorage::_gowData
	Dictionary_2_t309261261 * ____gowData_2;

public:
	inline static int32_t get_offset_of__gowData_2() { return static_cast<int32_t>(offsetof(GowDataStorage_t167176880, ____gowData_2)); }
	inline Dictionary_2_t309261261 * get__gowData_2() const { return ____gowData_2; }
	inline Dictionary_2_t309261261 ** get_address_of__gowData_2() { return &____gowData_2; }
	inline void set__gowData_2(Dictionary_2_t309261261 * value)
	{
		____gowData_2 = value;
		Il2CppCodeGenWriteBarrier(&____gowData_2, value);
	}
};

struct GowDataStorage_t167176880_StaticFields
{
public:
	// System.String GameOfWhales.GowDataStorage::GOW_DATA
	String_t* ___GOW_DATA_0;
	// GameOfWhales.GowDataStorage GameOfWhales.GowDataStorage::_instance
	GowDataStorage_t167176880 * ____instance_1;

public:
	inline static int32_t get_offset_of_GOW_DATA_0() { return static_cast<int32_t>(offsetof(GowDataStorage_t167176880_StaticFields, ___GOW_DATA_0)); }
	inline String_t* get_GOW_DATA_0() const { return ___GOW_DATA_0; }
	inline String_t** get_address_of_GOW_DATA_0() { return &___GOW_DATA_0; }
	inline void set_GOW_DATA_0(String_t* value)
	{
		___GOW_DATA_0 = value;
		Il2CppCodeGenWriteBarrier(&___GOW_DATA_0, value);
	}

	inline static int32_t get_offset_of__instance_1() { return static_cast<int32_t>(offsetof(GowDataStorage_t167176880_StaticFields, ____instance_1)); }
	inline GowDataStorage_t167176880 * get__instance_1() const { return ____instance_1; }
	inline GowDataStorage_t167176880 ** get_address_of__instance_1() { return &____instance_1; }
	inline void set__instance_1(GowDataStorage_t167176880 * value)
	{
		____instance_1 = value;
		Il2CppCodeGenWriteBarrier(&____instance_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
