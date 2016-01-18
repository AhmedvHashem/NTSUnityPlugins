using UnityEngine;
using System.Collections;
using System;

public class Android_NG_Handler : NTS_Singleton<Android_NG_Handler>
{
    public Action<string, Texture2D> onImageLoaded = delegate { };

    public void PickUpImage()
    {
        NTSAndroidNative.PickUpImage();
    }

    private void OnImageLoaded(string result)
    {
        string[] date = result.Split('|');
        string imgPath = date[0];
        string imgData = date[1];

        try
        {
            Texture2D _image = new Texture2D(1, 1, TextureFormat.DXT5, false);
            if (imgData.Length > 0)
            {
                byte[] decodedFromBase64 = System.Convert.FromBase64String(imgData);
                _image.LoadImage(decodedFromBase64);
            }
            onImageLoaded(imgPath, _image);
        }
        catch(Exception e)
        {
            NTS_Debug.Log(e.ToString());
        }
    }
}