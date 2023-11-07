using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolliageStreamer : MonoBehaviour
{
    [SerializeField] float timeforAsync = 0.2f;
    [SerializeField] GameObject[] folliageparts;
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(LoadFolliageAsync());
    }

    IEnumerator LoadFolliageAsync()
    {
        foreach (GameObject folliage in folliageparts)
        {
            folliage.SetActive(true);
            yield return new WaitForSeconds(timeforAsync);
        }
    }

}
