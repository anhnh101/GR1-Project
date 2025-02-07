using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject newGameUI;
    public GameObject settingUI;
    public GameObject helpUI;
    public GameObject exitUI;
    public GameObject selectUI;

    public Button newGameButton = null;
    public Button continueButton = null;

    public Button[] selectButton = null;
    
    
    private int stageIndex;
    private void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("currentStage"));
        //Debug.Log(PlayerPrefs.GetInt("unlockStage"));
        continueButton.interactable = false;
        for (int i = 0; i < selectButton.Length; i++)
        {
            selectButton[i].enabled = false;
        }

        if (PlayerPrefs.HasKey("unlockStage"))
        {
            stageIndex = PlayerPrefs.GetInt("unlockStage");
            UnlockStage(stageIndex);
            if (PlayerPrefs.HasKey("currentStage"))
            {
                continueButton.interactable = true;
            }
            else return;
        }
        else
        {
            if (!PlayerPrefs.HasKey("currentStage"))
            {
                selectButton[0].enabled = true;
                return;
            }
            else
            {
                stageIndex = PlayerPrefs.GetInt("currentStage") - 1;
                continueButton.interactable = true;
                UnlockStage(stageIndex);
            }

        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        DeleteUnlockKey();
    //    }
    //}


    public void Play()
    {
        //stageIndex = 1;
        PlayerPrefs.SetInt("currentStage", SceneManager.GetActiveScene().buildIndex);

        DisableMenuButton();
        //DataPersistenceManager.Instance.NewGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Continue()
    {
        DisableMenuButton();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + PlayerPrefs.GetInt("currentStage"));
    }
    public void Settings()
    {
        mainMenuUI.SetActive(false);
        settingUI.SetActive(true);
    }
    public void Help()
    {
        mainMenuUI.SetActive(false);
        helpUI.SetActive(true);
    }

    public void ExitButton()
    {
        mainMenuUI.SetActive(false);
        exitUI.SetActive(true);
    }

    public void SelectButton()
    {
        mainMenuUI.SetActive(false);
        selectUI.SetActive(true);
    }
    public void Back()
    {
        settingUI.SetActive(false);
        helpUI.SetActive(false);
        exitUI.SetActive(false);
        newGameUI.SetActive(false);
        mainMenuUI.SetActive(true);
        selectUI.SetActive(false);
    }

    public void NewGameButton()
    {
        mainMenuUI.SetActive(false);
        newGameUI.SetActive(true);
    }
        public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void DisableMenuButton()
    {
        newGameButton.interactable = false;
        continueButton.interactable = false;
    }

    public void PlayStage2()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayStage3()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayStage4()
    {
        SceneManager.LoadScene(4);
    }
    public void PlayStage5()
    {
        SceneManager.LoadScene(5);
    }
    public void PlayStage6()
    {
        SceneManager.LoadScene(6);
    }
    public void PlayStage7()
    {
        SceneManager.LoadScene(7);
    }
    public void PlayStage8()
    {
        SceneManager.LoadScene(8);
    }
    public void PlayStage9()
    {
        SceneManager.LoadScene(9);
    }
    public void PlayStage10()
    {
        SceneManager.LoadScene(10);
    }

    private void UnlockStage(int stageIndex)
    {
        for (int i = 0; i < selectButton.Length; i++)
        {
            if (i <= stageIndex)
            {
                selectButton[i].enabled = true;
            }
        }
    }
    
}
