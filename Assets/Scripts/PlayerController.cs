using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [SerializeField] Animator anim;
    int jumpHash = Animator.StringToHash ("Jump");

    [SerializeField] float horizontalMovementSpeed = 10f;
    [SerializeField] bool canJump = true;
    [SerializeField] bool canJumpInAir = true;
    [SerializeField][Tooltip ("Only applies if canJumpInAir=true")] int maxJumps = 2;
    [SerializeField] float jumpForce = 100f;
    [SerializeField] GameObject gun;

    Rigidbody rigidBody;

    bool isGrounded;
    int jumpCounter = 0;
    Camera mainCamera;
    //bool isFacingBackward = false;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody> ();
        if (anim == null) {
            anim = GetComponent<Animator> ();
        }
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update () {
        HandleVerticalMovement ();
        HandleHorizontalMovement ();
    }

    private void HandleHorizontalMovement () {
        //float camDis = mainCamera.transform.position.z - transform.position.z;
        Vector3 mouse = mainCamera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, mainCamera.farClipPlane)); //Calculate the position of the cursor relative to the player
        //Debug.Log(mouse+","+transform.position);

        float speed = Input.GetAxis ("Horizontal");
        rigidBody.velocity = new Vector3 (horizontalMovementSpeed * speed, rigidBody.velocity.y, 0);
        if (mouse.x >= 0) //Point the player towards the cursor
        {
            anim.SetFloat ("Speed", speed);
            //Debug.Log("Facing Forward");
            // if (transform.localScale.z < 0) {
            //     transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, -transform.localScale.z);
            // }
            //Debug.Log(transform.rotation.eulerAngles.y);
            if (Math.Abs(transform.rotation.eulerAngles.y - 270f) <= 1f)//transform.rotation.eulerAngles.y.Equals(-90f)
            {
                transform.Rotate(new Vector3(0f,180f,0f));
                //Debug.Log("Rotate to face forward");

            }
        } else {
             //Debug.Log("Facing Back");
            anim.SetFloat ("Speed", -speed);
            // if (transform.localScale.z > 0)
            // {
            //     transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y, -transform.localScale.z);
            // }
            //Debug.Log(transform.rotation.eulerAngles.y);
            if (Math.Abs(transform.rotation.eulerAngles.y - 90f) <= 1f)
            {
                transform.Rotate(new Vector3(0f,180f,0f));

            }
        }

    }

    private void HandleVerticalMovement () {
        if (Input.GetButtonDown ("Jump") && canJump && canJumpInAir && jumpCounter < maxJumps) {
            rigidBody.AddForce (new Vector3 (0, jumpForce, 0));
            anim.SetTrigger (jumpHash);
            jumpCounter++;
        } else if (Input.GetButtonDown ("Jump") && canJump && isGrounded) {
            rigidBody.AddForce (new Vector3 (0, jumpForce, 0));
            anim.SetTrigger (jumpHash);
        }
    }

    void OnCollisionEnter (Collision collision) {

        //Debug.Log("Collision Entered");
        //Debug.Log(collision.collider.tag);

        if (collision.collider.tag == "Ground") {
            isGrounded = true;
            jumpCounter = 0;
        }
    }

    void OnCollisionExit (Collision collision) {
        if (collision.collider.tag == "Ground") {
            isGrounded = false;

        }
    }
}