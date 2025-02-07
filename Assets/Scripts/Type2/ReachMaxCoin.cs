using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReachMaxCoin : MonoBehaviour
{
    private int coins = 0;
    public int maxCoins = 25;

    [SerializeField] private Text coinsText;
    [SerializeField] private Text maxCoinsText;

    [SerializeField] private AudioSource coinsCollectSFX;
    [SerializeField] private AudioSource finishSFX;

    [SerializeField] private GameObject finishUI = null;
    
    //private int currentStage = 0;
    private void Awake()
    {
        maxCoinsText.text = "/ " + maxCoins;
    }

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
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinsCollectSFX.Play();
            Destroy(collision.gameObject);
            coins++;
            coinsText.text = "x " + coins;

            if (coins == maxCoins)
            {
                PlayerPrefs.SetInt("unlockStage", PlayerPrefs.GetInt("currentStage"));
                finishSFX.Play();
                //SetCurrentStage();
                FinishStage();
            }
        }
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
