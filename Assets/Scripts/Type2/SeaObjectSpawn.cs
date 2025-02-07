using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SeaObjectSpawn : MonoBehaviour
{

    public GameObject seaObject;
    public float spawnRate = 2f;
    public float highestPos = 5;
    public float lowestPos = 0;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObject();
            timer = 0;

        }
    }

   private void SpawnObject()
    {
        Instantiate(seaObject, new Vector3(transform.position.x ,Random.Range(lowestPos, highestPos), 0) + transform.position, transform.rotation, transform.parent);
    }
}
