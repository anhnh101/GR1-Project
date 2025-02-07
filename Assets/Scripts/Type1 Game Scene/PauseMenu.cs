using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject restartUI;
    public GameObject settingUI;
    public GameObject backToMenuUI;
    public GameObject exitUI;
    public GameObject beginningUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && restartUI.activeSelf == false && settingUI.activeSelf == false && backToMenuUI.activeSelf == false && exitUI.activeSelf == false && beginningUI.activeSelf == false)
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void BackToMenuConfirmation()
    {
        pauseMenuUI.SetActive(false);
        backToMenuUI.SetActive(true);
    }
    public void BackToMenu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }

    public void RestartConfirmation()
    {
        pauseMenuUI.SetActive(false);
        restartUI.SetActive(true);
    }
    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Setting()
    {
        pauseMenuUI.SetActive(false);
        settingUI.SetActive(true);
    }

    public void ExitConfirm()
    {
        pauseMenuUI.SetActive(false);
        exitUI.SetActive(true);
    }
    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void Back()
    {
        restartUI.SetActive(false);
        backToMenuUI.SetActive(false);
        settingUI.SetActive(false);
        exitUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}
