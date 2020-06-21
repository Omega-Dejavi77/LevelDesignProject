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

    [SerializeField] private Transform pivotPoint;
    [SerializeField] private Transform pike;
    private Vector2 _targetPoint;

    private void Start()
    {
        transform.SetParent(pivotPoint);
    }

    private void Update()
    {
        var distance = Mathf.Abs(collisionPoint.position.y - initialPoint.position.y);
        if (distance < 0.1f)
            _direction *= -1;
    }

    private void FixedUpdate()
    {
        var hit = Physics2D.Raycast(collisionPoint.position, Vector2.down, 200f);
        if (hit.collider.CompareTag("Ground"))
        {
            var distance = Mathf.Abs(hit.point.y - collisionPoint.position.y);
            if (distance < 0.1f)
                _direction *= -1;
        }
        //transform.position += new Vector3(0 , _direction, 0) * (Time.deltaTime * speedFactor);
        pivotPoint.transform.localScale += new Vector3(0, _direction, 0) * (Time.deltaTime * speedFactor);
        pike.localScale = new Vector2(3, 1);
    }
}
