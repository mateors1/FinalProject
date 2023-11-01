using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MimosBarBehaviour : MonoBehaviour
{
    public int maxMimo;
    public int currentMimo;
    private int deterioration = 1;
    public MimosBar mimoBar;
    private float timeStep = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        currentMimo = maxMimo;
        mimoBar.MaxMimos(maxMimo);
        
        InvokeRepeating("MimoDeterioration", 0.5f, timeStep);

   
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MimoDeterioration()
    {
        if (currentMimo > 0)
        {
            currentMimo -= deterioration;
            mimoBar.setMimo(currentMimo);
            mimoBar.SetEmotion(currentMimo, maxMimo);
        }

    }

}
