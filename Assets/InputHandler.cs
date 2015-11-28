using System;
using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";
    private const string JumpInput = "Jump";

    public float movementSpeed = 5;

    private Rigidbody2D RigidBody { get; set; }
	private Animator Animator { get; set;}

    private volatile bool _isGrounded;

	// Use this for initialization
	void Start () {
        RigidBody = gameObject.GetComponent<Rigidbody2D>();
		Animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		var axis = Input.GetAxis(HorizontalInput);
        Horizontal(axis);
	    Jump();
		Animate(axis);
	}

    void Horizontal(float axis)
    {        
        gameObject.transform.Translate(Vector3.right * axis * movementSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetButton(JumpInput) && _isGrounded && RigidBody.velocity.y.Equals(0))
            RigidBody.velocity += Vector2.up*5;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Ground"))
            _isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Ground"))
            _isGrounded = true;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Ground"))
            _isGrounded = true;
    }

	void Animate(float axis)
	{
		if (axis.Equals(0)) 
		{		// Not moving
			Animator.SetBool("isIdle", true);
			Animator.SetBool("isMovingLeft", false);
			Animator.SetBool("isMovingRight", false);
		} else if (axis > 0)
		{	// Moving right
			Animator.SetBool("isIdle", false);
			Animator.SetBool("isMovingLeft", false);
			Animator.SetBool("isMovingRight", true);
		} else if (axis < 0) 
		{	// Moving left		
			Animator.SetBool("isIdle", false);
			Animator.SetBool("isMovingLeft", true);
			Animator.SetBool("isMovingRight", false);
		}
	}
}