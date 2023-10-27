using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (currentMimo >= 0)
        {
            InvokeRepeating("MimoDeterioration", 0.5f, timeStep);

        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void MimoDeterioration()
    {
        currentMimo -= deterioration;
        mimoBar.setMimo(currentMimo);
    }

}
