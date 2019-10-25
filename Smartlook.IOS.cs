#if UNITY_IOS

namespace SmartlookUnity {
	using System.Runtime.InteropServices;
	using UnityEngine;
	
	public partial class Smartlook {
		
		[DllImport("__Internal")]
		static extern void SmartlookSetupAndStartRecording(string key);
		
		static partial void SetupAndStartRecordingInternal(string key) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookSetupAndStartRecording(key);
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookSetupAndStartRecordingWithFramerate(string key, int frameRate);
		
		static partial void SetupAndStartRecordingInternal(string key, int frameRate) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookSetupAndStartRecordingWithFramerate(key, frameRate);
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookSetup(string key);
		
		static partial void SetupInternal(string key) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookSetup(key);
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookSetupWithFramerate(string key, int frameRate);
		
		static partial void SetupInternal(string key, int frameRate) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookSetupWithFramerate(key, frameRate);
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookStartRecording();
		
		static partial void StartRecordingInternal() {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookStartRecording();
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookStopRecording();
		
		static partial void StopRecordingInternal() {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookStopRecording();
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookStartFullscreenSensitiveMode();
		
		static partial void StartFullscreenSensitiveModeInternal() {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookStartFullscreenSensitiveMode();
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookStopFullscreenSensitiveMode();
		
		static partial void StopFullscreenSensitiveModeInternal() {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookStopFullscreenSensitiveMode();
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookSetReferrer(string referrer, string source);
		
		static partial void SetReferrerInternal(string referrer, string source) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookSetReferrer(referrer, source);
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookInit(string key);
		
		static partial void InitInternal(string key) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookInit(key);
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookInitWithFramerate(string key, int framerate);
		
		static partial void InitInternal(string key, int frameRate) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookInitWithFramerate(key, frameRate);
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookRecordEvent(string eventName);
		
		static partial void RecordEventInternal(string eventName) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookRecordEvent(eventName);
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookRecordEventWithProperties(string eventName, string properties);
		
		static partial void RecordEventInternal(string eventName, string properties) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookRecordEventWithProperties(eventName, properties);
			}
		}

		[DllImport("__Internal")]
		static extern void SmartlookRecordNavigationEvent(string screenName, int direction);
		
		static partial void RecordNavigationEventInternal(string screenName, NavigationEventType direction) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookRecordNavigationEvent(screenName, direction);
			}
		}		

		[DllImport("__Internal")]
		static extern void SmartlookTimeEvent(string eventName);
		
		static partial void TimeEventInternal(string eventName) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookTimeEvent(eventName);
			}
		}

		
		[DllImport("__Internal")]
		static extern void SmartlookSetUserIdentifier(string userIdentifier);
		
		static partial void SetUserIdentifierInternal(string userIdentifier) {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookSetUserIdentifier(userIdentifier);
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookPauseRecording();
		
		static partial void PauseRecordingInternal() {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookPauseRecording();
			}
		}
		
		[DllImport("__Internal")]
		static extern void SmartlookResumeRecording();
		
		static partial void ResumeRecordingInternal() {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				SmartlookResumeRecording();
			}
		}

		[DllImport("__Internal")]
		static extern bool SmartlookIsRecording();

		public static bool IsRecordingInternalIOS() {
			return SmartlookIsRecording();
		}

		[DllImport("__Internal")]
		static extern string SmartlookGetDashboardSessionUrl();

		public static string GetDashboardSessionUrlInternalIOS() {
			return SmartlookGetDashboardSessionUrl();
		}

	}
}

#endif
