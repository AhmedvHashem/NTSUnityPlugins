package com.NTStudio.Plugins.Utilities;

import com.unity3d.player.UnityPlayer;

public class NTS_Debug 
{
	public static void Log(String log)
	{
		UnityPlayer.UnitySendMessage("NTS_Debug", "NativeLog", log);
	}
}
