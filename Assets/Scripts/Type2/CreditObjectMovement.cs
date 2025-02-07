using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditObjectMovement : MonoBehaviour
{

    [SerializeField] private float speed = 2f;
    [SerializeField] private float existTime = 15f;
    
    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyObject();
    }

    private void Move()
    {
        if (gameObject.name != "Seaweed" && gameObject.name != "Fish" && gameObject.name != "Coin" && gameObject.name != "Saw" && gameObject.name != "Arrow" && gameObject.name != "Box" && gameObject.name != "Fish2" && gameObject.name != "Jellyfish" && gameObject.name != "Spike" && gameObject.name != "Goal Flag")
        {
            transform.position = transform.position + (Vector3.down * speed) * Time.deltaTime;
        }
    }

    private void DestroyObject()
    {
        if (gameObject.name == "Seaweed(Clone)" || gameObject.name == "Fish(Clone)" || gameObject.name == "Fish2(Clone)" || gameObject.name == "Coin(Clone)" || gameObject.name == "Jellyfish(Clone)" || gameObject.name == "Saw(Clone)" || gameObject.name == "Arrow(Clone)" || gameObject.name == "Box(Clone)" || gameObject.name == "Spike(Clone)" || gameObject.name == "Goal Flag(Clone)")
        {
            Destroy(gameObject, existTime);
        }
    }
}
