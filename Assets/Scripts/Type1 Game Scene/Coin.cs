using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.VFX;

public class Coin : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]

    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    private bool isCollected = false;

    private SpriteRenderer visual;

    private void Awake()
    {
        visual = this.GetComponentInChildren<SpriteRenderer>();
    }

    public void LoadData(GameData data)
    {
        data.coinsCollected.TryGetValue(id, out isCollected);
        if (isCollected)
        {
            visual.gameObject.SetActive(false);
        }
    }

    public void SaveData(GameData data) 
    {
        if (data.coinsCollected.ContainsKey(id))
        {
            data.coinsCollected.Remove(id);
        }
        data.coinsCollected.Add(id, isCollected);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected)
        {
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        isCollected = true;
        visual.gameObject.SetActive(false);
    }
}
