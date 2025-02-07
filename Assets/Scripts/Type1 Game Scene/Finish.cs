using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{

    [SerializeField] private AudioSource finishSFX;
    [SerializeField] private Text coinCount = null;

    [SerializeField] private GameObject finishUI = null;

    [SerializeField] private DataPersistenceManager dpManager = null;
    private int coinTotal = 0;

    //private int currentStage = 0;

    private void Start()
    {
        PlayerPrefs.SetInt("currentStage", SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (finishUI != null)
        {
            PressToCont();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            finishSFX.Play();
            CompleteStage();
        }
    }

    private void CompleteStage()
    {
        PlayerPrefs.SetInt("unlockStage", PlayerPrefs.GetInt("currentStage"));
        //SetCurrentStage();
        FinishStage();
        if(dpManager!= null)
        {
            dpManager.DeleteData();
        }
        //yield return new WaitForSeconds(1.5f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (coinCount != null)
        {
            LoadCoin();
            coinTotal = int.Parse(coinCount.text) + PlayerPrefs.GetInt("saveCoinTotal");
            SaveCoinTotal(coinTotal);
        }
    }

    public void SaveCoinTotal(int coinTotal)
    {
        PlayerPrefs.SetInt("saveCoinTotal", coinTotal);
    }

    public void LoadCoin()
    {
        coinCount.text = PlayerPrefs.GetInt("saveCoin").ToString();
    }

    public void LoadCoinTotal()
    {
        coinCount.text = PlayerPrefs.GetInt("saveCoinTotal").ToString();
    }

    public void DeleteCoinTotal()
    {
        PlayerPrefs.DeleteKey("saveCoinTotal");
    }

    //public void SetCurrentStage()
    //{
    //    currentStage++;
    //    PlayerPrefs.SetInt("currentStage", currentStage);
    //}

    public void FinishStage()
    {
        finishUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void PressToCont()
    {
        if (Input.anyKeyDown && finishUI.activeSelf == true)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
    }
}
