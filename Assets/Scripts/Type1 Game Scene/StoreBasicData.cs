using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreBasicData : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    [SerializeField] private Text playerName = null;
    [SerializeField] private Text coinTotal = null;

    
    private void Start()
    {
        if (PlayerPrefs.HasKey("savePlayerName"))
        {
            LoadName();
        }

        if (playerName!= null)
        {
            playerName.text = PlayerPrefs.GetString("savePlayerName");
        }

        if (coinTotal!= null)
        {
            coinTotal.text = $"x {PlayerPrefs.GetInt("saveCoinTotal") + 50}";
        }
     
    }

    public void SetName()
    {
        if (inputField.text == "")
        {
            inputField.text = "No Name";
            SaveName();
        }
        else
        {
            SaveName();
        }
    }
    public void SaveName()
    { 
        PlayerPrefs.SetString("savePlayerName", inputField.text);
    }
    public void LoadName()
    {
        inputField.text = PlayerPrefs.GetString("savePlayerName");
    }

    public void DeteleName()
    {
        PlayerPrefs.DeleteKey("savePlayerName");
    }

    public void DisplayName()
    {
        Debug.Log(PlayerPrefs.GetString("savePlayerName"));
    }

    public void ResetStageIndex()
    {
        PlayerPrefs.DeleteKey("currentStage");
        
    }

    public void BackToMenu()
    {
        ResetStageIndex();
        SceneManager.LoadScene("Menu");
    }

    public void DeleteUnlockKey()
    {
        PlayerPrefs.DeleteKey("unlockStage");
    }
}
