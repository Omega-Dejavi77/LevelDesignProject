using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    private Rigidbody _rb;
    private float _speed;
    private float _angularSpeed;
    public Vector3 force;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        force = transform.eulerAngles += new Vector3(0 ,0, 1) * (Time.deltaTime * 100f);

    }
}
