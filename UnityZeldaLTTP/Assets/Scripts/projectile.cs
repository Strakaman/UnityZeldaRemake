using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour { 
    public LayerMask collisionMask;
	float speed = 10;
    int damage = 1;

	public void setSpeed (float newSpeed ) {
		speed = newSpeed;
	}
	
	
	void Update () {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions (moveDistance);
		transform.Translate(Vector3.forward * moveDistance);
	}
    
    void CheckCollisions(float moveDistance) {
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide)) {
			OnHitObject(hit.collider, hit.point);
		}
	}
    
   void OnHitObject(Collider c, Vector3 hitPoint) {
		IDamageable damageableObject = c.GetComponent<IDamageable> ();
		if (damageableObject != null) {
			damageableObject.TakeHit(damage, hitPoint, transform.forward);
		}
        Destroy(gameObject);

	}
}
