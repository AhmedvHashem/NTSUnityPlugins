package com.NTStudio.Plugins.PackageInfo;

import android.content.pm.PackageInfo;
import android.content.pm.PackageManager.NameNotFoundException;

import com.NTStudio.Plugins.NTSAndroidPlugins;
import com.NTStudio.Plugins.Utilities.NTS_Debug;
import com.unity3d.player.UnityPlayer;

public class AndroidPackageInfo 
{
	private static AndroidPackageInfo instance;
	
	public static AndroidPackageInfo GetInstance()
	{
		if(instance == null)
			instance = new AndroidPackageInfo();
		
		return instance;
	}
	public void LoadPackageInfo()
	{
		PackageInfo pInfo;
		try 
		{
			pInfo = NTSAndroidPlugins.GetInstance().getPackageManager().getPackageInfo(NTSAndroidPlugins.GetInstance().getPackageName(), 0);
			StringBuilder result = new StringBuilder();
			result.append(pInfo.versionName);
			result.append("|");
			result.append(pInfo.versionCode);
			result.append("|");
			result.append(pInfo.packageName);
			result.append("|");
			result.append(pInfo.lastUpdateTime);
			result.append("|");
			result.append(pInfo.sharedUserId);
			result.append("|");
			result.append(pInfo.sharedUserLabel);
			
			UnityPlayer.UnitySendMessage("Android_PI_Handler", "OnAndroidPackageInfoLoaded", result.toString());
		}
		catch (NameNotFoundException e) 
		{
			NTS_Debug.Log(e.toString());
			e.printStackTrace();
		}
	}
}
