using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private float speedFactor;
    private float _direction = 1f;
    

    void Update()
    {
        if (Distance(leftPoint.position) < 0.2f || Distance(rightPoint.position) < 0.2f)
            _direction *= -1;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(_direction , 0, 0) * (Time.deltaTime * speedFactor);
    }

    private float Distance(Vector3 position)
    {
        return Mathf.Abs(position.x - transform.position.x);
    }
}
