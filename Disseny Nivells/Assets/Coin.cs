using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Character>() != null)
        {
            var player = other.GetComponent<Character>();
            player.Coins++;
            gameObject.SetActive(false);
        }
    }
}
