using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private Transform door;
    private string _message = "The door is open!";

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            door.gameObject.SetActive(false);
            UIManager.Instance.ShowMessage(_message);
        }
    }
}
