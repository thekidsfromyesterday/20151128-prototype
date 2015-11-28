using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	//// Sets the value
	//anim.SetBool("InConga", true); 
	// Gets the value
	//bool isInConga = anim.GetBool("InConga");

	void Update () {
		var axis = Input.GetAxis ("Horizontal");
		if (axis == 0) {		// Not moving
			anim.SetBool("isIdle", true);
			anim.SetBool("isMovingLeft", false);
			anim.SetBool("isMovingRight", false);
		} else if (axis > 0){	// Moving right
			anim.SetBool("isIdle", false);
			anim.SetBool("isMovingLeft", false);
			anim.SetBool("isMovingRight", true);
		} else if (axis < 0) {	// Moving left		
			anim.SetBool("isIdle", false);
			anim.SetBool("isMovingLeft", true);
			anim.SetBool("isMovingRight", false);
		}

		var position = gameObject.transform.position;
		var scalar = 0.1f;
		gameObject.transform.position = new Vector3 (position.x + (axis * scalar), position.y, position.z);

	}
}
