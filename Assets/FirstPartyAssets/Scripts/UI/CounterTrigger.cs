using System.Collections;
using System.Collections.Generic;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class CounterTrigger : MonoBehaviour
{
    public Animal[] animalSprite;
    public Image animalImage;
    public TextMeshProUGUI textMeshPro;

    private AnimalNavigation animalNavigation;
    public static CounterTrigger Instance;
    private int animalCounter;
    private string currentAnimal;

    Animal animalToDisplay;

    private void Start()
    {
        Instance = this;
    }

    public void ChangeAnimalSprite(string animalTag)
    {
        if (currentAnimal != animalTag)
        {
            switch (animalTag)
            {
                case "Croc":
                    animalToDisplay = animalSprite[1];
                    break;
                case "Sparrow":
                    animalToDisplay = animalSprite[0];
                    break;
                default:
                    animalToDisplay = null;
                    break;
            }

            animalImage.sprite = animalToDisplay.sprite;
            currentAnimal = animalTag;
            animalCounter = 0;
        }

        animalCounter++;
        textMeshPro.text = $"{animalCounter}";
    }
}

[System.Serializable]
public class Animal
{
    public int animalId;
    public Sprite sprite;
}
