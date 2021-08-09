using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text cashName;
    public Text cashAmount;
    public RawImage image;


    private void Start()
    {
        image.texture = LoadImage(Application.streamingAssetsPath + "/ClickIcon/Icon.png", 128, 128);
    }


    public void UpdateCashName(string value)
    {
        cashName.text = value;
    }

    public void UpdateCashAmount(float amount)
    {
        cashAmount.text = amount.ToString("C");
    }


    public Texture2D LoadImage(string filePath, int width, int height)
    {
        Texture2D tex = null; // Set to null so that we can return tex later
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(width, height);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }

}
