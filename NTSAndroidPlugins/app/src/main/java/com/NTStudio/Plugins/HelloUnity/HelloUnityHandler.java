package com.NTStudio.Plugins.HelloUnity;

import com.unity3d.player.*;

public class HelloUnityHandler 
{
	public static void HelloUnity()
	{
		UnityPlayer.UnitySendMessage("Android_HU_Handler", "OnHelloUnityLoaded", "Hello Unity, i am String form Java");
	}
}
