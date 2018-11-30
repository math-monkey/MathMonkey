using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyHealth : MonoBehaviour {

    public GameObject enemyDeathFX;
    public Slider enemySlider;
    public GameObject theDrop;
    public AudioClip audioDeath;
    public float enemyMaxHealth;
    public bool drops;
    public bool isNumber;

    float currentHealth;
    bool onlyRightShots;
    ObjectController controller;

    // Use this for initialization
    void Start() {
        controller = GetComponent<ObjectController>();
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = enemyMaxHealth;
        enemySlider.value = currentHealth;
        onlyRightShots = true;
    }

    public void AddDamage(float damage, BulletController.BulletType bulletType) {
        Debug.Log(controller.GetNumber());
        if (!NumberHelper.HasDamage(bulletType, controller.GetNumber())) {
            damage *= -1;
            onlyRightShots = false;
        }
        currentHealth = Math.Min(currentHealth - damage, enemyMaxHealth);
        enemySlider.gameObject.SetActive(true);
        enemySlider.value = currentHealth;
        if (currentHealth <= 0) {
            MakeDead();
        } else {
            controller.UpdateValue();
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
        AudioSource.PlayClipAtPoint(audioDeath, transform.position, 1f);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (drops) {
            int coinsAmount = onlyRightShots ? 5 : 2;
            DropCoins(coinsAmount);
        }
    }
}
