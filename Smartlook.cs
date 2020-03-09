using UnityEngine;

namespace SmartlookUnity {
    public static partial class Smartlook {

        public enum NavigationEventType { enter = 0, exit = 1 }

        // Setup Smartlook and start recording.
        /// <param name="key">The application (project) specific SDK key, available in your Smartlook dashboard.</param>
        public static void SetupAndStartRecording(string key) { SetupAndStartRecordingInternal(key); }

        // Setup Smartlook and start recording, with custom framerate.
        /// <param name="key">The application (project) specific SDK key, available in your Smartlook dashboard.</param>
        /// <param name="frameRate">Custom recording framerate.</param> 
        public static void SetupAndStartRecording(string key, int frameRate) { SetupAndStartRecordingInternal(key, frameRate); }

        // Setup Smartlook. This method initializes Smartlook SDK, but does not start recording. To start recording, call StartRecording() method.
        /// <param name="key">The application (project) specific SDK key, available in your Smartlook dashboard.</param>
        public static void Setup(string key) { SetupInternal(key); }

        // Setup Smartlook. This method initializes Smartlook SDK, but does not start recording. To start recording, call StartRecording() method.
        /// <param name="key">The application (project) specific SDK key, available in your Smartlook dashboard.</param>
        /// <param name="frameRate">Custom recording framerate.</param> 
        public static void Setup(string key, int frameRate) { SetupInternal(key, frameRate); }

        // Starts video and events recording.
        public static void StartRecording() { StartRecordingInternal(); }

        // Stops video and events recording.
        public static void StopRecording() { StopRecordingInternal(); }

        // Current video and events recording state.
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
         public static string StartTimedCustomEvent(string eventName) { return StartTimedCustomEventInternal(eventName); }

         /// <param name="eventId">Name of the event.</param>
         /// <param name="properties">Optional dictionary (json string, obtained for example with JsonUtility.ToJson(param)) with additional information. Non String values will be stringlified.</param>
         public static void StopTimedCustomEvent(string eventId) { StopTimedCustomEventInternal(eventId); }

         /// <param name="eventId">Name of the event.</param>
         /// <param name="properties">Optional dictionary (json string, obtained for example with JsonUtility.ToJson(param)) with additional information. Non String values will be stringlified.</param>
         public static void StopTimedCustomEvent(string eventId, string properties) { StopTimedCustomEventInternal(eventId, properties); }

         /// <param name="eventId">Name of the event.</param>
         /// <param name="reason">Cancellation Reason</param>
         public static void CancelTimedCustomEvent(string eventId, string reason) { CancelTimedCustomEventInternal(eventId, reason); }

         /// <param name="eventId">Name of the event.</param>
         /// <param name="reason">Cancellation Reason</param>
         /// <param name="properties">Optional dictionary (json string, obtained for example with JsonUtility.ToJson(param)) with additional information. Non String values will be stringlified.</param>
         public static void CancelTimedCustomEvent(string eventId, string reason, string properties) { CancelTimedCustomEventInternal(eventId, reason, properties); }

        // Records timestamped custom event.
        /// <param name="eventName">Name that identifies the event.</param>
        public static void TrackCustomEvent(string eventName) { TrackCustomEventInternal(eventName); }

        // Records timestamped custom event with optional properties.
        /// <param name="eventName">Name that identifies the event.</param>
        /// <param name="properties">Optional dictionary (json string, obtained for example with JsonUtility.ToJson(param)) with additional information. Non String values will be stringlified.</param>
        public static void TrackCustomEvent(string eventName, string properties) { TrackCustomEventInternal(eventName, properties); }

        // Records navigation event
        /// <param name="screenName">Name that identifies the screen user is currently on.</param>
        /// <param name="direction">Navigation direction. Either entering the screen, or exiting the screen.</param>
        public static void TrackNavigationEvent(string screenName, NavigationEventType direction) { TrackNavigationEventInternal(screenName, (int)direction); }

        public static void SetGlobalEventProperty(string key, string value, bool immutable) { SetGlobalEventPropertyInternal(key, value, immutable); }

        public static void SetGlobalEventProperties(string properties, bool immutable) { SetGlobalEventPropertiesInternal(properties, immutable); }

        public static void RemoveGlobalEventProperty(string key) { RemoveGlobalEventPropertyInternal(key); }

        public static void RemoveAllGlobalEventProperties() { RemoveAllGlobalEventPropertiesInternal(); }

        // Returns URL leading to the Dashboard player for the current Smartlook session. This URL can be access by everyone with the access rights to the dashboard.
        public static string GetDashboardSessionUrl() { return GetDashboardSessionUrlInternal(); }
        
        // Use this method to enter the **full sensitive mode**. No video is recorded, just analytics events.
        public static void StartFullscreenSensitiveMode() { StartFullscreenSensitiveModeInternal(); }

        // Use this method to leave the **full sensitive mode**. Video is recorded again.
        public static void StopFullscreenSensitiveMode() { StopFullscreenSensitiveModeInternal(); }

        public static void SetReferrer(string referrer, string source) { SetReferrerInternal(referrer, source); }
        
        // Enables/disabled Crashlytics integration
        public static void EnableCrashlytics(bool enable) { EnableCrashlyticsInternal(enable); }


        // Set the app's user identifier.
        /// <param name="userIdentifier">The application-specific user identifier.</param>
         public static void SetUserIdentifier(string userIdentifier) { SetUserIdentifierInternal(userIdentifier); }

         // Set the app's user identifier.
        /// <param name="userIdentifier">The application-specific user identifier.</param>
         /// <param name="properties">Optional dictionary (json string, obtained for example with JsonUtility.ToJson(param)) with additional information. Non String values will be stringlified.</param>
         public static void SetUserIdentifier(string userIdentifier, string properties) { SetUserIdentifierInternal(userIdentifier, properties); }

        // Internal
         static partial void SetupAndStartRecordingInternal(string key);
         static partial void SetupAndStartRecordingInternal(string key, int frameRate);
         static partial void SetupInternal(string key);
         static partial void SetupInternal(string key, int frameRate);
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


         public static bool IsRecordingInternal() {
            #if UNITY_ANDROID            
            if (Application.platform == RuntimePlatform.Android) {
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

        public static string GetDashboardSessionUrlInternal() {
            #if UNITY_ANDROID            
            if (Application.platform == RuntimePlatform.Android) {
                return getSLClass().CallStatic<string>("getDashboardSessionUrl");
            }
            #endif
            
            #if UNITY_IOS
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                return GetDashboardSessionUrlInternalIOS();
            }
            #endif
            return "";
        }

        public static string StartTimedCustomEventInternal(string eventName) {
            #if UNITY_ANDROID            
            if (Application.platform == RuntimePlatform.Android) {
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

        public static string StartTimedCustomEventInternal(string eventName, string properties) {
            #if UNITY_ANDROID            
            if (Application.platform == RuntimePlatform.Android) {
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
    }
}
