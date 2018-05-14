using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//movement variables
	public float maxSpeed;

	//jumping variables
	bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;


	Rigidbody2D myRB;
	Animator myAnim;
	bool facingRight;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
		facingRight = true;
		grounded = true;
	}

	// Update is called once per frame
    void Update () {
		if(grounded && Input.GetAxis("Jump") > 0) {
			grounded = false;
			myAnim.SetBool("isGrounded", grounded);
			myRB.AddForce(new Vector2(0, jumpHeight));
		}
    }
    
    void FixedUpdate () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		myAnim.SetBool("isGrounded", grounded);

		myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

		float move = Input.GetAxis("Horizontal");
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
		myAnim.SetFloat("speed", Mathf.Abs(move)); 

		if(move>0 && !facingRight || move<0 && facingRight) {
			Flip();
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
