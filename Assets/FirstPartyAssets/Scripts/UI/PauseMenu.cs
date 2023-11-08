using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool pause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        MenuSFX.instance.PlayMenuSound();
        pause = !pause;
        pauseMenu.SetActive(pause);
        if (pause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Resume()
    {
        MenuSFX.instance.PlayMenuSound();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        MenuSFX.instance.PlayMenuSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        MenuSFX.instance.PlayMenuSound();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
