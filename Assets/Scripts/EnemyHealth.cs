using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyHealth : MonoBehaviour {

	public GameObject enemyDeathFX;
	public Slider enemySlider;
	public float enemyMaxHealth;
	public bool drops;
	public GameObject theDrop;

	float currentHealth;
	NumberController nc;
	bool onlyRightShots;

	// Use this for initialization
	void Start() {
		nc = GetComponent<NumberController>();
		currentHealth = enemyMaxHealth;
		enemySlider.maxValue = enemyMaxHealth;
		enemySlider.value = currentHealth;
		onlyRightShots = true;
	}

	public void AddDamage(float damage, BulletController.BulletType bulletType) {
		if (!NumberHelper.HasDamage(bulletType, nc.GetNumber())) {
			// Make any penalty here
			damage *= -1;
			onlyRightShots = false;
		}
		currentHealth = Math.Min(currentHealth - damage, enemyMaxHealth);
		enemySlider.gameObject.SetActive(true);
		enemySlider.value = currentHealth;
		if (currentHealth <= 0) {
			MakeDead();
		} else {
			nc.UpdateNumber();
		}
	}

	void DropCoins(int numberOfCoins) {
		Vector3 temp = new Vector3(transform.position.x - 0.5f, transform.position.y - 0.5f, transform.position.z);
		transform.position = temp;
		for (int i = 0; i < numberOfCoins; i++) {
			Instantiate(theDrop, transform.position, transform.rotation);
			temp.x = transform.position.x + 0.5f;
			transform.position = temp;
		}
	}

	private void MakeDead() {
		Destroy(gameObject);
		Instantiate(enemyDeathFX, transform.position, transform.rotation);
		if (drops) {
			int coinsAmount = onlyRightShots ? 5 : 2;
			DropCoins(coinsAmount);
		}
	}
}
