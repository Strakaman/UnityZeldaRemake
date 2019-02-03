using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour {

	public Transform weaponHold;
	public Weapons startingWeapon;
	Weapons equippedWeapon;
	void Start () {
		if (startingWeapon != null) {
			EquipWeapon(startingWeapon);
		}
		
	}
	
	public void EquipWeapon(Weapons weaponToEquip) {
		if (equippedWeapon != null) {
			Destroy(equippedWeapon.gameObject);
		}
		equippedWeapon = Instantiate (weaponToEquip, weaponHold.position, weaponHold.rotation) as Weapons;
		equippedWeapon.transform.parent = weaponHold;
	}
	   	public void Shoot() {
		  if (equippedWeapon != null) {
			  equippedWeapon.Shoot();
		}
	}
}

