using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditSpawn : MonoBehaviour
{
    public GameObject seaObject;
    public float spawnRate = 2f;
    public float highestPos = 8.5f;
    public float lowestPos = -8.5f;
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
        Instantiate(seaObject, new Vector3(Random.Range(lowestPos, highestPos), transform.position.y, 0) + transform.position, transform.rotation, transform.parent);
    }
}
