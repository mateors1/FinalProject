using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    [SerializeField] Image fadeImage;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            NextScene();
        }
    }
    // Update is called once per frame
    void OnEnable()
    {
        if (gameObject.name == "SceneManager")
        {
            NextScene();
        }
    }

    public void NextScene()
    {
        if (fadeImage != null) { 
            fadeImage.gameObject.SetActive(true);
            fadeImage.DOFade(0, 2f).OnComplete(() => { fadeImage.gameObject.SetActive(false); });
        }
        Scene escenaActual = SceneManager.GetActiveScene();
        int indiceSiguienteEscena = escenaActual.buildIndex + 1;
        if (indiceSiguienteEscena > 4)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(indiceSiguienteEscena);
        }
    }
}
