using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class NTS_Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;

    public static T Instance()
    {
        //get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType(typeof(T)) as T;

                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<T>();
                    _instance.gameObject.name = _instance.GetType().Name;

                    NTS_Debug.Log("NTS_Singleton : " + _instance.GetType().Name);

                    DontDestroyOnLoad(_instance.gameObject);
                }
            }

            return _instance;
        }
    }

    public static void Dispose()
    {
        _instance = null;
        GameObject.Destroy(_instance);
    }
}
