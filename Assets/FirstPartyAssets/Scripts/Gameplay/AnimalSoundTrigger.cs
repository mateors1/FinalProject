using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSoundTrigger : MonoBehaviour
{

    AudioSource audioSource;
    bool canCry = true;
    [SerializeField] int timeBetweenCries =2;
    // Start is called before the first frame update
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
        audioSource.Play();
        canCry = false;
        yield return new WaitForSeconds(timeBetweenCries);
        canCry=true;
    }
}
