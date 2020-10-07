#if UNITY_IOS

namespace SmartlookUnity {
    using System.Runtime.InteropServices;
    using UnityEngine;
    using System.Collections;
    using AOT;
    
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
        static extern void SmartlookSetupAndStartRecordingWithOptions(string setupOptions);
        
        static partial void SetupAndStartRecordingInternal(SetupOptions setupOptions) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookSetupAndStartRecordingWithOptions(JsonUtility.ToJson(setupOptions));
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
        static extern void SmartlookSetupWithOptions(string setupOptions);
        
        static partial void SetupInternal(SetupOptions setupOptions) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookSetupWithOptions(JsonUtility.ToJson(setupOptions));
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
        static extern void SmartlookTrackCustomEvent(string eventName);
        
        static partial void TrackCustomEventInternal(string eventName) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookTrackCustomEvent(eventName);
            }
        }
        
        [DllImport("__Internal")]
        static extern void SmartlookTrackCustomEventWithProperties(string eventName, string properties);
        
        static partial void TrackCustomEventInternal(string eventName, string properties) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookTrackCustomEventWithProperties(eventName, properties);
            }
        }

        [DllImport("__Internal")]
        static extern void SmartlookTrackNavigationEvent(string screenName, int direction);
        
        static partial void TrackNavigationEventInternal(string screenName, int direction) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookTrackNavigationEvent(screenName, direction);
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
        static extern void SmartlookSetUserIdentifierWithProperties(string userIdentifier, string properties);
        
        static partial void SetUserIdentifierInternal(string userIdentifier, string properties) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookSetUserIdentifierWithProperties(userIdentifier, properties);
            }
        }

        [DllImport("__Internal")]
        static extern bool SmartlookIsRecording();

        public static bool IsRecordingInternalIOS() {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                return SmartlookIsRecording();
            }

            return false;
        }

        [DllImport("__Internal")]
        static extern string SmartlookGetDashboardSessionUrl();

        public static string GetDashboardSessionUrlInternalIOS() {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                return SmartlookGetDashboardSessionUrl();
            }

            return null;
        }

        [DllImport("__Internal")]
        static extern string SmartlookGetDashboardVisitorUrl();

        public static string GetDashboardVisitorUrlInternalIOS() {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                return SmartlookGetDashboardVisitorUrl();
            }

            return null;
        }

        [DllImport("__Internal")]
        static extern void SmartlookEnableCrashlytics(bool enable);

        static partial void EnableCrashlyticsInternal(bool enable) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookEnableCrashlytics(enable);
            }
        }

        [DllImport("__Internal")]
        static extern string SmartlookStartTimedCustomEvent(string eventName);

        public static string StartTimedCustomEventInternalIOS(string eventName) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                return SmartlookStartTimedCustomEvent(eventName);
            }

            return null;
        }

        [DllImport("__Internal")]
        static extern string SmartlookStartTimedCustomEventWithProperties(string eventName, string properties);

        public static string StartTimedCustomEventInternalIOS(string eventName, string properties) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                return SmartlookStartTimedCustomEventWithProperties(eventName, properties);
            }

            return null;
        }

        [DllImport("__Internal")]
        static extern void SmartlookStopTimedCustomEvent(string eventId);

        static partial void StopTimedCustomEventInternal(string eventId) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookStopTimedCustomEvent(eventId);
            }
        }

        [DllImport("__Internal")]
        static extern void SmartlookStopTimedCustomEventWithProperties(string eventId, string properties);

        static partial void StopTimedCustomEventInternal(string eventId, string properties) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookStopTimedCustomEventWithProperties(eventId, properties);
            }
        }

        [DllImport("__Internal")]
        static extern void SmartlookCancelTimedCustomEvent(string eventId, string reason);

        static partial void CancelTimedCustomEventInternal(string eventId, string reason) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookCancelTimedCustomEvent(eventId, reason);
            }
        }

        [DllImport("__Internal")]
        static extern void SmartlookCancelTimedCustomEventWithProperties(string eventId, string reason, string properties);

        static partial void CancelTimedCustomEventInternal(string eventId, string reason, string properties) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookCancelTimedCustomEventWithProperties(eventId, reason, properties);
            }
        }

        [DllImport("__Internal")]
        static extern void SmartlookSetGlobalEventProperty(string key, string value, bool immutable);

        static partial void SetGlobalEventPropertyInternal(string key, string value, bool immutable) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookSetGlobalEventProperty(key, value, immutable);
            }
        }

        [DllImport("__Internal")]
        static extern void SmartlookSetGlobalEventProperties(string properties, bool immutable);

        static partial void SetGlobalEventPropertiesInternal(string properties, bool immutable) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookSetGlobalEventProperties(properties, immutable);
            }
        }

        [DllImport("__Internal")]
        static extern void SmartlookRemoveGlobalEventProperty(string key);

        static partial void RemoveGlobalEventPropertyInternal(string key) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookRemoveGlobalEventProperty(key);
            }
        }

        [DllImport("__Internal")]
        static extern void SmartlookRemoveAllGlobalEventProperties();

        static partial void RemoveAllGlobalEventPropertiesInternal() {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookRemoveAllGlobalEventProperties();
            }
        }

        [DllImport("__Internal")]
        static extern void SmartlookResetSession(bool resetUser);
        
        static partial void ResetSessionInternal(bool resetUser) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookResetSession(resetUser);
            }
        }

        [DllImport("__Internal")]
        static extern void SmartlookSetRenderingMode(int renderingMode);
        
        static partial void SetRenderingModeInternal(int renderingMode) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookSetRenderingMode(renderingMode);
            }
        }

        [DllImport("__Internal")]
        static extern void SmartlookSetEventTrackingMode(string eventTrackingMode);

        static partial void SetEventTrackingModeInternal(string eventTrackingMode)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookSetEventTrackingMode(eventTrackingMode);
            }
        }

        [DllImport("__Internal")]
        static extern void SmartlookSetEventTrackingModes(string eventTrackingModes);

        static partial void SetEventTrackingModesInternal(string eventTrackingModes)
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookSetEventTrackingModes(eventTrackingModes);
            }
        }
        
        private static IntegrationListener privateIntegrationListener;
        private delegate void DelegateMessage(string message);
 
        [MonoPInvokeCallback(typeof(DelegateMessage))] 
        private static void delegateVisitorUrlChanged(string message) {
            privateIntegrationListener.onVisitorReady(message);
        }

        [MonoPInvokeCallback(typeof(DelegateMessage))] 
        private static void delegateSessionUrlChanged(string message) {
            privateIntegrationListener.onSessionReady(message);
        }


        [DllImport("__Internal")]
        static extern void SmartlookSetDashboardSessionUrlListener(DelegateMessage callback);
        [DllImport("__Internal")]
        static extern void SmartlookSetDashboardVisitorUrlListener(DelegateMessage callback);

        public static void RegisterIntegrationListenerInternalIOS(IntegrationListener integrationListener) {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                privateIntegrationListener = integrationListener;

                SmartlookSetDashboardSessionUrlListener(delegateSessionUrlChanged);
                SmartlookSetDashboardVisitorUrlListener(delegateVisitorUrlChanged);
            }
        }

        [DllImport("__Internal")]
        static extern void SmartlookUnregisterDashboardListener();

        static partial void UnregisterIntegrationListenerInternal() {
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                SmartlookUnregisterDashboardListener();
            }
        }
    }
}

#endif
