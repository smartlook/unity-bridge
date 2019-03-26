using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class Smartlook
{
    public static AndroidJavaClass SL = null;

    #if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void SmartlookUnityBridgeInit(string key);
    #endif

    public static void Init(string key)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookUnityBridgeInit(key);
        }
        else
        {
            object[] parameters = new object[1];
            parameters[0] = key;
            getSLClass().CallStatic("init", parameters);
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void SmartlookUnityBridgeInitWithFramerate(string key, int framerate);
    #endif

    public static void Init(string key, int framerate)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookUnityBridgeInitWithFramerate(key, framerate);
        }
        else
        {
            object[] parameters = new object[2];
            parameters[0] = key;
            parameters[1] = framerate;
            getSLClass().CallStatic("init", parameters);
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void SmartlookUnityBridgeRecordEvent(string eventName);
    #endif

    public static void RecordEvent(string eventName)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookUnityBridgeRecordEvent(eventName);
        }
        else
        {
            object[] parameters = new object[1];
            parameters[0] = eventName;
            getSLClass().CallStatic("track", parameters);
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void SmartlookUnityBridgeRecordEventWithProperties(string eventName, string properties);
    #endif

    public static void RecordEvent(string eventName, string properties)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookUnityBridgeRecordEventWithProperties(eventName, properties);
        }
        else
        {
            object[] parameters = new object[2];
            parameters[0] = eventName;
            parameters[1] = properties;
            getSLClass().CallStatic("track", parameters);
        }
    }

    public static void TimeEvent(string eventName)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {

        }
        else
        {
            object[] parameters = new object[1];
            parameters[0] = eventName;
            getSLClass().CallStatic("timeEvent", parameters);
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void SmartlookUnityBridgeSetUserIdentifier(string userIdentifier);
    #endif

    public static void SetUserIdentifier(string userIdentifier)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookUnityBridgeSetUserIdentifier(userIdentifier);
        }
        else
        {
            object[] parameters = new object[1];
            parameters[0] = userIdentifier;
            getSLClass().CallStatic("identify", parameters);
        }
    }


    #if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void SmartlookUnityBridgePauseRecording();
    #endif

    public static void PauseRecording()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookUnityBridgePauseRecording();
        }
        else
        {
            getSLClass().CallStatic("pause");
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void SmartlookUnityBridgeResumeRecording();
    #endif

    public static void ResumeRecording()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookUnityBridgeResumeRecording();
        }
        else
        {
            getSLClass().CallStatic("start");
        }
    }

    private static AndroidJavaClass getSLClass()
    {
        if (Smartlook.SL != null) {
            return Smartlook.SL;
        }
        Smartlook.SL = new AndroidJavaClass("com.smartlook.sdk.smartlook.Smartlook");
        return Smartlook.SL;
    }
}