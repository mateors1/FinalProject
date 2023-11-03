using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBalancer : MonoBehaviour
{
    public List<GameObject> levels;
    public static SceneBalancer Instance;

    private void Start()
    {
        Instance = this;
    }


    public void LoadBalanceSCenes(GameObject level)
    {
        levels.Add(level);
        if (levels.Count >= 3)
        {
            levels[0].SetActive(false);
            levels.RemoveAt(0);
        }
    }
}
