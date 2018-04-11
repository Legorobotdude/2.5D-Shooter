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
    [SerializeField][Tooltip("Only applies if canJumpInAir=true")] int maxJumps = 2;
	[SerializeField]float jumpForce = 100f;

	Rigidbody rigidBody;

    bool isGrounded;
    int jumpCounter = 0;

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
        if(Input.GetButtonDown("Jump")&&canJump&&canJumpInAir&&jumpCounter<=maxJumps)
		{
			rigidBody.AddForce(new Vector3(0,jumpForce*Time.deltaTime,0));
            anim.SetTrigger(jumpHash);
            jumpCounter++;
		}
		else if(Input.GetButtonDown("Jump")&&canJump&&isGrounded)
		{
            rigidBody.AddForce(new Vector3(0, jumpForce * Time.deltaTime, 0));
            anim.SetTrigger(jumpHash);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        //Debug.Log("Collision Entered");
        //Debug.Log(collision.collider.tag);
        

        if (collision.collider.tag == "Ground")
        {
           isGrounded = true;
            jumpCounter = 0;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;

        }
    }
}
