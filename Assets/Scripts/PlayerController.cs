using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.CrossPlatformInput;

public class PlayerController : MonoBehaviour {


    [SerializeField]Animator anim;

	[SerializeField]float horizontalMovementSpeed = 10f;
	[SerializeField]bool canJump = true;
	[SerializeField]bool canJumpInAir = true;
	[SerializeField]float jumpForce = 100f;

	Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
        if (anim == null)
        {
            anim = GetComponent<Animator>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		HandleVerticalMovement();
		HandleHorizontalMovement();
	}

    private void HandleHorizontalMovement()
    {
        float speed = Input.GetAxis("Horizontal");
        rigidBody.AddForce(new Vector3(horizontalMovementSpeed*speed*Time.deltaTime,0,0));
        anim.SetFloat("Speed", speed);
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
