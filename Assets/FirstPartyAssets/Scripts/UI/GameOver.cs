using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Restart()
    {
        MenuSFX.instance.PlayMenuSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        MenuSFX.instance.PlayMenuSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
