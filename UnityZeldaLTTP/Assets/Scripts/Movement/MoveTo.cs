﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveTo : MonoBehaviour {
    public bool enable = false;
    public Transform destination;
    public float speed = 15f;

    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private Vector2 _force;

	// Use this for initialization
	void Start ()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _force = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!enable)
        {
            return;
        }

        _rigidbody.AddForce(-_force);
        Vector2 direction = destination.position - _transform.position;
        _force = direction.normalized * speed;
        _rigidbody.AddForce(_force);
    }
}