using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float xIndex = 0;
    [SerializeField] private float yIndex = 2.75f;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x +xIndex, player.position.y + yIndex, transform.position.z);
    }
}
