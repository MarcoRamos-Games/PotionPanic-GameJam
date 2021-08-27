using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanicBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    public Gradient gradient;
    [SerializeField] Image fill = null;

    public void SetMaxPanic(float panic)
    {
        slider.maxValue = panic;
        slider.value = 1;
        gradient.Evaluate(1f);
        fill.color = gradient.Evaluate(0);
    }
    public void SetPanic(float panic)
    {
        slider.value = panic;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


}
