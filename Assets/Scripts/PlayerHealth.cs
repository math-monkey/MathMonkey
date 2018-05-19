using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float fullHealth;

	bool isDead;
	float currentHealth;
	PlayerController controlMovement;
	Transform enemyObject;
	Animator myAnim;
	CapsuleCollider2D capsuleCollider;
    
	// Use this for initialization
	void Start () {
		isDead = false;
		currentHealth = fullHealth;
		controlMovement = GetComponent<PlayerController>();
		myAnim = controlMovement.GetComponent<Animator>();
		capsuleCollider = GetComponent<CapsuleCollider2D>();
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
		capsuleCollider.enabled = false;
		controlMovement.enabled = false;
        myAnim.SetTrigger("Die");
		Destroy(gameObject, 3f);
	}
}
