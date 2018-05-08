using System;
using ObjCRuntime;

namespace Flic.iOS
{
	[Native]
    public enum SCLFlicButtonConnectionState : long
	{
		Connected = 0,
		Connecting,
		Disconnected,
		Disconnecting
	}

	[Native]
    public enum SCLFlicButtonLEDIndicateCount : long
	{
		SCLFlicButtonLEDIndicateCount1 = 1,
		SCLFlicButtonLEDIndicateCount2,
		SCLFlicButtonLEDIndicateCount3,
		SCLFlicButtonLEDIndicateCount4,
		SCLFlicButtonLEDIndicateCount5
	}

	[Native]
    public enum SCLFlicButtonTriggerBehavior : long
	{
        AndHold = 0,
        AndDoubleClick,
        AndDoubleClickAndHold,
        SCLFlicButtonTriggerBehaviorClick
	}

	[Native]
    public enum SCLFlicError : long
	{
		Unknown = 0,
		CouldNotCompleteTask = 1,
		ConnectionFailed = 2,
		CouldNotUpdateRSSI = 3,
		ButtonIsPrivate = 10,
		CryptographicFailure = 11,
		MissingData = 13,
		InvalidSignature = 14,
		ButtonAlreadyGrabbed = 15,
		BluetoothErrorUnknown = 100,
		BluetoothErrorInvalidParameters = 101,
		BluetoothErrorInvalidHandle = 102,
		BluetoothErrorNotConnected = 103,
		BluetoothErrorOutOfSpace = 104,
		BluetoothErrorOperationCancelled = 105,
		BluetoothErrorConnectionLost = 106,
		BluetoothErrorPeripheralDisconnected = 107,
		BluetoothErrorUUIDNotAllowed = 108,
		BluetoothErrorAlreadyAdvertising = 109,
		BluetoothErrorConnectionFailed = 110,
		BluetoothErrorConnectionLimitReached = 111,
		FlicRefusedConnection = 200
	}

	[Native]
    public enum SCLFlicManagerBluetoothState : long
	{
		PoweredOn = 0,
		PoweredOff,
		Resetting,
		Unsupported,
		Unauthorized,
		Unknown
	}
}
