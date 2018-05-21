using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

	public float bulletDamage;
	public GameObject explosionEffect;

	BulletController bc;

	void Awake() {
		bc = GetComponentInParent<BulletController>();
	}

	void OnTriggerEnter2D(Collider2D other) {
		HitShootable(other);
	}

	void OnTriggerStay2D(Collider2D other) {
		HitShootable(other);
	}

	void HitShootable(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Shootable")) {
			bc.RemoveForce();
			Instantiate(explosionEffect, transform.position, transform.rotation);
			Destroy(gameObject);

			if (other.tag == "Enemy") {
				EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
				enemyHealth.AddDamage(bulletDamage, bc.bulletType);
			}
		}
	}
}
