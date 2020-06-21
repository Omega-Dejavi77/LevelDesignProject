using UnityEngine;

public class FlipPlatform : Platform
{
    [SerializeField] private float speed;
    private bool _isAttached;
    
    protected override void Update()
    { 
        if (_isAttached)
        {
            var targetRotation = Quaternion.Euler(0, 2, 180f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 2f * Time.deltaTime);
        }
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.GetComponent<Character>())
        {
            base.OnCollisionEnter2D(other);
            _isAttached = true;
        }
    }

    protected override void OnCollisionExit2D(Collision2D other)
    {
        
        if (other.collider.GetComponent<Character>())
        { 
            base.OnCollisionExit2D(other); 
            _isAttached = false;
        }
    }
}