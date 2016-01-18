using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Android_NG : MonoBehaviour
{
    public RawImage image;

    void Start()
    {
        Android_NG_Handler.Instance().onImageLoaded += OnImageLoaded;

        Android_NG_Handler.Instance().PickUpImage();
    }

    private void OnImageLoaded(string imgPath, Texture2D image)
    {
        NTS_Debug.Log("OnGetImage ImagePath=" + imgPath);

        if (image == null)
            return;

        this.image.texture = image;
        this.image.SetNativeSize();
    }
}