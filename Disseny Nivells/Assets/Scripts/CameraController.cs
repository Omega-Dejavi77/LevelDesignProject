using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y  + offset.y, offset.z);
    }
}
