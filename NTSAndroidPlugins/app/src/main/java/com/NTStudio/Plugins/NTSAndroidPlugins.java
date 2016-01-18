package com.NTStudio.Plugins;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;

import com.unity3d.player.*;

import com.NTStudio.Plugins.NativeGallery.NativeGalleryHandler;
import com.NTStudio.Plugins.PackageInfo.AndroidPackageInfo;
import com.NTStudio.Plugins.Utilities.NTS_Debug;

public class NTSAndroidPlugins extends UnityPlayerActivity
{
    private static NTSAndroidPlugins instance;

    public static NTSAndroidPlugins GetInstance()
    {
        NTS_Debug.Log("Instance");
        return instance;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        instance = this;
    }

    protected void onActivityResult(int requestCode, int resultCode, Intent data)
    {
        NTS_Debug.Log(String.valueOf(requestCode) + "|" + String.valueOf(resultCode));

        if (resultCode != Activity.RESULT_OK || data == null) return;

        try
        {
            try
            {
                if (requestCode == 2)
                    NativeGalleryHandler.GetInstance().onActivityResult(requestCode, resultCode, data);
            }
            catch (Exception e)
            {
                e.printStackTrace();
                NTS_Debug.Log(e.toString());
            }
        }
        catch (NoClassDefFoundError e)
        {
            e.printStackTrace();
            NTS_Debug.Log(e.toString());
        }
    }

    public void LoadAndroidPackageInfo()
    {
        try
        {
            AndroidPackageInfo.GetInstance().LoadPackageInfo();
        }
        catch (Exception e)
        {
            e.printStackTrace();
            NTS_Debug.Log(e.toString());
        }
    }

    public void PickUpImage()
    {
        try
        {
            NativeGalleryHandler.GetInstance().PickUpImage();
        }
        catch (Exception e)
        {
            e.printStackTrace();
            NTS_Debug.Log(e.toString());
        }
    }
}