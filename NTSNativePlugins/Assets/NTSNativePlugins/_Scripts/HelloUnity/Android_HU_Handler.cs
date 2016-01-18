using UnityEngine;
using System;
using System.Collections;

public class Android_HU_Handler : NTS_Singleton<Android_HU_Handler>
{
    public Action<string> onHelloUnityLoaded = delegate { };

    public void HelloUnity()
    {
        NTSAndroidNative.HelloUnity();
    }
    
    private void OnHelloUnityLoaded(string data)
    {
        onHelloUnityLoaded(data);
    }
}