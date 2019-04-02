namespace SmartLookUnity {
  public static partial class SmartLook {
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
  }
}
