using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private Transform door;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            print("Porta");
            door.gameObject.SetActive(false);
        }
    }
}
