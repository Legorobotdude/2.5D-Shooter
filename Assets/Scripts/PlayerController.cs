using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.CrossPlatformInput;

public class PlayerController : MonoBehaviour {


    [SerializeField]Animator anim;
    int jumpHash = Animator.StringToHash("Jump");

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
        rigidBody.velocity = new Vector3(horizontalMovementSpeed * speed, rigidBody.velocity.y, 0);
       
        anim.SetFloat("Speed", speed);
    }

    private void HandleVerticalMovement()
    {
        if(Input.GetButtonDown("Jump")&&canJump&&canJumpInAir)
		{
			rigidBody.AddForce(new Vector3(0,jumpForce*Time.deltaTime,0));
            //rigidBody.velocity = 
            anim.SetTrigger(jumpHash);
		}
		else if(Input.GetButtonDown("Jump")&&canJump)
		{

		}
    }
}
