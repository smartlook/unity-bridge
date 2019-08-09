using UnityEngine;

namespace SmartlookUnity {
  public static partial class Smartlook {

    public static void SetupAndStartRecording(string key) { SetupAndStartRecordingInternal(key); }
    static partial void SetupAndStartRecordingInternal(string key);

    public static void SetupAndStartRecording(string key, int frameRate) { SetupAndStartRecordingInternal(key, frameRate); }
    static partial void SetupAndStartRecordingInternal(string key, int frameRate);

    public static void Setup(string key) { SetupInternal(key); }
    static partial void SetupInternal(string key);

    public static void Setup(string key, int frameRate) { SetupInternal(key, frameRate); }
    static partial void SetupInternal(string key, int frameRate);

    public static bool IsRecording() {
            if (Application.platform == RuntimePlatform.Android)
            {
                return getSLClass().CallStatic<bool>("isRecording");
            } else
            {
                return true;
            }
        }

        public static string GetDashboardSessionUrl() {
            if (Application.platform == RuntimePlatform.Android)
            {
                return getSLClass().CallStatic<string>("getDashboardSessionUrl");
            }
            else
            {
                return "";
            }
        }

    public static void StartFullscreenSensitiveMode() { StartFullscreenSensitiveModeInternal(); }
    static partial void StartFullscreenSensitiveModeInternal();

    public static void StopFullscreenSensitiveMode() { StopFullscreenSensitiveModeInternal(); }
    static partial void StopFullscreenSensitiveModeInternal();

    public static void SetReferrer(string referrer, string source) { SetReferrerInternal(referrer, source); }
    static partial void SetReferrerInternal(string referrer, string source);

    public static void Init(string key) { InitInternal(key); }
    static partial void InitInternal(string key);

    public static void Init(string key, int frameRate) { InitInternal(key, frameRate); }
    static partial void InitInternal(string key, int frameRate);

    public static void RecordEvent(string eventName) { RecordEventInternal(eventName); }
    static partial void RecordEventInternal(string eventName);

    public static void RecordEvent(string eventName, string properties) { RecordEventInternal(eventName, properties); }
    static partial void RecordEventInternal(string eventName, string properties);

    public static void TimeEvent(string eventName) { TimeEventInternal(eventName); }
    static partial void TimeEventInternal(string eventName);

    public static void SetUserIdentifier(string userIdentifier) { SetUserIdentifierInternal(userIdentifier); }
    static partial void SetUserIdentifierInternal(string userIdentifier);

    public static void PauseRecording() { PauseRecordingInternal(); }
    static partial void PauseRecordingInternal();

    public static void ResumeRecording() { ResumeRecordingInternal(); }
    static partial void ResumeRecordingInternal();

    public static void StartRecording() { StartRecordingInternal(); }
    static partial void StartRecordingInternal();

    public static void StopRecording() { StopRecordingInternal(); }
    static partial void StopRecordingInternal();
  }
}
