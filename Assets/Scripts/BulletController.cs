using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public float degsBySec;
	public float bulletSpeed;

	Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
		var direction = transform.localRotation.z.Equals(0) ? Vector2.right : Vector2.left;
		rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
	}

	// Update is called once per frame
	void Update() {
		transform.Rotate(0, 0, -degsBySec * Time.deltaTime);
	}

	public void RemoveForce() {
		rb.velocity = Vector2.zero;
	}
}
