using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

public Transform muzzle;
public Projectile projectile;
public Sprite weaponIcon;

public float msBetweenShots=100;
public float muzzleVelocity=35;

public void Shoot(){

	Projectile newProjectile = Instantiate (projectile, muzzle.position, muzzle.rotation) as Projectile;
	newProjectile.setSpeed (muzzleVelocity);
	}

}
 