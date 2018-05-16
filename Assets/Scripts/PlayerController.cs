using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Movement variables
	public float maxSpeed;

	// Jumping variables
	bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight = 15f;


	Rigidbody2D myRB;
	Animator myAnim;
	bool facingRight;

	// Projectile throwing Variables
	public Transform bulletSpawn;
	public GameObject bullet;
	float fireRate = 0.5f;
	float nextFire = 0f;

	// Use this for initialization
	void Start() {
		myRB = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
		facingRight = true;
		grounded = true;
	}

	// Update is called once per frame
	void Update() {
		if (grounded && Input.GetButtonDown("Jump")) {
			grounded = false;
			myAnim.SetBool("isGrounded", grounded);
			myRB.velocity = Vector2.up * jumpHeight;
		}

		// Player shooting
		if (Input.GetAxisRaw("Fire1") > 0) {
			throwBullet();
		}
	}

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		myAnim.SetBool("isGrounded", grounded);

		myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

		float move = Input.GetAxis("Horizontal");
		myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
		myAnim.SetFloat("speed", Mathf.Abs(move));

		if (move > 0 && !facingRight || move < 0 && facingRight) {
			Flip();
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void throwBullet() {
		var now = Time.time;
		if (now > nextFire) {
			nextFire = now + fireRate;
			var direction = facingRight ? Vector3.zero : Vector3.back;
			Instantiate(bullet, bulletSpawn.position, Quaternion.Euler(direction));
		}
	}
}
