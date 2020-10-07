using System;
using UnityEngine;
using System.Collections.Generic;

namespace SmartlookUnity
{

#if UNITY_ANDROID
    /// Extended class can be passed to RegisterIntegrationListener method
    [SL_COMPATIBILITY_NAME("name=IntegrationListener;type=callback;members=onSessionReady,onVisitorReady")]
    public abstract class IntegrationListener : AndroidJavaProxy
    {
        public IntegrationListener() : base("com.smartlook.sdk.smartlook.IntegrationListener") { }

        public abstract void onSessionReady(string dashboardSessionUrl);
        public abstract void onVisitorReady(string dashboardVisitorUrl);
    }
#endif

#if UNITY_IOS
    /// Extended class can be passed to RegisterIntegrationListener method
    public abstract class IntegrationListener
    {
        public abstract void onSessionReady(string dashboardSessionUrl);
        public abstract void onVisitorReady(string dashboardVisitorUrl);
    }
#endif

    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
    public class SL_COMPATIBILITY_NAME : System.Attribute
    {
        private string value;

        public SL_COMPATIBILITY_NAME(string value)
        {
            this.value = value;
        }
    }

    public class SetupOptionsBuilder
    {
        protected string ApiKey { get; set; }
        protected int Fps { get; set; } = 2;
        protected bool StartNewSession { get; set; } = false;
        protected bool StartNewSessionAndUser { get; set; } = false;

        public SetupOptionsBuilder(string ApiKey)
        {
            this.ApiKey = ApiKey;
        }

        public SetupOptionsBuilder SetFps(int Fps)
        {
            this.Fps = Fps;
            return this;
        }

        public SetupOptionsBuilder SetStartNewSession(bool StartNewSession)
        {
            this.StartNewSession = StartNewSession;
            return this;
        }

        public SetupOptionsBuilder SetStartNewSessionAndUser(bool StartNewSessionAndUser)
        {
            this.StartNewSessionAndUser = StartNewSessionAndUser;
            return this;
        }

        public SetupOptions Build()
        {
            return new SetupOptions(ApiKey, Fps, StartNewSession, StartNewSessionAndUser);
        }
    }

    /// Setup options used in SetupAndStartRecording(SetupOptions setupOptions)
    [SL_COMPATIBILITY_NAME("name=SetupOptions;type=builder;members=smartlookAPIKey,fps,startNewSession,startNewSessionAndUser")]
    public class SetupOptions
    {
        public string ApiKey;
        public int Fps;
        public bool StartNewSession;
        public bool StartNewSessionAndUser;

        public SetupOptions(string ApiKey, int Fps, bool StartNewSession, bool StartNewSessionAndUser)
        {
            this.ApiKey = ApiKey;
            this.Fps = Fps;
            this.StartNewSession = StartNewSession;
            this.StartNewSessionAndUser = StartNewSessionAndUser;
        }

    }

    public static partial class Smartlook
    {
        public enum NavigationEventType { enter = 0, exit = 1 }
        public enum RenderingModeType { native = 0, no_rendering = 1 }
        [Serializable]
        public enum EventTrackingMode { FULL_TRACKING, IGNORE_USER_INTERACTION, IGNORE_NAVIGATION_INTERACTION, IGNORE_RAGE_CLICKS, NO_TRACKING }

        [Serializable]
        public class TrackingEventsWrapper
        {
            public List<string> eventTrackingModes;
        }

        /// Setup Smartlook and start recording.
        /// <param name="key">The application (project) specific SDK key, available in your Smartlook dashboard.</param>
        [SL_COMPATIBILITY_NAME("name=setupAndStartRecording;type=func;params=smartlookAPIKey{string}")]
        public static void SetupAndStartRecording(string key) { SetupAndStartRecordingInternal(key); }

        /// Setup Smartlook and start recording, with custom framerate.
        /// <param name="key">The application (project) specific SDK key, available in your Smartlook dashboard.</param>
        /// <param name="frameRate">Custom recording framerate.</param> 
        [SL_COMPATIBILITY_NAME("name=setupAndStartRecording;type=func;params=smartlookAPIKey{string},fps{int};deprecated=yes")]
        public static void SetupAndStartRecording(string key, int frameRate) { SetupAndStartRecordingInternal(key, frameRate); }

        /// Setup Smartlook and start recording with custom setup options.
        /// <param name="setupOptions">Instance of SetupOptions class.</param>
        [SL_COMPATIBILITY_NAME("name=setupAndStartRecording;type=func;params=setupOptions{SetupOptions}")]
        public static void SetupAndStartRecording(SetupOptions setupOptions) { SetupAndStartRecordingInternal(setupOptions); }

        /// Setup Smartlook. This method initializes Smartlook SDK, but does not start recording. To start recording, call StartRecording() method.
        /// <param name="key">The application (project) specific SDK key, available in your Smartlook dashboard.</param>
        [SL_COMPATIBILITY_NAME("name=setup;type=func;params=smartlookAPIKey{string}")]
        public static void Setup(string key) { SetupInternal(key); }

        /// Setup Smartlook. This method initializes Smartlook SDK, but does not start recording. To start recording, call StartRecording() method.
        /// <param name="key">The application (project) specific SDK key, available in your Smartlook dashboard.</param>
        /// <param name="frameRate">Custom recording framerate.</param> 
        [SL_COMPATIBILITY_NAME("name=setup;type=func;params=smartlookAPIKey{string},fps{int};deprecated=yes")]
        public static void Setup(string key, int frameRate) { SetupInternal(key, frameRate); }

        /// Setup Smartlook. This method initializes Smartlook SDK, but does not start recording. To start recording, call StartRecording() method.
        /// <param name="setupOptions">Instance of SetupOptions class.</param>
        [SL_COMPATIBILITY_NAME("name=setup;type=func;params=setupOptions{SetupOptions}")]
        public static void Setup(SetupOptions setupOptions) { SetupInternal(setupOptions); }

        /// Starts video and events recording.
        [SL_COMPATIBILITY_NAME("name=startRecording;type=func")]
        public static void StartRecording() { StartRecordingInternal(); }

        /// Stops video and events recording.
        [SL_COMPATIBILITY_NAME("name=stopRecording;type=func")]
        public static void StopRecording() { StopRecordingInternal(); }

        /// Current video and events recording state.
        [SL_COMPATIBILITY_NAME("name=isRecording;type=func;returns=boolean")]
        public static bool IsRecording() { return IsRecordingInternal(); }

        /// <summary>
        /// Start timer for custom event.
        /// This method does not record an event. It is the subsequent `RecordEvent` call with the same `eventId` that does.
        /// In the resulting event, the property dictionaries of `start` and `record` are merged (the `record` values override the `start` ones if the key is the same), and a `duration` property is added to them.
        /// <summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="properties">Optional dictionary (json string, obtained for example with JsonUtility.ToJson(param)) with additional information. Non String values will be stringlified.</param>
        /// <returns>
        /// eventId that can be used in StopTimedCustomEvent or CancelTimedCustomEvent methods
        /// </returns>
        [SL_COMPATIBILITY_NAME("name=startTimedCustomEvent;type=func;params=eventName{string},eventProperties{JSONObject};returns=string")]
        [SL_COMPATIBILITY_NAME("name=startTimedCustomEvent;type=func;params=eventName{string},bundle{Bundle};returns=string")]
        [SL_COMPATIBILITY_NAME("name=startTimedCustomEvent;type=func;params=eventName{string},eventProperties{string};returns=string")]
        public static string StartTimedCustomEvent(string eventName, string properties) { return StartTimedCustomEventInternal(eventName, properties); }

        /// <summary>
        /// Start timer for custom event.
        /// This method does not record an event. It is the subsequent `RecordEvent` call with the same `eventId` that does.
        /// In the resulting event, the property dictionaries of `start` and `record` are merged (the `record` values override the `start` ones if the key is the same), and a `duration` property is added to them.
        /// <summary>
        /// <param name="eventName">Name of the event.</param>
        /// <returns>
        /// eventId that can be used in StopTimedCustomEvent or CancelTimedCustomEvent methods
        /// </returns>
        /// <param name="eventName">Name of the event.</param>
        [SL_COMPATIBILITY_NAME("name=startTimedCustomEvent;type=func;params=eventName{string};returns=string")]
        public static string StartTimedCustomEvent(string eventName) { return StartTimedCustomEventInternal(eventName); }

        /// Stops timed event
        /// <param name="eventId">Name of the event.</param>
        [SL_COMPATIBILITY_NAME("name=stopTimedCustomEvent;type=func;params=eventId{string}")]
        public static void StopTimedCustomEvent(string eventId) { StopTimedCustomEventInternal(eventId); }

        /// Stops timed event
        /// <param name="eventId">Name of the event.</param>
        /// <param name="properties">Optional dictionary (json string, obtained for example with JsonUtility.ToJson(param)) with additional information. Non String values will be stringlified.</param>
        [SL_COMPATIBILITY_NAME("name=stopTimedCustomEvent;type=func;params=eventId{string},eventProperties{JSONObject}")]
        [SL_COMPATIBILITY_NAME("name=stopTimedCustomEvent;type=func;params=eventId{string},bundle{Bundle}")]
        [SL_COMPATIBILITY_NAME("name=stopTimedCustomEvent;type=func;params=eventId{string},eventProperties{string}")]
        public static void StopTimedCustomEvent(string eventId, string properties) { StopTimedCustomEventInternal(eventId, properties); }

        /// Cancels timed event
        /// <param name="eventId">Name of the event.</param>
        /// <param name="reason">Cancellation Reason</param>
        [SL_COMPATIBILITY_NAME("name=cancelTimedCustomEvent;type=func;params=eventId{string},reason{string}")]
        public static void CancelTimedCustomEvent(string eventId, string reason) { CancelTimedCustomEventInternal(eventId, reason); }

        /// <param name="eventId">Name of the event.</param>
        /// <param name="reason">Cancellation Reason</param>
        /// <param name="properties">Optional dictionary (json string, obtained for example with JsonUtility.ToJson(param)) with additional information. Non String values will be stringlified.</param>
        [SL_COMPATIBILITY_NAME("name=cancelTimedCustomEvent;type=func;params=eventId{string},reason{string},eventProperties{JSONObject}")]
        [SL_COMPATIBILITY_NAME("name=cancelTimedCustomEvent;type=func;params=eventId{string},reason{string},bundle{Bundle}")]
        [SL_COMPATIBILITY_NAME("name=cancelTimedCustomEvent;type=func;params=eventId{string},reason{string},eventProperties{string}")]
        public static void CancelTimedCustomEvent(string eventId, string reason, string properties) { CancelTimedCustomEventInternal(eventId, reason, properties); }

        /// Records timestamped custom event.
        /// <param name="eventName">Name that identifies the event.</param>
        [SL_COMPATIBILITY_NAME("name=trackCustomEvent;type=func;params=eventName{string}")]
        public static void TrackCustomEvent(string eventName) { TrackCustomEventInternal(eventName); }

        /// Records timestamped custom event with optional properties.
        /// <param name="eventName">Name that identifies the event.</param>
        /// <param name="properties">Optional dictionary (json string, obtained for example with JsonUtility.ToJson(param)) with additional information. Non String values will be stringlified.</param>
        [SL_COMPATIBILITY_NAME("name=trackCustomEvent;type=func;params=eventName{string},eventProperties{JSONObject}")]
        [SL_COMPATIBILITY_NAME("name=trackCustomEvent;type=func;params=eventName{string},bundle{Bundle}")]
        [SL_COMPATIBILITY_NAME("name=trackCustomEvent;type=func;params=eventName{string},properties{string}")]
        public static void TrackCustomEvent(string eventName, string properties) { TrackCustomEventInternal(eventName, properties); }

        /// Records navigation event
        /// <param name="screenName">Name that identifies the screen user is currently on.</param>
        /// <param name="direction">Navigation direction. Either entering the screen, or exiting the screen.</param>
        [SL_COMPATIBILITY_NAME("name=trackNavigationEvent;type=func;params=name{string},viewState{ViewState}")]
        public static void TrackNavigationEvent(string screenName, NavigationEventType direction) { TrackNavigationEventInternal(screenName, (int)direction); }

        /// Global event properties are sent with every event.
        /// <param name="key">Property key (name).</param>
        /// <param name="value">Property Value.</param>
        /// <param name="immutable">To change immutable property, you need to remove that property first.</param>
        [SL_COMPATIBILITY_NAME("name=setGlobalEventProperty;type=func;params=key{string},value{string},immutable{boolean}")]
        public static void SetGlobalEventProperty(string key, string value, bool immutable) { SetGlobalEventPropertyInternal(key, value, immutable); }

        /// Global event properties are sent with every event.
        /// <param name="properties">Optional dictionary (json string, obtained for example with JsonUtility.ToJson(param)) with additional information. Non String values will be stringlified.</param>
        /// <param name="immutable">To change immutable property, you need to remove that property first.</param>
        [SL_COMPATIBILITY_NAME("name=setGlobalEventProperties;type=func;params=globalEventProperties{JSONObject},immutable{boolean}")]
        [SL_COMPATIBILITY_NAME("name=setGlobalEventProperties;type=func;params=globalEventProperties{Bundle},immutable{boolean}")]
        [SL_COMPATIBILITY_NAME("name=setGlobalEventProperties;type=func;params=globalEventProperties{string},immutable{boolean}")]
        public static void SetGlobalEventProperties(string properties, bool immutable) { SetGlobalEventPropertiesInternal(properties, immutable); }

        /// Removes global event property
        [SL_COMPATIBILITY_NAME("name=removeGlobalEventProperty;type=func;params=key{string}")]
        public static void RemoveGlobalEventProperty(string key) { RemoveGlobalEventPropertyInternal(key); }

        /// Removes all global event properties
        [SL_COMPATIBILITY_NAME("name=removeAllGlobalEventProperties;type=func")]
        public static void RemoveAllGlobalEventProperties() { RemoveAllGlobalEventPropertiesInternal(); }

        /// Returns URL leading to the Dashboard player for the current Smartlook session. This URL can be access by everyone with the access rights to the dashboard.
        /// <param name="withCurrentTimestamp">If true recording starts at current time</param>
        [SL_COMPATIBILITY_NAME("name=getDashboardSessionUrl;type=func;params=withCurrentTimestamp{boolean};returns=string")]
        public static string GetDashboardSessionUrl(bool withCurrentTimestamp) { return GetDashboardSessionUrlInternal(withCurrentTimestamp); }

        /// Returns URL leading to the Dashboard for current visitor. This URL can be access by everyone with the access rights to the dashboard.
        [SL_COMPATIBILITY_NAME("name=getDashboardVisitorUrl;type=func;returns=string")]
        public static string GetDashboardVisitorUrl() { return GetDashboardVisitorUrlInternal(); }

        /// Use this method to enter the **full sensitive mode**. No video is recorded, just analytics events.
        [SL_COMPATIBILITY_NAME("name=startFullscreenSensitiveMode;type=func;deprecated=yes")]
        public static void StartFullscreenSensitiveMode() { StartFullscreenSensitiveModeInternal(); }

        /// Use this method to leave the **full sensitive mode**. Video is recorded again.
        [SL_COMPATIBILITY_NAME("name=stopFullscreenSensitiveMode;type=func;deprecated=yes")]
        public static void StopFullscreenSensitiveMode() { StopFullscreenSensitiveModeInternal(); }

        [SL_COMPATIBILITY_NAME("name=setReferrer;type=func;params=referrer{string},source{string}")]
        public static void SetReferrer(string referrer, string source) { SetReferrerInternal(referrer, source); }

        /// Enables/disabled Crashlytics integration
        [SL_COMPATIBILITY_NAME("name=enableCrashlytics;type=func;params=enable{boolean}")]
        public static void EnableCrashlytics(bool enable) { EnableCrashlyticsInternal(enable); }

        /// Resets the current session by implicitly starting a new session. Optionally, it also resets the user.
        /// <param name="resetUser">Indicates whether new session starts with new user.</param>
        [SL_COMPATIBILITY_NAME("name=resetSession;type=func;params=resetUser{boolean}")]
        public static void ResetSession(bool resetUser) { ResetSessionInternal(resetUser); }

        /// By changing rendering mode you can adjust the way we render the application for recordings.
        /// <param name="renderingMode">Options are RenderingModeType.native (normal recording), and RenderingModeType.no_rendering (gray screen).</param>
        [SL_COMPATIBILITY_NAME("name=setRenderingMode;type=func;params=renderingMode{RenderingMode}")]
        public static void SetRenderingMode(RenderingModeType renderingMode) { SetRenderingModeInternal((int)renderingMode); }

        /// By changing rendering mode you can adjust the way we render the application for recordings.
        /// <param name="eventTrackingMode">Desired tracking mode.</param>
        [SL_COMPATIBILITY_NAME("name=setEventTrackingMode;type=func;params=eventTrackingMode{EventTrackingMode}")]
        public static void setEventTrackingMode(EventTrackingMode eventTrackingMode) { SetEventTrackingModeInternal(eventTrackingMode.ToString()); }

        /// By changing rendering mode you can adjust the way we render the application for recordings.
        /// <param name="eventTrackingModes">Desired tracking modes.</param>
        [SL_COMPATIBILITY_NAME("name=setEventTrackingModes;type=func;params=eventTrackingModes{List[EventTrackingMode]}")]
        public static void setEventTrackingModes(List<EventTrackingMode> eventTrackingModes) { SetEventTrackingModesInternal(handleEventModes(eventTrackingModes)); }

        private static string handleEventModes(List<EventTrackingMode> modes)
        {
            SmartlookUnity.Smartlook.TrackingEventsWrapper wrapper = new SmartlookUnity.Smartlook.TrackingEventsWrapper() { eventTrackingModes = modes.ConvertAll(mode => mode.ToString()) };
            string input = JsonUtility.ToJson(wrapper);
            string array = "[" + input.Split('[')[1].Split(']')[0] + "]";
            return array;
        }

        /// Set the app's user identifier.
        /// <param name="userIdentifier">The application-specific user identifier.</param>
        [SL_COMPATIBILITY_NAME("name=setUserIdentifier;type=func;params=identifier{string}")]
        public static void SetUserIdentifier(string userIdentifier) { SetUserIdentifierInternal(userIdentifier); }

        /// Set the app's user identifier with additional properties.
        /// <param name="userIdentifier">The application-specific user identifier.</param>
        /// <param name="properties">Optional dictionary (json string, obtained for example with JsonUtility.ToJson(param)) with additional information. Non String values will be stringlified.</param>
        [SL_COMPATIBILITY_NAME("name=setUserProperties;type=func;params=sessionProperties{JSONObject},immutable{boolean}")]
        [SL_COMPATIBILITY_NAME("name=setUserProperties;type=func;params=sessionProperties{Bundle},immutable{boolean}")]
        [SL_COMPATIBILITY_NAME("name=setUserProperties;type=func;params=sessionProperties{string},immutable{boolean}")]
        public static void SetUserIdentifier(string userIdentifier, string properties) { SetUserIdentifierInternal(userIdentifier, properties); }

        /// Set integration listener
        /// <param name="integrationListener">You provide your own subclass of IntegrationListener, with onSessionReady() and onVisitorReady callbacks, which are called when dashboard visitor url or dashboard session url changes.</param>
        [SL_COMPATIBILITY_NAME("name=registerIntegrationListener;type=func;params=integrationListener{IntegrationListener}")]
        public static void RegisterIntegrationListener(IntegrationListener integrationListener) { RegisterIntegrationListenerInternal(integrationListener); }

        /// Unregister integration listener
        [SL_COMPATIBILITY_NAME("name=unregisterIntegrationListener;type=func")]
        public static void UnregisterIntegrationListener() { UnregisterIntegrationListenerInternal(); }


        // Internal
        static partial void SetupAndStartRecordingInternal(string key);
        static partial void SetupAndStartRecordingInternal(string key, int frameRate);
        static partial void SetupAndStartRecordingInternal(SetupOptions setupOptions);
        static partial void SetupInternal(string key);
        static partial void SetupInternal(string key, int frameRate);
        static partial void SetupInternal(SetupOptions setupOptions);
        static partial void StartRecordingInternal();
        static partial void StopRecordingInternal();
        static partial void TrackCustomEventInternal(string eventName);
        static partial void TrackCustomEventInternal(string eventName, string properties);
        static partial void TrackNavigationEventInternal(string screenName, int direction);
        static partial void SetGlobalEventPropertyInternal(string key, string value, bool immutable);
        static partial void SetGlobalEventPropertiesInternal(string properties, bool immutable);
        static partial void RemoveGlobalEventPropertyInternal(string key);
        static partial void RemoveAllGlobalEventPropertiesInternal();
        static partial void StartFullscreenSensitiveModeInternal();
        static partial void StopFullscreenSensitiveModeInternal();
        static partial void SetReferrerInternal(string referrer, string source);
        static partial void EnableCrashlyticsInternal(bool enable);
        static partial void SetUserIdentifierInternal(string userIdentifier);
        static partial void SetUserIdentifierInternal(string userIdentifier, string properties);
        static partial void StopTimedCustomEventInternal(string eventId);
        static partial void StopTimedCustomEventInternal(string eventId, string properties);
        static partial void CancelTimedCustomEventInternal(string eventId, string reason);
        static partial void CancelTimedCustomEventInternal(string eventId, string reason, string properties);
        static partial void ResetSessionInternal(bool resetUser);
        static partial void SetRenderingModeInternal(int renderingMode);
        static partial void SetEventTrackingModeInternal(string eventTrackingMode);
        static partial void SetEventTrackingModesInternal(string eventTrackingModes);
        static partial void UnregisterIntegrationListenerInternal();


        public static bool IsRecordingInternal()
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                return getSLClass().CallStatic<bool>("isRecording");
            }
#endif

#if UNITY_IOS
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                return IsRecordingInternalIOS();
            }
#endif
            return false;
        }

        public static string GetDashboardSessionUrlInternal(bool withCurrentTimestamp)
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                return getSLClass().CallStatic<string>("getDashboardSessionUrl", withCurrentTimestamp);
            }
#endif

#if UNITY_IOS
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                return GetDashboardSessionUrlInternalIOS();
            }
#endif
            return "";
        }

        public static string GetDashboardVisitorUrlInternal()
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                return getSLClass().CallStatic<string>("getDashboardVisitorUrl");
            }
#endif

#if UNITY_IOS
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                return GetDashboardVisitorUrlInternalIOS();
            }
#endif
            return "";
        }

        public static string StartTimedCustomEventInternal(string eventName)
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                return getSLClass().CallStatic<string>("startTimedCustomEvent", eventName);
            }
#endif

#if UNITY_IOS
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                return StartTimedCustomEventInternalIOS(eventName);
            }
#endif
            return "";
        }

        public static string StartTimedCustomEventInternal(string eventName, string properties)
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                return getSLClass().CallStatic<string>("startTimedCustomEvent", eventName, properties);
            }
#endif

#if UNITY_IOS
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                return StartTimedCustomEventInternalIOS(eventName, properties);
            }
#endif
            return "";
        }

        private static void RegisterIntegrationListenerInternal(IntegrationListener integrationListener)
        {
#if UNITY_ANDROID
            if (Application.platform == RuntimePlatform.Android)
            {
                getSLClass().CallStatic("registerIntegrationListener", integrationListener);
            }
#endif

#if UNITY_IOS
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                RegisterIntegrationListenerInternalIOS(integrationListener);
            }
#endif
        }
    }
}
