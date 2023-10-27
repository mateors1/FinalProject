using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBetweenScenes : MonoBehaviour
{
    private MusicBetweenScenes instace;
    public MusicBetweenScenes Instance
    {
        get
        {
            return instace;
        }
    }

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        if (instace != null && instace != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instace = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}
