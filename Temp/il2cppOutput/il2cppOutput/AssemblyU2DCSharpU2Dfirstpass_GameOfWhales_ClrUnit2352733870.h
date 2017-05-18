#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Generic.IEnumerable`1<System.Object>
struct IEnumerable_1_t2981576340;
// System.Collections.Generic.IEnumerator`1<System.Object>
struct IEnumerator_1_t164973122;
// System.Object
struct Il2CppObject;
// System.Func`2<System.Object,System.Collections.Generic.IEnumerable`1<System.Object>>
struct Func_2_t3117631226;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.ClrUnityUtils/<SelectMany>c__Iterator2`2<System.Object,System.Object>
struct  U3CSelectManyU3Ec__Iterator2_2_t2352733870  : public Il2CppObject
{
public:
	// System.Collections.Generic.IEnumerable`1<T> GameOfWhales.ClrUnityUtils/<SelectMany>c__Iterator2`2::list
	Il2CppObject* ___list_0;
	// System.Collections.Generic.IEnumerator`1<T> GameOfWhales.ClrUnityUtils/<SelectMany>c__Iterator2`2::$locvar0
	Il2CppObject* ___U24locvar0_1;
	// T GameOfWhales.ClrUnityUtils/<SelectMany>c__Iterator2`2::<e>__1
	Il2CppObject * ___U3CeU3E__1_2;
	// System.Func`2<T,System.Collections.Generic.IEnumerable`1<TResult>> GameOfWhales.ClrUnityUtils/<SelectMany>c__Iterator2`2::selector
	Func_2_t3117631226 * ___selector_3;
	// System.Collections.Generic.IEnumerator`1<TResult> GameOfWhales.ClrUnityUtils/<SelectMany>c__Iterator2`2::$locvar1
	Il2CppObject* ___U24locvar1_4;
	// TResult GameOfWhales.ClrUnityUtils/<SelectMany>c__Iterator2`2::<childE>__2
	Il2CppObject * ___U3CchildEU3E__2_5;
	// TResult GameOfWhales.ClrUnityUtils/<SelectMany>c__Iterator2`2::$current
	Il2CppObject * ___U24current_6;
	// System.Boolean GameOfWhales.ClrUnityUtils/<SelectMany>c__Iterator2`2::$disposing
	bool ___U24disposing_7;
	// System.Int32 GameOfWhales.ClrUnityUtils/<SelectMany>c__Iterator2`2::$PC
	int32_t ___U24PC_8;

public:
	inline static int32_t get_offset_of_list_0() { return static_cast<int32_t>(offsetof(U3CSelectManyU3Ec__Iterator2_2_t2352733870, ___list_0)); }
	inline Il2CppObject* get_list_0() const { return ___list_0; }
	inline Il2CppObject** get_address_of_list_0() { return &___list_0; }
	inline void set_list_0(Il2CppObject* value)
	{
		___list_0 = value;
		Il2CppCodeGenWriteBarrier(&___list_0, value);
	}

	inline static int32_t get_offset_of_U24locvar0_1() { return static_cast<int32_t>(offsetof(U3CSelectManyU3Ec__Iterator2_2_t2352733870, ___U24locvar0_1)); }
	inline Il2CppObject* get_U24locvar0_1() const { return ___U24locvar0_1; }
	inline Il2CppObject** get_address_of_U24locvar0_1() { return &___U24locvar0_1; }
	inline void set_U24locvar0_1(Il2CppObject* value)
	{
		___U24locvar0_1 = value;
		Il2CppCodeGenWriteBarrier(&___U24locvar0_1, value);
	}

	inline static int32_t get_offset_of_U3CeU3E__1_2() { return static_cast<int32_t>(offsetof(U3CSelectManyU3Ec__Iterator2_2_t2352733870, ___U3CeU3E__1_2)); }
	inline Il2CppObject * get_U3CeU3E__1_2() const { return ___U3CeU3E__1_2; }
	inline Il2CppObject ** get_address_of_U3CeU3E__1_2() { return &___U3CeU3E__1_2; }
	inline void set_U3CeU3E__1_2(Il2CppObject * value)
	{
		___U3CeU3E__1_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CeU3E__1_2, value);
	}

	inline static int32_t get_offset_of_selector_3() { return static_cast<int32_t>(offsetof(U3CSelectManyU3Ec__Iterator2_2_t2352733870, ___selector_3)); }
	inline Func_2_t3117631226 * get_selector_3() const { return ___selector_3; }
	inline Func_2_t3117631226 ** get_address_of_selector_3() { return &___selector_3; }
	inline void set_selector_3(Func_2_t3117631226 * value)
	{
		___selector_3 = value;
		Il2CppCodeGenWriteBarrier(&___selector_3, value);
	}

	inline static int32_t get_offset_of_U24locvar1_4() { return static_cast<int32_t>(offsetof(U3CSelectManyU3Ec__Iterator2_2_t2352733870, ___U24locvar1_4)); }
	inline Il2CppObject* get_U24locvar1_4() const { return ___U24locvar1_4; }
	inline Il2CppObject** get_address_of_U24locvar1_4() { return &___U24locvar1_4; }
	inline void set_U24locvar1_4(Il2CppObject* value)
	{
		___U24locvar1_4 = value;
		Il2CppCodeGenWriteBarrier(&___U24locvar1_4, value);
	}

	inline static int32_t get_offset_of_U3CchildEU3E__2_5() { return static_cast<int32_t>(offsetof(U3CSelectManyU3Ec__Iterator2_2_t2352733870, ___U3CchildEU3E__2_5)); }
	inline Il2CppObject * get_U3CchildEU3E__2_5() const { return ___U3CchildEU3E__2_5; }
	inline Il2CppObject ** get_address_of_U3CchildEU3E__2_5() { return &___U3CchildEU3E__2_5; }
	inline void set_U3CchildEU3E__2_5(Il2CppObject * value)
	{
		___U3CchildEU3E__2_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3CchildEU3E__2_5, value);
	}

	inline static int32_t get_offset_of_U24current_6() { return static_cast<int32_t>(offsetof(U3CSelectManyU3Ec__Iterator2_2_t2352733870, ___U24current_6)); }
	inline Il2CppObject * get_U24current_6() const { return ___U24current_6; }
	inline Il2CppObject ** get_address_of_U24current_6() { return &___U24current_6; }
	inline void set_U24current_6(Il2CppObject * value)
	{
		___U24current_6 = value;
		Il2CppCodeGenWriteBarrier(&___U24current_6, value);
	}

	inline static int32_t get_offset_of_U24disposing_7() { return static_cast<int32_t>(offsetof(U3CSelectManyU3Ec__Iterator2_2_t2352733870, ___U24disposing_7)); }
	inline bool get_U24disposing_7() const { return ___U24disposing_7; }
	inline bool* get_address_of_U24disposing_7() { return &___U24disposing_7; }
	inline void set_U24disposing_7(bool value)
	{
		___U24disposing_7 = value;
	}

	inline static int32_t get_offset_of_U24PC_8() { return static_cast<int32_t>(offsetof(U3CSelectManyU3Ec__Iterator2_2_t2352733870, ___U24PC_8)); }
	inline int32_t get_U24PC_8() const { return ___U24PC_8; }
	inline int32_t* get_address_of_U24PC_8() { return &___U24PC_8; }
	inline void set_U24PC_8(int32_t value)
	{
		___U24PC_8 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
