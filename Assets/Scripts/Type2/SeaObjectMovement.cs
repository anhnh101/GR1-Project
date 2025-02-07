using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaObjectMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float existTime = 7f;

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyObject();
    }

    private void Move()
    {
        if (gameObject.name != "Seaweed" && gameObject.name != "Fish" && gameObject.name != "Coin" && gameObject.name != "Arrow")
        {
            transform.position = transform.position + (Vector3.left * speed) * Time.deltaTime;
        }
    }

    private void DestroyObject()
    {
        if (gameObject.name == "Seaweed(Clone)" || gameObject.name == "Fish(Clone)" || gameObject.name == "Fish2(Clone)" || gameObject.name == "Coin(Clone)" || gameObject.name == "Jellyfish(Clone)")
        {
            Destroy(gameObject, existTime);
        }
    }
}
