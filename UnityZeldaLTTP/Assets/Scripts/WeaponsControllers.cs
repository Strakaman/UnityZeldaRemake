using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public Transform weaponHold;
	public Gun startingWeapon;
	Weapon equippedWeapon;
	void Start () {
		if (startingWeapon != null) {
			EquipWeapon(startingWeapon);
		}
		
	}
	
	public void EquipWeapon(Weapon weaponToEquip) {
		if (equippedWeapon != null) {
			DestroyWeapon(equippedWeapon.gameObject);
		}
		equippedGun = Instantiate (weaponToEquip, weaponHold.position, weaponHold.rotation) as Weapon;
		equippedWeapon.transform.parent =weaponHold;

	}

}

