using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player.cs : MonoBehaviour {

    public float moveSpeed = 5;

	void Start () {
		
	}
	

	void Update () {
    Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    Vector3 moveVelocity = moveInput.normalized * moveSpeed;

	}
}
