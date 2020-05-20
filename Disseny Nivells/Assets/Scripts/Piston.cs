using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour
{

    [SerializeField] private Transform initialPoint;
    [SerializeField] private float speedFactor;
    private float _direction = -1f;
    [SerializeField] private Transform point;

    private void Update()
    {
        var distance = Mathf.Abs(point.position.y - initialPoint.position.y);
        if (distance < 0.1f)
            _direction *= -1;
    }

    void FixedUpdate()
    {
        var hit = Physics2D.Raycast(point.position, Vector2.down, 200f);
        print(hit.collider.name);
        if (hit.collider.CompareTag("Ground"))
        {
            var distance = Mathf.Abs(hit.point.y - point.position.y);
            if (distance < 0.1f)
            {
                _direction *= -1;
                print("pene");
            }
        }
        transform.position += new Vector3(0 , _direction, 0) * (Time.deltaTime * speedFactor);
    }
}
