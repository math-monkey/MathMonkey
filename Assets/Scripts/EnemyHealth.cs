using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyHealth : MonoBehaviour {

	public GameObject enemyDeathFX;
	public Slider enemySlider;
	public float enemyMaxHealth;
	float currentHealth;
	NumberController nc;

	// Use this for initialization
	void Start() {
		nc = GetComponent<NumberController>();
		currentHealth = enemyMaxHealth;
		enemySlider.maxValue = enemyMaxHealth;
		enemySlider.value = currentHealth;
	}

	public void AddDamage(float damage, BulletController.BulletType bulletType) {
		if (!NumberHelper.HasDamage(bulletType, nc.GetNumber())) {
			// Make any penalty here
			damage = -10;
		}
		currentHealth = Math.Min(currentHealth - damage, enemyMaxHealth);
		enemySlider.gameObject.SetActive(true);
		enemySlider.value = currentHealth;
		if (currentHealth <= 0) {
			MakeDead();
		}
	}

	private void MakeDead() {
		Destroy(gameObject);
		Instantiate(enemyDeathFX, transform.position, transform.rotation);
	}
}
