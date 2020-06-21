using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform initialPoint;
    [SerializeField] private Transform finalPoint;
    [SerializeField] private float speedFactor;
    
    private Vector2 _targetPoint;

    private void Start()
    {
        _targetPoint = initialPoint.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, initialPoint.position) <= 0.5f)
        {
            _targetPoint = finalPoint.position;
        }

        if (Vector3.Distance(transform.position, finalPoint.position) <= 0.5f)
        {
            _targetPoint = initialPoint.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPoint, Time.deltaTime * speedFactor);
    }
}
