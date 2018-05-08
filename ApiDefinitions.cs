using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Flic.iOS
{
	// @interface SCLFlicButton : NSObject
	[BaseType (typeof(NSObject))]
    interface SCLFlicButton : INativeObject
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		SCLFlicButtonDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<SCLFlicButtonDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) NSUUID * _Nonnull buttonIdentifier;
		[Export ("buttonIdentifier", ArgumentSemantic.Strong)]
		NSUuid ButtonIdentifier { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull buttonPublicKey;
		[Export ("buttonPublicKey", ArgumentSemantic.Strong)]
		string ButtonPublicKey { get; }

		// @property (readonly, atomic, strong) NSString * _Nonnull name;
		[Export ("name", ArgumentSemantic.Strong)]
		string Name { get; }

		// @property (readonly, atomic, strong) UIColor * _Nonnull color;
		[Export ("color", ArgumentSemantic.Strong)]
		UIColor Color { get; }

		// @property (readonly, atomic, strong) NSString * _Nonnull userAssignedName;
		[Export ("userAssignedName", ArgumentSemantic.Strong)]
		string UserAssignedName { get; }

		// @property (readonly, atomic) SCLFlicButtonConnectionState connectionState;
		[Export ("connectionState")]
		SCLFlicButtonConnectionState ConnectionState { get; }

		// @property (readwrite, nonatomic) BOOL lowLatency;
		[Export ("lowLatency")]
		bool LowLatency { get; set; }

		// @property (readwrite, nonatomic) SCLFlicButtonTriggerBehavior triggerBehavior;
		[Export ("triggerBehavior", ArgumentSemantic.Assign)]
		SCLFlicButtonTriggerBehavior TriggerBehavior { get; set; }

		// @property (readonly, nonatomic) int pressCount;
		[Export ("pressCount")]
		int PressCount { get; }

		// @property (readonly) BOOL isReady;
		[Export ("isReady")]
		bool IsReady { get; }

		// -(void)connect;
		[Export ("connect")]
		void Connect ();

		// -(void)disconnect;
		[Export ("disconnect")]
		void Disconnect ();

		// -(void)indicateLED:(SCLFlicButtonLEDIndicateCount)count;
		[Export ("indicateLED:")]
		void IndicateLED (SCLFlicButtonLEDIndicateCount count);

		// -(void)readRSSI;
		[Export ("readRSSI")]
		void ReadRSSI ();
	}

	// @protocol SCLFlicButtonDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
    interface SCLFlicButtonDelegate
	{
		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didReceiveButtonDown:(BOOL)queued age:(NSInteger)age;
		[Export ("flicButton:didReceiveButtonDown:age:")]
		void ButtonDown (SCLFlicButton button, bool queued, nint age);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didReceiveButtonUp:(BOOL)queued age:(NSInteger)age;
		[Export ("flicButton:didReceiveButtonUp:age:")]
		void ButtonUp (SCLFlicButton button, bool queued, nint age);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didReceiveButtonClick:(BOOL)queued age:(NSInteger)age;
		[Export ("flicButton:didReceiveButtonClick:age:")]
		void ButtonClick (SCLFlicButton button, bool queued, nint age);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didReceiveButtonDoubleClick:(BOOL)queued age:(NSInteger)age;
		[Export ("flicButton:didReceiveButtonDoubleClick:age:")]
		void ButtonDoubleClick (SCLFlicButton button, bool queued, nint age);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didReceiveButtonHold:(BOOL)queued age:(NSInteger)age;
		[Export ("flicButton:didReceiveButtonHold:age:")]
		void ButtonHold (SCLFlicButton button, bool queued, nint age);

		// @optional -(void)flicButtonDidConnect:(SCLFlicButton * _Nonnull)button;
		[Export ("flicButtonDidConnect:")]
		void ButtonDidConnect (SCLFlicButton button);

		// @optional -(void)flicButtonIsReady:(SCLFlicButton * _Nonnull)button;
		[Export ("flicButtonIsReady:")]
		void ButtonIsReady (SCLFlicButton button);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didDisconnectWithError:(NSError * _Nullable)error;
		[Export ("flicButton:didDisconnectWithError:")]
		void ButtonDidDisconnectWithError (SCLFlicButton button, [NullAllowed] NSError error);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didFailToConnectWithError:(NSError * _Nullable)error;
		[Export ("flicButton:didFailToConnectWithError:")]
		void ButtonFailedToConnect (SCLFlicButton button, [NullAllowed] NSError error);

		// @optional -(void)flicButton:(SCLFlicButton * _Nonnull)button didUpdateRSSI:(NSNumber * _Nonnull)RSSI error:(NSError * _Nullable)error;
		[Export ("flicButton:didUpdateRSSI:error:")]
		void Button (SCLFlicButton button, NSNumber RSSI, [NullAllowed] NSError error);
	}

	// @interface SCLFlicManager : NSObject
	[BaseType (typeof(NSObject))]
	interface SCLFlicManager
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		SCLFlicManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<SCLFlicManagerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakDefaultButtonDelegate")]
		[NullAllowed]
		SCLFlicButtonDelegate DefaultButtonDelegate { get; set; }

		// @property (nonatomic, weak) id<SCLFlicButtonDelegate> _Nullable defaultButtonDelegate;
		[NullAllowed, Export ("defaultButtonDelegate", ArgumentSemantic.Weak)]
		NSObject WeakDefaultButtonDelegate { get; set; }

		// @property (readonly, nonatomic) SCLFlicManagerBluetoothState bluetoothState;
		[Export ("bluetoothState")]
		SCLFlicManagerBluetoothState BluetoothState { get; }

		// @property (readonly, getter = isEnabled) BOOL enabled;
		[Export ("enabled")]
		bool Enabled { [Bind ("isEnabled")] get; }

		// +(instancetype _Nullable)sharedManager;
		[Static]
		[Export ("sharedManager")]
		[return: NullAllowed]
		SCLFlicManager SharedManager ();

		// +(instancetype _Nullable)configureWithDelegate:(id<SCLFlicManagerDelegate> _Nullable)delegate defaultButtonDelegate:(id<SCLFlicButtonDelegate> _Nullable)buttonDelegate appID:(NSString * _Nonnull)appID appSecret:(NSString * _Nonnull)appSecret backgroundExecution:(BOOL)bExecution;
		[Static]
		[Export ("configureWithDelegate:defaultButtonDelegate:appID:appSecret:backgroundExecution:")]
		[return: NullAllowed]
		SCLFlicManager ConfigureWithDelegate ([NullAllowed] SCLFlicManagerDelegate @delegate, [NullAllowed] SCLFlicButtonDelegate buttonDelegate, string appID, string appSecret, bool bExecution);

        // -(NSDictionary<NSUuid *,SCLFlicButton *> * _Nonnull)knownButtons;
        [Export("knownButtons")]
        NSDictionary<NSUuid, SCLFlicButton> getKnownButtons { get; }

		// -(void)forgetButton:(SCLFlicButton * _Nonnull)button;
		[Export ("forgetButton:")]
		void ForgetButton (SCLFlicButton button);

		// -(void)disable;
		[Export ("disable")]
		void Disable ();

		// -(void)enable;
		[Export ("enable")]
		void Enable ();

		// -(void)grabFlicFromFlicAppWithCallbackUrlScheme:(NSString * _Nonnull)scheme;
		[Export ("grabFlicFromFlicAppWithCallbackUrlScheme:")]
		void GrabFlicFromFlicAppWithCallbackUrlScheme (string scheme);

		// -(BOOL)handleOpenURL:(NSURL * _Nonnull)url;
		[Export ("handleOpenURL:")]
		bool HandleOpenURL (NSUrl url);

		// -(void)onLocationChange;
		[Export ("onLocationChange")]
		void OnLocationChange ();
	}

	// @protocol SCLFlicManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
    interface SCLFlicManagerDelegate
	{
		// @required -(void)flicManager:(SCLFlicManager * _Nonnull)manager didGrabFlicButton:(SCLFlicButton * _Nullable)button withError:(NSError * _Nullable)error;
		[Abstract]
		[Export ("flicManager:didGrabFlicButton:withError:")]
		void DidGrabFlicButton (SCLFlicManager manager, [NullAllowed] SCLFlicButton button, [NullAllowed] NSError error);

		// @optional -(void)flicManager:(SCLFlicManager * _Nonnull)manager didChangeBluetoothState:(SCLFlicManagerBluetoothState)state;
		[Export ("flicManager:didChangeBluetoothState:")]
		void ChangeBluetoothState (SCLFlicManager manager, SCLFlicManagerBluetoothState state);

		// @optional -(void)flicManagerDidRestoreState:(SCLFlicManager * _Nonnull)manager;
		[Export ("flicManagerDidRestoreState:")]
		void DidRestoreState (SCLFlicManager manager);

		// @optional -(void)flicManager:(SCLFlicManager * _Nonnull)manager didForgetButton:(NSUUID * _Nonnull)buttonIdentifier error:(NSError * _Nullable)error;
		[Export ("flicManager:didForgetButton:error:")]
		void DidForgetButton (SCLFlicManager manager, NSUuid buttonIdentifier, [NullAllowed] NSError error);
	}

	[Static]
	partial interface Constants
	{
		// extern double fliclibVersionNumber;
		[Field ("fliclibVersionNumber", "__Internal")]
		double fliclibVersionNumber { get; }

		// extern const unsigned char [] fliclibVersionString;
		[Field ("fliclibVersionString", "__Internal")]
        IntPtr fliclibVersionString { get; }
	}
}
