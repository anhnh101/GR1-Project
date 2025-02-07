using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossStageSpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject hearts;
    [SerializeField] private GameObject ghosts;
    [SerializeField] private GameObject rocks;
    [SerializeField] private GameObject slimes;
    
    private Vector2 heartSpawnPos;
    private float heartSpawnRate = 4.0f;
    private float slimeSpawnRate = 7.0f;
    private float ghostSpawnRate = 10.0f;
    private float rockSpawnRate = 13.0f;
    private bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("currentStage", SceneManager.GetActiveScene().buildIndex);
        
        StartCoroutine(SpawnHeart());
        StartCoroutine(SpawnSlime());
        StartCoroutine(SpawnGhost());
        StartCoroutine(SpawnRock());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnHeart()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(heartSpawnRate);
            Instantiate(hearts, RandomSpawnPos(), Quaternion.identity);
        }
    }

    IEnumerator SpawnGhost()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(ghostSpawnRate);
            Instantiate(ghosts, RandomSpawnPos(), Quaternion.identity);
        }
    }

    IEnumerator SpawnSlime()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(slimeSpawnRate);
            Instantiate(slimes, RandomSpawnPos(), Quaternion.identity);
        }
    }

    IEnumerator SpawnRock()
    {
        while (canSpawn)
        {
            yield return new WaitForSeconds(rockSpawnRate);
            Instantiate(rocks, RandomSpawnPos(), Quaternion.identity);
        }
    }

    private Vector2 RandomSpawnPos()
    {
        Vector2 spawnPos1 = new Vector2(Random.Range(-12, 12), -5.20f);
        Vector2 spawnPos2 = new Vector2(Random.Range(-8, -3), 4f);
        Vector2 spawnPos3 = new Vector2(Random.Range(3, 8), 4f);
        int index = Random.Range(1, 4);
        if(index == 1) return spawnPos1;
        else if (index == 2) return spawnPos1;
        else return spawnPos3;
    }
}
