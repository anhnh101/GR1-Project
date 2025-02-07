using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawn : MonoBehaviour
{

    public GameObject arrow;
    public float spawnRate = 2f;
    private float timer = 0;
    public GameObject gObject = null;


    // Start is called before the first frame update
    private void Start()
    {
        //SpawnArrow();
    }

    // Update is called once per frame
    private void Update()
    {
        if (gObject != null)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnArrow();
                timer = 0;

            }
        }
    }

    private void SpawnArrow()
    {
        Instantiate(arrow, transform.position, transform.rotation, transform.parent);
    }
}
