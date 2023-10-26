using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int ScenesSolved;
    public static GameManager instance;
    public int unlockedLevels =2;
    public GameObject[] gameLevels;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
        
    }



   
}
