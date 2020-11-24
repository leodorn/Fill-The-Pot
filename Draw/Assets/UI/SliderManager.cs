using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public static SliderManager instance;
    Slider sliderLine,sliderWater;
    Image fillLine,fillWater;
    [SerializeField]
    Gradient gradientLine;
    private void Awake()
    {
        if(instance ==null)
        {
            instance = this;
        }
        sliderLine = GameObject.Find("LineBar").GetComponent<Slider>();
        sliderWater = GameObject.Find("WaterBar").GetComponent<Slider>();
        fillLine = GameObject.Find("FillLineImage").GetComponent<Image>();
        fillWater = GameObject.Find("FillWaterImage").GetComponent<Image>();

    }

    private void Start()
    {
        PlayerScript player = GameObject.Find("Player").GetComponent<PlayerScript>();
        sliderLine.maxValue = DrawManager.instance.amountLine;
        sliderLine.minValue = 0;
        SetSliderLine(DrawManager.instance.amountLine);
        sliderWater.maxValue = player.totalWater;
        sliderWater.minValue = 0;
        SetSliderWater(player.totalWater);
    }

    public void SetSliderLine(float value)
    {
        sliderLine.value = value;
        fillLine.color = gradientLine.Evaluate(sliderLine.normalizedValue);
    }

    public void SetSliderWater(int value)
    {
        sliderWater.value = value;
    }


}
