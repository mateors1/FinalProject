using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MimosBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fillImage;
    public Image emotionImage; // Asegúrate de asignar la imagen en el Inspector.
    public Sprite[] emotionSprites; // Array que contiene las tres imágenes de emociones.


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
        // Calcula el índice de la imagen de emoción en función de currentMimo y el número de imágenes disponibles (3).
        int index = Mathf.Clamp(mimo / (maxMimo / 3), 0, 2); // Asegúrate de que el índice esté dentro de los límites (0-2).

        // Establece la imagen de emoción.
        emotionImage.sprite = emotionSprites[index];
    }
}
