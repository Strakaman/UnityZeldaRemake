using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class DamageOnCollision : MonoBehaviour
{
    public int damageRate = 1;

    private Transform _transform;

	// Use this for initialization
	void Start()
   {
        _transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update()
   {
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            var otherTransform = collision.gameObject.GetComponent<Transform>();
            var differenceBetweenCenters = otherTransform.position - _transform.position;
            damageable.TakeHit(damageRate, _transform.position, differenceBetweenCenters.normalized);
        }
    }
}
