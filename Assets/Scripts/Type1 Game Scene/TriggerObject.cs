using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TriggerObject : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private TilemapRenderer tilemapRenderer;
    private TilemapCollider2D tilemapCollider2D;
    [SerializeField][Tooltip("Type 1: Enable Sprite Renderer\nType 2: Enable Tilemap Renderer\nType 3: Disable Object\nType 4: Disable Tilemap Collider\nType 5: Disable Collider + Renderer")] private int type ;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapCollider2D = GetComponent<TilemapCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (type == 1)
            {
                spriteRenderer.enabled = true;
                
            }

            if (type == 2)
            {
                tilemapRenderer.enabled = true;
                
            }
            
            if (type == 3)
            {
                gameObject.SetActive(false);
                
            }

            if (type == 4)
            {
                tilemapCollider2D.enabled = false;
            }

            if (type == 5)
            {
                tilemapRenderer.enabled = false;
                tilemapCollider2D.enabled = false;
            }
        }

    }
}
