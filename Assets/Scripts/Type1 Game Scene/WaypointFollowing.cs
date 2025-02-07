using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollowing : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 4;
    //[SerializeField] private float delayTime = 0f;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(sprite.enabled == true)
        {
            if (waypoints.Length > 0)
            {
                if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
                {
                    currentWaypointIndex++;
                    if (currentWaypointIndex >= waypoints.Length)
                    {
                        currentWaypointIndex = 0;
                    }
                }
                //StartCoroutine(SpawnEnemy(delayTime));
                transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
            }
        }
        
    }

    /*private IEnumerator SpawnEnemy(float delayTime)
    {
        
        yield return new WaitForSeconds(delayTime);
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }*/
}
