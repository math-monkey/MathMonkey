using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float fullHealth;
	float currentHealth;
    
	PlayerController controlMovement;
	Transform enemyObject;
	Animator myAnim;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		controlMovement = GetComponent<PlayerController>();
		myAnim = controlMovement.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //adds damage to player
	public void AddDamage(float damage) {
		if (damage <= 0) return;
		currentHealth -= damage;

		if(currentHealth <= 0) {
			MakeDead();
		}
	}

	void MakeDead() {
        myAnim.SetTrigger("die");
		Destroy(gameObject, 0.6f);
	}
}
