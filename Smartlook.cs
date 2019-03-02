using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class Smartlook
{
    public static AndroidJavaClass SL = null;

    [DllImport("__Internal")]
    private static extern void SmartlookInit(string key);

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

    [DllImport("__Internal")]
    private static extern void SmartlookInitWithFramerate(string key, int framerate);

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


    [DllImport("__Internal")]
    private static extern void SmartlookRecordEvent(string eventName);

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


    [DllImport("__Internal")]
    private static extern void SmartlookRecordEventWithProperties(string eventName, string properties);

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

    [DllImport("__Internal")]
    private static extern void SmartlookSetUserIdentifier(string userIdentifier);

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


    [DllImport("__Internal")]
    private static extern void SmartlookPauseRecording();

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


    [DllImport("__Internal")]
    private static extern void SmartlookResumeRecording();

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