using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSoundTrigger : MonoBehaviour
{

    AudioSource audioSource;
    bool canCry = true;
    [SerializeField] int timeBetweenCries =2;
    [SerializeField] AudioClip animalcry;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (canCry)
        {
            StartCoroutine(CanCryAgain());
        }
        
    }

    IEnumerator CanCryAgain()
    {
        if(animalcry != null)
        {
            audioSource.PlayOneShot(animalcry);
        }
        else
        {
            audioSource.Play();
        }
        canCry = false;
        yield return new WaitForSeconds(timeBetweenCries);
        canCry=true;
    }
}
