using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bushes : MonoBehaviour
{
    GameManager gManager;
    AudioSource m_AudioSource;
    [SerializeField] AudioClip bushAudioClip;

    private void Start()
    {
         
       m_AudioSource = GetComponent<AudioSource>();
    
    }

    private void OnTriggerEnter(Collider other)
    {
        
            RumbleBush();
        
   
        
    }
    // Start is called before the first frame update
    void RumbleBush()
    {
        m_AudioSource.clip = bushAudioClip;
        m_AudioSource.Play();

    }

    
}
