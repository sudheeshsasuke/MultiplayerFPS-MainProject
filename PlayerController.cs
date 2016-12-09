﻿using UnityEngine;
//using System.Collections;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

	[SerializeField]

	private float speed = 5f;

	[SerializeField]

	private float lookSensitivity = 3f;

	private PlayerMotor motor;

	void Start()
	{
		motor = GetComponent<PlayerMotor> ();
	}

	void Update()
	{
		//calculate movement velocity as 3D vector
		float _xMov = Input.GetAxisRaw("Horizontal");
		float _zMov = Input.GetAxisRaw ("Vertical");

		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _movVertical = transform.forward * _zMov;

		//final movement vector
		Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;


		//apply movement
		motor.Move(_velocity);

		//calculate rotation as a 3d vector (turinig around)
		float _yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * lookSensitivity;

		//Apply rotation
		motor.Rotate(_rotation);

		//calculate camera rotation as a 3d vector (turinig around)
		float _xRot = Input.GetAxisRaw("Mouse Y");

		Vector3 _cameraRotation = new Vector3 (_xRot, 0f, 0f) * lookSensitivity;

		//Apply rotation
		motor.RotateCamera(_cameraRotation);


	}

}
