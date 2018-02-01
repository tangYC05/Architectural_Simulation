﻿using UnityEngine;
using System.Collections;

//This script is used to enable control on player
//Put This Script On player

[RequireComponent (typeof(CharacterController))]
[RequireComponent (typeof(T_Spin))]
public class T_FPSController : MonoBehaviour {

	public float speed = 10;
	public float gravity = -9.8f;
	bool lockCamera = true;

	CharacterController charCtrl;

	void Start () {
		charCtrl = GetComponent<CharacterController> ();
	}

	//Enable character control
	void Update () {

		float deltaX = Input.GetAxis ("Horizontal")* speed;
		float deltaY = Input.GetAxis ("Vertical") * speed;

		Vector3 movement = new Vector3 (deltaX, gravity, deltaY);
		movement *= Time.deltaTime;
		charCtrl.Move (transform.TransformDirection(movement));


		//lock the cursor to the screen
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			lockCamera = !lockCamera;
		}

		if (lockCamera == true) 
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		if (lockCamera == false) 
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
