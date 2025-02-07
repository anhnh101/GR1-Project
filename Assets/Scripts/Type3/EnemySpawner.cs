using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    private BoxCollider2D spawnZone;

    [Header("Spawning Time Range")]
    public float min = 1.5f;
    public float max = 3.5f;

    private void Awake()
    {
        spawnZone = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(Random.Range(min, max));
        float minY = -spawnZone.bounds.size.y / 2f;
        float maxY = spawnZone.bounds.size.y / 2f;

        Vector3 temp = transform.position;
        temp.y = Random.Range(minY, maxY);
        Instantiate(enemy, temp, Quaternion.identity);

        StartCoroutine(SpawnEnemy());
    }
}
