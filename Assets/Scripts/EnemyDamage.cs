using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	public float damage;
	public float damageRate;
    
	float nextDamage;

	// Use this for initialization
	void Start () {
		nextDamage = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.tag == "Player" && nextDamage < Time.time) {
			PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
			playerHealth.AddDamage(damage);
			nextDamage = Time.time + damageRate;

			playerHealth.PushBack();
		}
	}
}
