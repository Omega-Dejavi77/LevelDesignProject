using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePlatform : Platform
{
    [SerializeField] private float timeToDestroy;
    private bool _destroy;
    private float _currentTime;
    private Character _player;
    
    protected override void Update()
    {
        base.Update();
        
        if (_destroy)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= timeToDestroy)
                Destroy(gameObject);
        }
    }


    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            base.OnCollisionEnter2D(other);
            _destroy = true;
            _player = other.collider.GetComponent<Character>();
        }
    }

    protected override void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            base.OnCollisionExit2D(other);
            _destroy = false;
            _currentTime = 0f;
            _player = null;
        }
    }

    private void OnDestroy()
    {
        if (_player != null) 
            _player.EnablePhysics();
    }
}
