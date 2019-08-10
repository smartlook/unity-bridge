using UnityEngine;

namespace SmartlookUnity {
    public static partial class Smartlook {

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

        // Records timestamped custom event.
        /// <param name="eventName">Name that identifies the event.</param>
        public static void RecordEvent(string eventName) { RecordEventInternal(eventName); }

        // Records timestamped custom event with optional properties.
        /// <param name="eventName">Name that identifies the event.</param>
        /// <param name="properties">Optional dictionary (json string, obtained for example with JsonUtility.ToJson(param)) with additional information. Non String values will be stringlified.</param>
        public static void RecordEvent(string eventName, string properties) { RecordEventInternal(eventName, properties); }

        // Returns URL leading to the Dashboard player for the current Smartlook session. This URL can be access by everyone with the access rights to the dashboard.
        public static string GetDashboardSessionUrl() { return GetDashboardSessionUrlInternal(); }

        // Use this method to enter the **full sensitive mode**. No video is recorded, just analytics events.
        public static void StartFullscreenSensitiveMode() { StartFullscreenSensitiveModeInternal(); }

        // Use this method to leave the **full sensitive mode**. Video is recorded again.
        public static void StopFullscreenSensitiveMode() { StopFullscreenSensitiveModeInternal(); }


        public static void SetReferrer(string referrer, string source) { SetReferrerInternal(referrer, source); }

        /**
            Start timer for custom event.
         
            This method does not record an event. It is the subsequent `RecordEvent` call with the same `eventName` that does.

            In the resulting event, the property dictionaries of `start` and `record` are merged (the `record` values override the `start` ones if the key is the same), and a `duration` property is added to them.
         
         @param eventName Name of the event.
         */
         /// <param name="eventName">Name of the event.</param>
         public static void TimeEvent(string eventName) { TimeEventInternal(eventName); }

        // Set the app's user identifier.
        /// <param name="userIdentifier">The application-specific user identifier.</param>
         public static void SetUserIdentifier(string userIdentifier) { SetUserIdentifierInternal(userIdentifier); }


        // Deprecated methods
         public static void Init(string key) { InitInternal(key); }
         public static void Init(string key, int frameRate) { InitInternal(key, frameRate); }
         public static void PauseRecording() { PauseRecordingInternal(); }
         public static void ResumeRecording() { ResumeRecordingInternal(); }
         

        // Internal
         static partial void SetupAndStartRecordingInternal(string key);
         static partial void SetupAndStartRecordingInternal(string key, int frameRate);
         static partial void SetupInternal(string key);
         static partial void SetupInternal(string key, int frameRate);
         static partial void StartRecordingInternal();
         static partial void StopRecordingInternal();
         static partial void RecordEventInternal(string eventName);
         static partial void RecordEventInternal(string eventName, string properties);
         static partial void StartFullscreenSensitiveModeInternal();
         static partial void StopFullscreenSensitiveModeInternal();
         static partial void SetReferrerInternal(string referrer, string source);
         static partial void TimeEventInternal(string eventName);
         static partial void SetUserIdentifierInternal(string userIdentifier);

         static partial void InitInternal(string key);
         static partial void InitInternal(string key, int frameRate);
         static partial void PauseRecordingInternal();
         static partial void ResumeRecordingInternal();


         public static bool IsRecordingInternal() {
#if UNITY_ANDROID            
            if (Application.platform == RuntimePlatform.Android) {
                return getSLClass().CallStatic<bool>("isRecording");
            }
#elif UNITY_IOS
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
#elif UNITY_IOS
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                return GetDashboardSessionUrlInternalIOS();
            }
#endif
            return "";
        }
    }
}
