using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class Smartlook
{
    [DllImport("__Internal")]
    private static extern void SmartlookUnityBridgeInit(string key);

    public static void Init(string key, int fps)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookUnityBridgeInit(key);
        }
        else
        {
            AndroidJavaClass bridge = new AndroidJavaClass("com.smartlook.sdk.smartlook.Smartlook");
            object[] parameters = new object[2];
            parameters[0] = key;
            parameters[1] = fps;
            bridge.CallStatic("init", parameters);
        }
    }


    [DllImport("__Internal")]
    private static extern void SmartlookUnityBridgeRecordEvent(string eventName);

    public static void RecordEvent(string eventName)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookUnityBridgeRecordEvent(eventName);
        }
        else
        {
            AndroidJavaClass bridge = new AndroidJavaClass("com.smartlook.sdk.smartlook.Smartlook");
            object[] parameters = new object[2];
            parameters[0] = eventName;
            bridge.CallStatic("track", parameters);
        }
    }


    [DllImport("__Internal")]
    private static extern void SmartlookUnityBridgeSetUserIdentifier(string userIdentifier);

    public static void SetUserIdentifier(string userIdentifier)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookUnityBridgeSetUserIdentifier(userIdentifier);
        }
        else
        {
            AndroidJavaClass bridge = new AndroidJavaClass("com.smartlook.sdk.smartlook.Smartlook");
            object[] parameters = new object[2];
            parameters[0] = userIdentifier;
            bridge.CallStatic("identify", parameters);
        }
    }


    [DllImport("__Internal")]
    private static extern void SmartlookUnityBridgePauseRecording();

    public static void PauseRecording()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookUnityBridgePauseRecording();
        }
        else
        {
            AndroidJavaClass bridge = new AndroidJavaClass("com.smartlook.sdk.smartlook.Smartlook");
            bridge.CallStatic("pause");
        }
    }


    [DllImport("__Internal")]
    private static extern void SmartlookUnityBridgeResumeRecording();

    public static void ResumeRecording()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookUnityBridgeResumeRecording();
        }
        else
        {
            AndroidJavaClass bridge = new AndroidJavaClass("com.smartlook.sdk.smartlook.Smartlook");
            bridge.CallStatic("start");
        }
    }


    [DllImport("__Internal")]
    private static extern void SmartlookUnityBridgeConsoleLog(string log);

    public static void Log(string log)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookUnityBridgeConsoleLog(log);
        }
    }
}
