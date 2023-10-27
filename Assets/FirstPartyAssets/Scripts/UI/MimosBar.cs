using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MimosBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fillImage;

    public void MaxMimos(int maxMimo)
    {
        slider.maxValue = maxMimo;
        slider.value = maxMimo;
        fillImage.color = gradient.Evaluate(1f);
    }

    public void setMimo(int mimo)
    {
        slider.value = mimo;
        fillImage.color= gradient.Evaluate(slider.normalizedValue);
    }
}
