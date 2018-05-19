using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public GameObject enemyDeathFX;
	public Slider enemySlider;
	public float enemyMaxHealth;
	float currentHealth;

	// Use this for initialization
	void Start() {
		currentHealth = enemyMaxHealth;
		enemySlider.maxValue = enemyMaxHealth;
		enemySlider.value = currentHealth;
	}

	public void AddDamage(float damage) {
		currentHealth -= damage;
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
