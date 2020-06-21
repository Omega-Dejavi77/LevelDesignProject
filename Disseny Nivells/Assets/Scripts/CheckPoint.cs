using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform spawnTransform;
    private BoxCollider2D _collider2D;

    private void Start()
    {
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            print("Checkpoint");
            var player = other.transform.GetComponent<Character>();
            player.ReSpawnPosition = spawnTransform.position;
            _collider2D.enabled = false;
        }
    }
}
