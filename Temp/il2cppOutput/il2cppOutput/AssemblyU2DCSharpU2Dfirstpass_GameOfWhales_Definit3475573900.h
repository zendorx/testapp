#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_EventArgs3289624707.h"

// GameOfWhales.SpecialOffers/Definition
struct Definition_t3840865879;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.DefinitionEventArgs
struct  DefinitionEventArgs_t3475573900  : public EventArgs_t3289624707
{
public:
	// GameOfWhales.SpecialOffers/Definition GameOfWhales.DefinitionEventArgs::definition
	Definition_t3840865879 * ___definition_1;

public:
	inline static int32_t get_offset_of_definition_1() { return static_cast<int32_t>(offsetof(DefinitionEventArgs_t3475573900, ___definition_1)); }
	inline Definition_t3840865879 * get_definition_1() const { return ___definition_1; }
	inline Definition_t3840865879 ** get_address_of_definition_1() { return &___definition_1; }
	inline void set_definition_1(Definition_t3840865879 * value)
	{
		___definition_1 = value;
		Il2CppCodeGenWriteBarrier(&___definition_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
