using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class Smartlook
{
    public static AndroidJavaClass SL = null;

    #if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void SmartlookInit(string key);
    #endif

    public static void Init(string key)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookInit(key);
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
    private static extern void SmartlookInitWithFramerate(string key, int framerate);
    #endif

    public static void Init(string key, int framerate)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookInitWithFramerate(key, framerate);
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
    private static extern void SmartlookRecordEvent(string eventName);
    #endif

    public static void RecordEvent(string eventName)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookRecordEvent(eventName);
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
    private static extern void SmartlookRecordEventWithProperties(string eventName, string properties);
    #endif

    public static void RecordEvent(string eventName, string properties)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookRecordEventWithProperties(eventName, properties);
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
    private static extern void SmartlookSetUserIdentifier(string userIdentifier);
    #endif

    public static void SetUserIdentifier(string userIdentifier)
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookSetUserIdentifier(userIdentifier);
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
    private static extern void SmartlookPauseRecording();
    #endif

    public static void PauseRecording()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookPauseRecording();
        }
        else
        {
            getSLClass().CallStatic("pause");
        }
    }

    #if UNITY_IOS
    [DllImport("__Internal")]
    private static extern void SmartlookResumeRecording();
    #endif

    public static void ResumeRecording()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            SmartlookResumeRecording();
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