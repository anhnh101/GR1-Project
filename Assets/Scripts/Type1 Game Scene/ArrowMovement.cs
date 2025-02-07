using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ArrowMovement : MonoBehaviour
{

    [SerializeField] private int type = 0;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float existTime = 7f;

    // Update is called once per frame
    private void Update()
    {
        Move();
        DestroyArrow();
    }

    private void Move()
    {
        if (gameObject.name != "Arrow Move Up" && gameObject.name != "Arrow Move Left" && gameObject.name != "Arrow Move Right" && gameObject.name != "Arrow Move Down" && gameObject.name != "Yellow Bullet" && gameObject.name != "Grey Bullet")
        {
            if (type == 0)
            {
                transform.position = transform.position + (Vector3.up * speed) * Time.deltaTime;
            }

            if (type == 1)
            {
                transform.position = transform.position + (Vector3.left * speed) * Time.deltaTime;
            }

            if (type == 2)
            {
                transform.position = transform.position + (Vector3.right * speed) * Time.deltaTime;
            }

            if (type == 3)
            {
                transform.position = transform.position + (Vector3.down * speed) * Time.deltaTime;
            }
        }
    }


    private void DestroyArrow()
    {
        if (gameObject.name == "Arrow Move Up(Clone)" || gameObject.name == "Arrow Move Left(Clone)" || gameObject.name == "Arrow Move Right(Clone)" || gameObject.name == "Arrow Move Down(Clone)" || gameObject.name == "Yellow Bullet(Clone)" || gameObject.name == "Grey Bullet(Clone)")
        {
            Destroy(gameObject, existTime);
        }
    }
}
