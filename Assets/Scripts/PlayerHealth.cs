using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float fullHealth;
	public float pushBackForce;
	public Image playerLife1;
    public Image playerLife2;
    public Image playerLife3;
    public RectTransform numPlayerLives;

	static int lives;
	static int countLives;
    
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

		if (lives == 0) {
			PlayerHealth.lives = 3;	
		}
       
		if(PlayerHealth.countLives != 0) {
		    checkLife();	
		}
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

	void checkLife() {
		if(PlayerHealth.lives == 2) {
			removeLife(playerLife3);
		} else if(PlayerHealth.lives == 1) {
			removeLife(playerLife3);
			removeLife(playerLife2);
		} else if (PlayerHealth.lives == 0) {
			//gameOver();
		}
	}

	void removeLife(Image playerLifeImg) {
        playerLifeImg.enabled = false;
        float difference = healthSlider.transform.position.x - playerLifeImg.transform.position.x;
        Vector3 temp = healthSlider.transform.position; // copy to an auxiliary variable...
        temp.x = healthSlider.transform.position.x - difference + 5; // modify the component you want in the variable...
        healthSlider.transform.position = temp;
    }

	public void Death() {
		StartCoroutine("MakeDead");
	}
    
     IEnumerator MakeDead() {
		PlayerHealth.countLives++;
        PlayerHealth.lives--;
		Debug.Log(PlayerHealth.lives);
		PushBack();
		healthSlider.gameObject.SetActive(false);
		capsuleCollider.enabled = false;
		controlMovement.enabled = false;
        myAnim.SetTrigger("Die");
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("Main");
	}
}
