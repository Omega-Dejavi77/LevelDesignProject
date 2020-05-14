using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody _rb;
    private bool _attached;
    private Vector3 force;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        if (!_attached)
            transform.Translate(new Vector2(x, y) * (Time.deltaTime * 2f));
        
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            _attached = false;
            transform.SetParent(null);
            Debug.Log("HOLA");
            _rb.useGravity = true;
            _rb.AddRelativeForce(force * 20f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Attach"))
        {
            transform.SetParent(other.transform);
            _attached = true;
            force = other.transform.GetComponent<Loop>().force;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Attach"))
        {
            transform.SetParent(null);
            _attached = false;
        }
    }
}
