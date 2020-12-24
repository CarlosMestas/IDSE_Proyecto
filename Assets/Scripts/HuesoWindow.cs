using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuesoWindow : MonoBehaviour
{
    private static HuesoWindow instance;
    private Text huesoText;
    public static int huesoCountFinal = 0;

    private void Awake()
    {
        instance = this;
        huesoText = transform.Find("huesoText").GetComponent<Text>();
        SetHuesoCount(0);
    }

    public static void SetHuesoCount(int huesoCount)
    {
        huesoCountFinal += huesoCount;
        instance.huesoText.text = huesoCountFinal.ToString();
    }

    public static void ResetHuesoCount()
    {
        huesoCountFinal = 0;
    }
}

