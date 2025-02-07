using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    [SerializeField] private float leftBound = -21.0f;
    [SerializeField] private float rightBound = 21.0f;
    [SerializeField] private float upperBound = 11.0f;
    [SerializeField] private float underBound = -11.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftBound || transform.position.x > rightBound || transform.position.y > upperBound || transform.position.y < underBound)
        {
            if (gameObject.CompareTag("Player Bullet"))
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
