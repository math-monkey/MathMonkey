using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float fullHealth;
	public float pushBackForce;
    
	float currentHealth;
	PlayerController controlMovement;
	Animator myAnim;
	CapsuleCollider2D capsuleCollider;

    //HUD Variables
	public Slider healthSlider;
    
	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		controlMovement = GetComponent<PlayerController>();
		myAnim = controlMovement.GetComponent<Animator>();
		capsuleCollider = GetComponent<CapsuleCollider2D>();

		//HUD Initialization
		healthSlider.maxValue = fullHealth;
		healthSlider.value = fullHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //adds damage to player
	public void AddDamage(float damage) {
		if (damage <= 0) return;
		currentHealth -= damage;
		healthSlider.value = currentHealth;

		if(currentHealth <= 0) {
			Death();
		}
	}
    
	public void PushBack() {
        Vector2 pushDirection = new Vector2(0, 5).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }

	public void Death() {
		StartCoroutine("MakeDead");
	}

     IEnumerator MakeDead() {
		PushBack();
		healthSlider.gameObject.SetActive(false);
		capsuleCollider.enabled = false;
		controlMovement.enabled = false;
        myAnim.SetTrigger("Die");
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("Main");
	}
}
