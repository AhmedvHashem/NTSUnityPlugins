using UnityEngine;
using System.Runtime.InteropServices;

class NTSiOSNative
{

//#if UNITY_IPHONE || UNITY_XBOX360
//   // On iOS and Xbox 360 plugins are statically linked into
//   // the executable, so we have to use __Internal as the
//   // library name.
//   [DllImport ("__Internal")]
//#else
//    // Other platforms load plugins dynamically, so pass the name
//    // of the plugin's dynamic library.
//    [DllImport("NTSiOS_TestPlugin")]
//#endif

    [DllImport("NTSiOS_TestPlugin")]
    private static extern float NTS_TestPluginFunction();


    public static float TestPluginFunction()
    {
        return NTS_TestPluginFunction();
    }
}