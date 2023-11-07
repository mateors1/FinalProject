using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    [SerializeField] Image fadeImage;
    public void Play()
    {
        Debug.Log("Play");
        fadeImage.gameObject.SetActive(true);
        MenuSFX.instance.PlayMenuSound();
        fadeImage.DOFade(1, 2f).OnComplete(() => { SceneManager.LoadScene(1); });
        
    }

    private void Start()
    {
        fadeImage.gameObject.SetActive(false);
    }
    public void GameQuit()
    {
        MenuSFX.instance.PlayMenuSound();
        Application.Quit();
    }


}
