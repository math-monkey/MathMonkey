using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float enemyMaxHealth;
	float currentHealth;

	// Use this for initialization
	void Start() {
		currentHealth = enemyMaxHealth;
	}

	public void AddDamage(float damage) {
		currentHealth -= damage;
		if (currentHealth <= 0) {
			MakeDead();
		}
	}

	private void MakeDead() {
		Destroy(gameObject);
	}
}
