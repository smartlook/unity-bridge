#if UNITY_ANDROID
using UnityEngine;

namespace SmartlookUnity
{
    public partial class Smartlook
    {
        static AndroidJavaClass SL;

        static AndroidJavaClass getSLClass()
        {
            if (SL == null) SL = new AndroidJavaClass("com.smartlook.sdk.smartlook.Smartlook");
            return SL;
        }

        static partial void SetupAndStartRecordingInternal(string key)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("setupAndStartRecording", key);
            }
        }

        static partial void SetupAndStartRecordingInternal(string key, int frameRate)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("setupAndStartRecording", key, frameRate);
            }
        }

        static partial void SetupAndStartRecordingInternal(SetupOptions setupOptions)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("setupAndStartRecordingBridge", JsonUtility.ToJson(setupOptions));
            }
        }

        static partial void SetupInternal(string key)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("setup", key);
            }
        }

        static partial void SetupInternal(string key, int frameRate)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("setup", key, frameRate);
            }
        }

        static partial void SetupInternal(SetupOptions setupOptions)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("setupBridge", JsonUtility.ToJson(setupOptions));
            }
        }

        static partial void StartFullscreenSensitiveModeInternal()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("startFullscreenSensitiveMode");
            }
        }

        static partial void StopFullscreenSensitiveModeInternal()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("stopFullscreenSensitiveMode");
            }
        }

        static partial void SetReferrerInternal(string referrer, string source)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("setReferrer", referrer, source);
            }
        }

        static partial void TrackCustomEventInternal(string eventName)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("trackCustomEvent", eventName);
            }
        }

        static partial void TrackCustomEventInternal(string eventName, string properties)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("trackCustomEvent", eventName, properties);
            }
        }

        static partial void TrackNavigationEventInternal(string screenName, int direction)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                string internalDirection = "start";

                if (direction.Equals(NavigationEventType.exit))
                {
                    internalDirection = "stop";
                }

                getSLClass().CallStatic("trackNavigationEvent", screenName, internalDirection);
            }
        }

        static partial void StopTimedCustomEventInternal(string eventId)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("stopTimedCustomEvent", eventId);
            }
        }

        static partial void StopTimedCustomEventInternal(string eventId, string properties)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("stopTimedCustomEvent", eventId, properties);
            }
        }

        static partial void CancelTimedCustomEventInternal(string eventId, string reason)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("cancelTimedCustomEvent", eventId, reason);
            }
        }

        static partial void CancelTimedCustomEventInternal(string eventId, string reason, string properties)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("cancelTimedCustomEvent", eventId, reason, properties);
            }
        }

        static partial void SetGlobalEventPropertyInternal(string eventName, string eventValue, bool immutable)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("setGlobalEventProperty", eventName, eventValue, immutable);
            }
        }

        static partial void SetGlobalEventPropertiesInternal(string properties, bool immutable)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("setGlobalEventProperties", properties, immutable);
            }
        }

        static partial void RemoveGlobalEventPropertyInternal(string eventName)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("removeGlobalEventProperty", eventName);
            }
        }

        static partial void RemoveAllGlobalEventPropertiesInternal()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("removeAllGlobalEventProperties");
            }
        }

        static partial void SetUserIdentifierInternal(string userIdentifier)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("setUserIdentifier", userIdentifier);
            }
        }

        static partial void SetUserIdentifierInternal(string userIdentifier, string properties)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("setUserIdentifier", userIdentifier);
                getSLClass().CallStatic("setUserProperties", properties, false);
            }
        }

        static partial void StartRecordingInternal()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("startRecording");
            }
        }

        static partial void StopRecordingInternal()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("stopRecording");
            }
        }

        static partial void EnableCrashlyticsInternal(bool enable)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("enableCrashlytics", enable);
            }
        }

        static partial void ResetSessionInternal(bool resetUser)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("resetSession", resetUser);
            }
        }

        static partial void SetRenderingModeInternal(int renderingMode)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                string internalRenderingMode = "native";

                if (renderingMode.Equals(RenderingModeType.no_rendering))
                {
                    internalRenderingMode = "no_rendering";
                }

                getSLClass().CallStatic("setRenderingMode", internalRenderingMode);
            }
        }

        static partial void SetEventTrackingModeInternal(string eventTrackingMode)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("setEventTrackingMode", eventTrackingMode);
            }
        }

        static partial void SetEventTrackingModesInternal(string eventTrackingModes)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("setEventTrackingModes", eventTrackingModes);
            }
        }

        static partial void UnregisterIntegrationListenerInternal()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("unregisterIntegrationListener");
            }
        }
    }
}
#endif
