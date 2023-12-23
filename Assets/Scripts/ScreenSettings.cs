using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSettings : MonoBehaviour
{
    public GameObject pausePanel, inventory, tapEffect;
    public int level;

    public void PauseButtonPressed()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void ContinueButtonPressed()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;

    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }

}
