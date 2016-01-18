using UnityEngine;
using System.Collections;

public class Android_PI : MonoBehaviour
{
    void Start()
    {
        NTS_Debug.Log("Android_PI : Start");
        Android_PI_Handler.Instance().onAndroidPackageInfoLoaded += OnAndroidPackageInfoLoaded;
        Android_PI_Handler.Instance().LoadAndroidPackageInfo();
    }

    private void OnAndroidPackageInfoLoaded(AndroidPackageInfo AndroidPI)
    {
        string info = AndroidPI.packageName;
        info += "\n";
        info += AndroidPI.versionName;
        info += "\n";
        info += AndroidPI.versionCode;
        info += "\n";
        info += AndroidPI.sharedUserId;
        info += "\n";
        info += AndroidPI.sharedUserLabel;
        info += "\n";
        info += AndroidPI.lastUpdateTime;

        NTS_Debug.Log(info);
    }
}
