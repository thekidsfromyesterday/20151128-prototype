using System;
using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    private const string HorizontalInput = "Horizontal";
    private const string JumpInput = "Jump";

    public float movementSpeed = 5;
    
    private Rigidbody2D RigidBody { get; set; }

    private bool IsGrounded
    {
        get { return false; }
    }

	// Use this for initialization
	void Start () {
        RigidBody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        Horizontal();
	    Jump();
	}

    void Horizontal()
    {
        var axis = Input.GetAxis(HorizontalInput);
        gameObject.transform.Translate(Vector3.right * axis * movementSpeed * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetButton(JumpInput) && IsGrounded)
            RigidBody.velocity += Vector2.up*5;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
