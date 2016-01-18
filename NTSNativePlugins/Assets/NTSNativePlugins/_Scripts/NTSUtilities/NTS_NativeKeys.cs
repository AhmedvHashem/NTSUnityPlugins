using UnityEngine;
using System.Collections;

public class NTS_NativeKeys : NTS_Singleton<NTS_NativeKeys>
{
    void Awake()
    {
        Instance();
    }
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("KeyCode.Escape");
            //NTS_Debug.Log("KeyCode.Escape");

            //Findee.showExit = true;

            Application.Quit();
        }
    }
}
