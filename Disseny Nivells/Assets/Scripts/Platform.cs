using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private float speedFactor;

    private Vector2 _targetPoint;

    private void Start()
    {
        _targetPoint = leftPoint.position;
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, leftPoint.position) <= 0.5f)
        {
            _targetPoint = rightPoint.position;
        }

        if (Vector3.Distance(transform.position, rightPoint.position) <= 0.5f)
        {
            _targetPoint = leftPoint.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPoint, Time.deltaTime * speedFactor);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }
}