#if UNITY_ANDROID
using UnityEngine;

namespace SmartLookUnity {
  public partial class SmartLook {
    static AndroidJavaClass SL;
    
    static AndroidJavaClass getSLClass() {
      if (SL == null) SL = new AndroidJavaClass("com.smartlook.sdk.smartlook.Smartlook");
      return SL;
    }

    static partial void SetupAndStartRecordingInternal(string key) {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("setupAndStartRecording", key);
      }
    }

    static partial void SetupAndStartRecordingInternal(string key, int frameRate) {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("setupAndStartRecording", key, frameRate);
      }
    }

    static partial void SetupInternal(string key) {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("setup", key);
      }
    }

    static partial void SetupInternal(string key, int frameRate) {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("setup", key, frameRate);
      }
    }

    static partial void StartFullscreenSensitiveModeInternal() {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("startFullscreenSensitiveMode");
      }
    }

    static partial void StopFullscreenSensitiveModeInternal() {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("stopFullscreenSensitiveMode");
      }
    }

    static partial void SetReferrerInternal(string referrer, string source) {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("setReferrer", referrer, source);
      }
    }
    
    static partial void InitInternal(string key) {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("init", key);
      }
    }

    static partial void InitInternal(string key, int frameRate) {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("init", key, frameRate);
      }
    }

    static partial void RecordEventInternal(string eventName) {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("track", eventName);
      }
    }

    static partial void RecordEventInternal(string eventName, string properties) {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("track", eventName, properties);
      }
    }

    static partial void TimeEventInternal(string eventName) {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("timeEvent", eventName);
      }
    }

    static partial void SetUserIdentifierInternal(string userIdentifier) {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("identify", userIdentifier);
      }
    }

    static partial void PauseRecordingInternal() {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("pause");
      }
    }

    static partial void ResumeRecordingInternal() {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("start");
      }
    }

    static partial void StartRecordingInternal() {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("startRecording");
      }
    }

    static partial void StopRecordingInternal() {
      if (Application.platform == RuntimePlatform.Android) {
        getSLClass().CallStatic("stopRecording");
      }
    }
  }
}
#endif
