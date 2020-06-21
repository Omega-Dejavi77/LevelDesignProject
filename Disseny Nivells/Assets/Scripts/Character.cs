﻿using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _isHookThrown;
    
    private Vector2 hitPoint;
    [SerializeField] private float speedFactor;
    private Vector3 _direction;

    private Vector2 _defaultGravity;
    public Vector2 ReSpawnPosition { get; set; }

    private int _coins;
    public int Coins
    {
        get => _coins;
        set
        {
            _coins = value;
            UIManager.Instance.UpdateCoinsVisuals(_coins);
        }
    }

    private void Start()
    {
        _defaultGravity = Physics2D.gravity;
        _rb = GetComponent<Rigidbody2D>();
        ReSpawnPosition = transform.position;
        _direction = Vector2.zero;
    }

    void Update()
    {
        if (!_isHookThrown)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _direction = Vector2.up;
                hitPoint = ThrowHook(Vector2.up);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _direction = Vector2.left;
                hitPoint = ThrowHook(Vector2.left);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _direction = Vector2.down;
                hitPoint = ThrowHook(Vector2.down);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _direction = Vector2.right;
                hitPoint = ThrowHook(Vector2.right);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isHookThrown = false;
            _rb.gravityScale = 1f;
            transform.SetParent(null);
            Physics2D.gravity = _defaultGravity;
            _rb.velocity = Vector2.zero;
        }

        else if (_isHookThrown && Vector3.Distance(transform.position, hitPoint) > 1f)
        {
            _rb.velocity = _direction * speedFactor;
        }
    }

    private Vector2 ThrowHook(Vector2 direction)
    {
        Physics2D.gravity = Vector2.zero;
        _isHookThrown = true;
        _rb.velocity = new Vector2(_rb.velocity.x, 0f);
        var hit = Physics2D.Raycast(transform.position, direction, 500f);
        if (hit.collider.CompareTag("Platform"))
        {
            transform.SetParent(hit.transform);
            _rb.velocity = Vector2.zero;
        }
        return hit.point;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        transform.position = ReSpawnPosition;
        _direction = Vector2.zero;
        _isHookThrown = false;
        _rb.gravityScale = 1f;
        transform.SetParent(null);
        Physics2D.gravity = _defaultGravity;
    }
}