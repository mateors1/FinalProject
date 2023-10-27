using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int ScenesSolved =0;
    public static GameManager instance;
    public int unlockedLevels =1;
    public GameObject[] gameLevels;
    public MimosBarBehaviour mimosBarBehaviour;

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

   private void Update()
    {
        if (mimosBarBehaviour.currentMimo == 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }




}
