using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NTSAndroidNative
{
    private const string HELLOUNITY_CLASS = "com.NTStudio.Plugins.HelloUnity.HelloUnityHandler";

    #region PublicMethods

    public static void HelloUnity()
    {
        CallStaticNativeMethod(HELLOUNITY_CLASS, "HelloUnity");
    }
    public static void LoadAndroidPackageInfo()
    {
        CallNativeMethod("LoadAndroidPackageInfo");
    }
    public static void PickUpImage()
    {
        CallNativeMethod("PickUpImage");
    }

    #endregion

    #region NativeMethods
    private static void CallNativeMethod(string methodName, params object[] args)
    {
        AndroidJNIHelper.debug = true; 

#if UNITY_ANDROID
        if (Application.platform != RuntimePlatform.Android)
        {
            return;
        }
        try
        {
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject activity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

            activity.Call("runOnUiThread", new AndroidJavaRunnable(() => { activity.Call(methodName, args); }));
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning(ex.Message);
            NTS_Debug.Log(ex.Message);
        }
#endif
    }

#if UNITY_ANDROID
    private static Dictionary<string, AndroidJavaClass> JavaClasses = new Dictionary<string, AndroidJavaClass>();//classes pool
#endif
    private static void CallStaticNativeMethod(string className, string methodName, params object[] args)
    {
        AndroidJNIHelper.debug = true; 

#if UNITY_ANDROID
        if (Application.platform != RuntimePlatform.Android)
        {
            return;
        }
        try
        {
            AndroidJavaClass JavaClass;
            if (JavaClasses.ContainsKey(className))
            {
                JavaClass = JavaClasses[className];
            }
            else
            {
                JavaClass = new AndroidJavaClass(className);
                JavaClasses.Add(className, JavaClass);
            }

            JavaClass.CallStatic(methodName, args);

            //AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            //AndroidJavaObject activity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

            //activity.Call("runOnUiThread", new AndroidJavaRunnable(() => { JavaClass.CallStatic(methodName, args); }));
        }
        catch (System.Exception ex)
        {
            Debug.LogWarning(ex.Message);
            NTS_Debug.Log(ex.Message);
        }
#endif
    }
    #endregion
}
