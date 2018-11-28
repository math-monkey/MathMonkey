using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float fullHealth;
	public float pushBackForce;
	public Slider healthSlider;
    public AudioClip monkeyAudio;

    float currentHealth;
    PlayerController controlMovement;
    Animator myAnim;
    CapsuleCollider2D capsuleCollider;
    PlayerLife playerLife;
    
	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		controlMovement = GetComponent<PlayerController>();
		myAnim = controlMovement.GetComponent<Animator>();
		capsuleCollider = GetComponent<CapsuleCollider2D>();
		playerLife = GetComponent<PlayerLife>();
        
		//HUD Initialization
		healthSlider.maxValue = fullHealth;
		healthSlider.value = fullHealth;

		transform.gameObject.SetActive(true);
		playerLife.gameOverUI.gameObject.SetActive(false);
		playerLife.playerUI.gameObject.SetActive(true);
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
    

	void decrementLives() {
		if (PlayerLife.lives == 0) PlayerLife.lives = 3;
		PlayerLife.countLives++;
        PlayerLife.lives--;
	}


	void disableObjects() {
		healthSlider.gameObject.SetActive(false);
        capsuleCollider.enabled = false;
        controlMovement.enabled = false;
	}
    
	IEnumerator MakeDead() {
        PushBack();
        myAnim.SetTrigger("Die");
        AudioSource.PlayClipAtPoint(monkeyAudio, transform.position, 1f);
        decrementLives();
        disableObjects();
		yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
