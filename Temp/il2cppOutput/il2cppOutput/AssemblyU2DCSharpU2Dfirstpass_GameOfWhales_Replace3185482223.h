#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_EventArgs3289624707.h"

// GameOfWhales.SpecialOffers/Replacement
struct Replacement_t2058140272;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.ReplacementEventArgs
struct  ReplacementEventArgs_t3185482223  : public EventArgs_t3289624707
{
public:
	// GameOfWhales.SpecialOffers/Replacement GameOfWhales.ReplacementEventArgs::replacement
	Replacement_t2058140272 * ___replacement_1;

public:
	inline static int32_t get_offset_of_replacement_1() { return static_cast<int32_t>(offsetof(ReplacementEventArgs_t3185482223, ___replacement_1)); }
	inline Replacement_t2058140272 * get_replacement_1() const { return ___replacement_1; }
	inline Replacement_t2058140272 ** get_address_of_replacement_1() { return &___replacement_1; }
	inline void set_replacement_1(Replacement_t2058140272 * value)
	{
		___replacement_1 = value;
		Il2CppCodeGenWriteBarrier(&___replacement_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
