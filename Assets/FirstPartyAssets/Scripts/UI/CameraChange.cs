using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject cameraA;
    public GameObject cameraB;

    public void DialogueCamera()
    {
        cameraA.SetActive(false);
        cameraB.SetActive(true);
    }

    public void MainCamera()
    {
        cameraA.SetActive(true);
        cameraB.SetActive(false);
    }
}
