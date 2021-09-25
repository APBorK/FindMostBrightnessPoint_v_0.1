using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WebCamera : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImage;
    [SerializeField] 
    private TextMeshProUGUI _text;

    
    private WebCamTexture _webCamTexture;
    private float _timer = 5;
    void Start()
    {
        _webCamTexture = new WebCamTexture();
        _rawImage.texture = _webCamTexture;
        _rawImage.material.mainTexture = _webCamTexture;
        _webCamTexture.Play();
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            Texture2D photo = TakePhoto();
            if (photo)
            {
                photo.LoadImage(TakePixelsCodes());
                _text.text = Convert.ToString(BrightnessPointSearcher.SearchMostBrightnessPoint(photo)) ;
                Debug.Log(BrightnessPointSearcher.SearchMostBrightnessPoint(photo));
            }
            _timer = 5;
        }
    }
    
    private Texture2D TakePhoto()
    {
        var photo = new Texture2D(_webCamTexture.width, _webCamTexture.height);
        photo.SetPixels(_webCamTexture.GetPixels());
        photo.Apply();
        //это, чтобы сохранить снимок вебки (не обязательно)
        //File.WriteAllBytes("photo.png", TakePixelsCodes());
        
        return photo;
    }
    
    private byte[] TakePixelsCodes()
    {
        return TakePhoto().EncodeToPNG();;
    }
}
