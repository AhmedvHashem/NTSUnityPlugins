using System;
using UnityEngine;
using System.Collections;

public class NTS_WWWLoader : MonoBehaviour
{
    private string _url;

    public Action<Texture2D> OnLoad = delegate { };

	void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
	
    public static NTS_WWWLoader Create()
    {
        return new GameObject("NTS_WWWLoader").AddComponent<NTS_WWWLoader>();
    }

    public void LoadTexture(string url)
    {
        _url = url;
        StartCoroutine(LoadCoroutin());
    }

    private IEnumerator LoadCoroutin()
    {
        // Start a download of the given URL
        WWW www = new WWW(_url);

        // Wait for download to complete
        yield return www;

        if (www.error == null)
        {
            Debug.Log("OnLoad Image");
            //dispatch(BaseEvent.LOADED, www.texture);
            OnLoad(www.texture);
        }
        else
        {
            Debug.Log("OnLoad Image Error");
            //dispatch(BaseEvent.LOADED, null);
            OnLoad(null);
        }

        Destroy(gameObject);
    }
}
