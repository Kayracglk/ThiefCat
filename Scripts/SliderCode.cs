using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCode : MonoBehaviour
{
    public static SliderCode instance;
    public int count = 0;
    public Slider sliderUi;

    private void Awake()
    {
        instance = this;
    }
}
