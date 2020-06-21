using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform spawnTransform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.transform.GetComponent<Character>();
            player.ReSpawnPosition = spawnTransform.position;
        }
    }
}
