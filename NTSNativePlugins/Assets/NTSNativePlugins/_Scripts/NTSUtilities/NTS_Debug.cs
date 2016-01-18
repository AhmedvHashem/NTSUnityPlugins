using UnityEngine;
using System.Collections;

public class NTS_Debug : NTS_Singleton<NTS_Debug>
{
    static Vector2 scrollPosition = Vector2.zero;
   
    static string innerText = "";

    public bool showLog;

    void Awake()
    {
        Instance();
    }

    void OnGUI()
    {
        if (!showLog)
            return;

        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(Screen.height), GUILayout.MaxWidth(Screen.width));
        GUILayout.Box(innerText, new GUIStyle() { alignment = TextAnchor.UpperLeft, fontStyle = FontStyle.Bold }, GUILayout.ExpandHeight(true));
        GUILayout.EndScrollView();
    }

    void Update()
    {
        FPSCounter();
        //Log("Unity NTSDebug.Log");

        if (Input.GetKeyDown(KeyCode.Menu))
        {
            showLog = !showLog;
        }
    }

    int frameCount = 0;
    float dt = 0.0f;
    float fps = 0.0f;
    float updateRate = 4.0f;  // 4 updates per sec.
    private void FPSCounter()
    {
        frameCount++;
        dt += Time.deltaTime;
        if (dt > 1.0 / updateRate)
        {
            fps = frameCount / dt;
            frameCount = 0;
            dt -= 1.0f / updateRate;
        }

        if (fps < 40)
        {
            //NTS_Debug.Log("FPS =" + (int)fps);
            //Debug.Log("FPS =" + (int)fps);
        }
    }

    public static void Log(string msg)
    {
        innerText += msg + "\n";

        scrollPosition = new Vector2(scrollPosition.x, Mathf.Infinity);
    }

    public void NativeLog(string msg)
    {
        innerText += msg + "\n";

        scrollPosition = new Vector2(scrollPosition.x, Mathf.Infinity);
    }
}