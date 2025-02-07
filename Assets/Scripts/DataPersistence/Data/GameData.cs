using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //public int deathTime;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> coinsCollected;
    public SerializableDictionary<string, Vector3> objects;

    public GameData()
    {
        //deathTime = 0;
        playerPosition = Vector3.zero;
        coinsCollected = new SerializableDictionary<string, bool>();
        objects = new SerializableDictionary<string, Vector3>();
    }


}
