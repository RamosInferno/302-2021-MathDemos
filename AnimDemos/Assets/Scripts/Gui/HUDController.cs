using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{

    public static float timeScale = 1;
  
    public TMP_Text textTimeScale;
    public Slider sliderLerp;

    public LerpDemo lerper;

    void Start()
    {
        SliderTimeUpdated(1);
    }

    // Update is called once per frame
    void Update()
    {
        float p = lerper.getCurrentPercent;
        sliderLerp.SetValueWithoutNotify(p);
    }

    public void SliderTimeUpdated(float amt)
    {
        timeScale = amt;
        textTimeScale.text = System.Math.Round(timeScale, 2).ToString();
    }

    public void SliderLerpUpdated(float amt)
    {
        lerper.DotheLerp(amt);
    }
}
