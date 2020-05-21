using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{

    [SerializeField] private Transform initialPoint;
    [SerializeField] private float speedFactor;
    private float _direction = -1f;
    [SerializeField] private Transform collisionPoint;

    private void Update()
    {
        var distance = Mathf.Abs(collisionPoint.position.y - initialPoint.position.y);
        if (distance < 0.1f)
            _direction *= -1;
    }

    void FixedUpdate()
    {
        var hit = Physics2D.Raycast(collisionPoint.position, Vector2.down, 200f);
        if (hit.collider.CompareTag("Ground"))
        {
            var distance = Mathf.Abs(hit.point.y - collisionPoint.position.y);
            if (distance < 0.1f)
                _direction *= -1;
        }
        transform.position += new Vector3(0 , _direction, 0) * (Time.deltaTime * speedFactor);
    }
}
