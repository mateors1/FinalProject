using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MimosBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fillImage;
    public Image emotionImage; // Aseg�rate de asignar la imagen en el Inspector.
    public Sprite[] emotionSprites; // Array que contiene las tres im�genes de emociones.


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

    public void SetEmotion(int mimo, int maxMimo)
    {
        // Calcula el �ndice de la imagen de emoci�n en funci�n de currentMimo y el n�mero de im�genes disponibles (3).
        int index = Mathf.Clamp(mimo / (maxMimo / 3), 0, 2); // Aseg�rate de que el �ndice est� dentro de los l�mites (0-2).

        // Establece la imagen de emoci�n.
        emotionImage.sprite = emotionSprites[index];
    }
}
