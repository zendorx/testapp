#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "mscorlib_System_Collections_Generic_KeyValuePair_2_g38854645.h"

// System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<System.Object,System.Object>>
struct IEnumerable_1_t330981690;
// System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<System.Object,System.Object>>
struct IEnumerator_1_t1809345768;
// System.Func`2<System.Collections.Generic.KeyValuePair`2<System.Object,System.Object>,System.Object>
struct Func_2_t2065790391;
// System.Object
struct Il2CppObject;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.ClrUnityUtils/<Select>c__Iterator1`2<System.Collections.Generic.KeyValuePair`2<System.Object,System.Object>,System.Object>
struct  U3CSelectU3Ec__Iterator1_2_t3817382600  : public Il2CppObject
{
public:
	// System.Collections.Generic.IEnumerable`1<T> GameOfWhales.ClrUnityUtils/<Select>c__Iterator1`2::list
	Il2CppObject* ___list_0;
	// System.Collections.Generic.IEnumerator`1<T> GameOfWhales.ClrUnityUtils/<Select>c__Iterator1`2::$locvar0
	Il2CppObject* ___U24locvar0_1;
	// T GameOfWhales.ClrUnityUtils/<Select>c__Iterator1`2::<e>__1
	KeyValuePair_2_t38854645  ___U3CeU3E__1_2;
	// System.Func`2<T,TResult> GameOfWhales.ClrUnityUtils/<Select>c__Iterator1`2::selector
	Func_2_t2065790391 * ___selector_3;
	// TResult GameOfWhales.ClrUnityUtils/<Select>c__Iterator1`2::$current
	Il2CppObject * ___U24current_4;
	// System.Boolean GameOfWhales.ClrUnityUtils/<Select>c__Iterator1`2::$disposing
	bool ___U24disposing_5;
	// System.Int32 GameOfWhales.ClrUnityUtils/<Select>c__Iterator1`2::$PC
	int32_t ___U24PC_6;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(U3CSelectU3Ec__Iterator1_2_t3817382600, ___list_0)); }
	inline Il2CppObject* get_list_0() const { return ___list_0; }
	inline Il2CppObject** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(Il2CppObject* value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier(&___list_0, value);
	}

	inline static int32_t get_offset_of_U24locvar0_1() { return static_cast<int32_t>(offsetof(U3CSelectU3Ec__Iterator1_2_t3817382600, ___U24locvar0_1)); }
	inline Il2CppObject* get_U24locvar0_1() const { return ___U24locvar0_1; }
	inline Il2CppObject** get_address_of_U24locvar0_1() { return &___U24locvar0_1; }
	inline void set_U24locvar0_1(Il2CppObject* value)
	{
		___U24locvar0_1 = value;
		Il2CppCodeGenWriteBarrier(&___U24locvar0_1, value);
	}

	inline static int32_t get_offset_of_U3CeU3E__1_2() { return static_cast<int32_t>(offsetof(U3CSelectU3Ec__Iterator1_2_t3817382600, ___U3CeU3E__1_2)); }
	inline KeyValuePair_2_t38854645  get_U3CeU3E__1_2() const { return ___U3CeU3E__1_2; }
	inline KeyValuePair_2_t38854645 * get_address_of_U3CeU3E__1_2() { return &___U3CeU3E__1_2; }
	inline void set_U3CeU3E__1_2(KeyValuePair_2_t38854645  value)
	{
		___U3CeU3E__1_2 = value;
	}

	inline static int32_t get_offset_of_selector_3() { return static_cast<int32_t>(offsetof(U3CSelectU3Ec__Iterator1_2_t3817382600, ___selector_3)); }
	inline Func_2_t2065790391 * get_selector_3() const { return ___selector_3; }
	inline Func_2_t2065790391 ** get_address_of_selector_3() { return &___selector_3; }
	inline void set_selector_3(Func_2_t2065790391 * value)
	{
		___selector_3 = value;
		Il2CppCodeGenWriteBarrier(&___selector_3, value);
	}

	inline static int32_t get_offset_of_U24current_4() { return static_cast<int32_t>(offsetof(U3CSelectU3Ec__Iterator1_2_t3817382600, ___U24current_4)); }
	inline Il2CppObject * get_U24current_4() const { return ___U24current_4; }
	inline Il2CppObject ** get_address_of_U24current_4() { return &___U24current_4; }
	inline void set_U24current_4(Il2CppObject * value)
	{
		___U24current_4 = value;
		Il2CppCodeGenWriteBarrier(&___U24current_4, value);
	}

	inline static int32_t get_offset_of_U24disposing_5() { return static_cast<int32_t>(offsetof(U3CSelectU3Ec__Iterator1_2_t3817382600, ___U24disposing_5)); }
	inline bool get_U24disposing_5() const { return ___U24disposing_5; }
	inline bool* get_address_of_U24disposing_5() { return &___U24disposing_5; }
	inline void set_U24disposing_5(bool value)
	{
		___U24disposing_5 = value;
	}

	inline static int32_t get_offset_of_U24PC_6() { return static_cast<int32_t>(offsetof(U3CSelectU3Ec__Iterator1_2_t3817382600, ___U24PC_6)); }
	inline int32_t get_U24PC_6() const { return ___U24PC_6; }
	inline int32_t* get_address_of_U24PC_6() { return &___U24PC_6; }
	inline void set_U24PC_6(int32_t value)
	{
		___U24PC_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
