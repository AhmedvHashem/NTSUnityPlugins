using UnityEngine;
using System.Collections;

public class Android_HU : MonoBehaviour
{
    void Start()
    {
        Android_HU_Handler.Instance().onHelloUnityLoaded += OnHelloUnityLoaded;
        Android_HU_Handler.Instance().HelloUnity();
    }

    private void OnHelloUnityLoaded(string msg)
    {
        NTS_Debug.Log(msg);
    }
}
