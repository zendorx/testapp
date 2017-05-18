#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.Action`1<GameOfWhales.GowNotification[]>
struct Action_1_t1694514227;
// System.Action`1<GameOfWhales.GowNotification>
struct Action_1_t2844161962;
// System.Action`1<System.String>
struct Action_1_t1831019615;
// System.Collections.Generic.Queue`1<GameOfWhales.DeviceInfo/DialogRequests>
struct Queue_1_t24219257;
// System.Collections.Generic.List`1<System.String>
struct List_1_t1398341365;
// GameOfWhales.DeviceInfo/DialogRequests
struct DialogRequests_t204562422;
// System.String
struct String_t;
// System.Func`2<System.Collections.Generic.Dictionary`2<System.String,System.Object>,GameOfWhales.GowNotification>
struct Func_2_t1667507972;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameOfWhales.DeviceInfo
struct  DeviceInfo_t3954376236  : public MonoBehaviour_t1158329972
{
public:
	// System.Action`1<GameOfWhales.GowNotification[]> GameOfWhales.DeviceInfo::NotificationRecieved
	Action_1_t1694514227 * ___NotificationRecieved_2;
	// System.Action`1<GameOfWhales.GowNotification> GameOfWhales.DeviceInfo::CurrentNotificationRecieved
	Action_1_t2844161962 * ___CurrentNotificationRecieved_3;
	// System.Action`1<System.String> GameOfWhales.DeviceInfo::TokenReceived
	Action_1_t1831019615 * ___TokenReceived_4;
	// System.Collections.Generic.Queue`1<GameOfWhales.DeviceInfo/DialogRequests> GameOfWhales.DeviceInfo::_dialogResponsesQueue
	Queue_1_t24219257 * ____dialogResponsesQueue_5;
	// System.Collections.Generic.List`1<System.String> GameOfWhales.DeviceInfo::_dialogPushIds
	List_1_t1398341365 * ____dialogPushIds_6;
	// GameOfWhales.DeviceInfo/DialogRequests GameOfWhales.DeviceInfo::_currentDialogRequest
	DialogRequests_t204562422 * ____currentDialogRequest_7;
	// System.String GameOfWhales.DeviceInfo::<token>k__BackingField
	String_t* ___U3CtokenU3Ek__BackingField_8;

public:
	inline static int32_t get_offset_of_NotificationRecieved_2() { return static_cast<int32_t>(offsetof(DeviceInfo_t3954376236, ___NotificationRecieved_2)); }
	inline Action_1_t1694514227 * get_NotificationRecieved_2() const { return ___NotificationRecieved_2; }
	inline Action_1_t1694514227 ** get_address_of_NotificationRecieved_2() { return &___NotificationRecieved_2; }
	inline void set_NotificationRecieved_2(Action_1_t1694514227 * value)
	{
		___NotificationRecieved_2 = value;
		Il2CppCodeGenWriteBarrier(&___NotificationRecieved_2, value);
	}

	inline static int32_t get_offset_of_CurrentNotificationRecieved_3() { return static_cast<int32_t>(offsetof(DeviceInfo_t3954376236, ___CurrentNotificationRecieved_3)); }
	inline Action_1_t2844161962 * get_CurrentNotificationRecieved_3() const { return ___CurrentNotificationRecieved_3; }
	inline Action_1_t2844161962 ** get_address_of_CurrentNotificationRecieved_3() { return &___CurrentNotificationRecieved_3; }
	inline void set_CurrentNotificationRecieved_3(Action_1_t2844161962 * value)
	{
		___CurrentNotificationRecieved_3 = value;
		Il2CppCodeGenWriteBarrier(&___CurrentNotificationRecieved_3, value);
	}

	inline static int32_t get_offset_of_TokenReceived_4() { return static_cast<int32_t>(offsetof(DeviceInfo_t3954376236, ___TokenReceived_4)); }
	inline Action_1_t1831019615 * get_TokenReceived_4() const { return ___TokenReceived_4; }
	inline Action_1_t1831019615 ** get_address_of_TokenReceived_4() { return &___TokenReceived_4; }
	inline void set_TokenReceived_4(Action_1_t1831019615 * value)
	{
		___TokenReceived_4 = value;
		Il2CppCodeGenWriteBarrier(&___TokenReceived_4, value);
	}

	inline static int32_t get_offset_of__dialogResponsesQueue_5() { return static_cast<int32_t>(offsetof(DeviceInfo_t3954376236, ____dialogResponsesQueue_5)); }
	inline Queue_1_t24219257 * get__dialogResponsesQueue_5() const { return ____dialogResponsesQueue_5; }
	inline Queue_1_t24219257 ** get_address_of__dialogResponsesQueue_5() { return &____dialogResponsesQueue_5; }
	inline void set__dialogResponsesQueue_5(Queue_1_t24219257 * value)
	{
		____dialogResponsesQueue_5 = value;
		Il2CppCodeGenWriteBarrier(&____dialogResponsesQueue_5, value);
	}

	inline static int32_t get_offset_of__dialogPushIds_6() { return static_cast<int32_t>(offsetof(DeviceInfo_t3954376236, ____dialogPushIds_6)); }
	inline List_1_t1398341365 * get__dialogPushIds_6() const { return ____dialogPushIds_6; }
	inline List_1_t1398341365 ** get_address_of__dialogPushIds_6() { return &____dialogPushIds_6; }
	inline void set__dialogPushIds_6(List_1_t1398341365 * value)
	{
		____dialogPushIds_6 = value;
		Il2CppCodeGenWriteBarrier(&____dialogPushIds_6, value);
	}

	inline static int32_t get_offset_of__currentDialogRequest_7() { return static_cast<int32_t>(offsetof(DeviceInfo_t3954376236, ____currentDialogRequest_7)); }
	inline DialogRequests_t204562422 * get__currentDialogRequest_7() const { return ____currentDialogRequest_7; }
	inline DialogRequests_t204562422 ** get_address_of__currentDialogRequest_7() { return &____currentDialogRequest_7; }
	inline void set__currentDialogRequest_7(DialogRequests_t204562422 * value)
	{
		____currentDialogRequest_7 = value;
		Il2CppCodeGenWriteBarrier(&____currentDialogRequest_7, value);
	}

	inline static int32_t get_offset_of_U3CtokenU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(DeviceInfo_t3954376236, ___U3CtokenU3Ek__BackingField_8)); }
	inline String_t* get_U3CtokenU3Ek__BackingField_8() const { return ___U3CtokenU3Ek__BackingField_8; }
	inline String_t** get_address_of_U3CtokenU3Ek__BackingField_8() { return &___U3CtokenU3Ek__BackingField_8; }
	inline void set_U3CtokenU3Ek__BackingField_8(String_t* value)
	{
		___U3CtokenU3Ek__BackingField_8 = value;
		Il2CppCodeGenWriteBarrier(&___U3CtokenU3Ek__BackingField_8, value);
	}
};

struct DeviceInfo_t3954376236_StaticFields
{
public:
	// System.Func`2<System.Collections.Generic.Dictionary`2<System.String,System.Object>,GameOfWhales.GowNotification> GameOfWhales.DeviceInfo::<>f__am$cache0
	Func_2_t1667507972 * ___U3CU3Ef__amU24cache0_9;

public:
	inline static int32_t get_offset_of_U3CU3Ef__amU24cache0_9() { return static_cast<int32_t>(offsetof(DeviceInfo_t3954376236_StaticFields, ___U3CU3Ef__amU24cache0_9)); }
	inline Func_2_t1667507972 * get_U3CU3Ef__amU24cache0_9() const { return ___U3CU3Ef__amU24cache0_9; }
	inline Func_2_t1667507972 ** get_address_of_U3CU3Ef__amU24cache0_9() { return &___U3CU3Ef__amU24cache0_9; }
	inline void set_U3CU3Ef__amU24cache0_9(Func_2_t1667507972 * value)
	{
		___U3CU3Ef__amU24cache0_9 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__amU24cache0_9, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
