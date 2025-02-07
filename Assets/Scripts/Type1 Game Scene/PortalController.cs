using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private AudioSource teleSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            if (Vector2.Distance(collision.transform.position, transform.position) > 0.5f)
            {
                teleSFX.Play();
                collision.transform.position = destination.transform.position;
            }
            
        }
    }
}
