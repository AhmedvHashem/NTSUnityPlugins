using UnityEngine;
using System;
using System.Collections;

public class Android_PI_Handler : NTS_Singleton<Android_PI_Handler>
{
    public Action<AndroidPackageInfo> onAndroidPackageInfoLoaded = delegate { };

    private AndroidPackageInfo androidAppInfo = new AndroidPackageInfo();

    public void LoadAndroidPackageInfo()
    {
        NTSAndroidNative.LoadAndroidPackageInfo();
    }

    private void OnAndroidPackageInfoLoaded(string data)
    {
        string[] appData;
        appData = data.Split('|');

        androidAppInfo.versionName = appData[0];
        androidAppInfo.versionCode = appData[1];
        androidAppInfo.packageName = appData[2];
        androidAppInfo.lastUpdateTime = System.Convert.ToInt64(appData[3]);
        androidAppInfo.sharedUserId = appData[3];
        androidAppInfo.sharedUserLabel = appData[4];

        onAndroidPackageInfoLoaded(androidAppInfo);
    }
}