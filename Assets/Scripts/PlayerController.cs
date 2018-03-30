using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.CrossPlatformInput;

public class PlayerController : MonoBehaviour {


	[SerializeField]float horizontalMovementSpeed = 10f;
	[SerializeField]bool canJump = true;
	[SerializeField]bool canJumpInAir = true;
	[SerializeField]float jumpForce = 100f;

	Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		HandleVerticalMovement();
		HandleHorizontalMovement();
	}

    private void HandleHorizontalMovement()
    {
        rigidBody.AddForce(new Vector3(horizontalMovementSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0,0));
    }

    private void HandleVerticalMovement()
    {
        if(Input.GetButtonDown("Jump")&&canJump&&canJumpInAir)
		{
			rigidBody.AddForce(new Vector3(0,jumpForce*Time.deltaTime,0));
		}
		else if(Input.GetButtonDown("Jump")&&canJump)
		{

		}
    }
}
