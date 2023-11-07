using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    public static MenuSFX instance;
    AudioSource m_AudioSource;
    [SerializeField] AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(instance);
      m_AudioSource = GetComponent<AudioSource>();  
     }

    // Update is called once per frame
    public void PlayMenuSound()
    {
            if (m_AudioSource != null)
        {
            m_AudioSource.PlayOneShot(clip);
        }
    }
}
