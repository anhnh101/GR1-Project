using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour, IDataPersistence    
{
    private int coins = 0;
    //private int coinCollected = 0;

    [SerializeField] private Text coinsText = null;
    [SerializeField] private Text coinCount = null;

    [SerializeField] private AudioSource coinsCollectSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coinsCollectSFX.Play();
            Destroy(collision.gameObject);
            coins++;
            coinsText.text = "x " + coins;
            SaveCoin(coins);
        }
    }

    public void LoadData(GameData data)
    {
        
        foreach (KeyValuePair<string, bool> pair in data.coinsCollected)
        {
            if (pair.Value)
            {
                coins++;
                coinsText.text = "x " + coins;
            }
        }
        SaveCoin(coins);
    }

    public void SaveData(GameData data)
    {
        //no data needs to be saved
    }

    public void SaveCoin(int coinCount)
    {
        PlayerPrefs.SetInt("saveCoin", coinCount);
    }

    public void LoadCoin()
    {
        coinCount.text = PlayerPrefs.GetInt("saveCoin").ToString();
    }

    public void DeleteCoin()
    {
        PlayerPrefs.DeleteKey("saveCoin");
    }
}
