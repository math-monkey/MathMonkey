using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.tag == "Player") {
			PlayerHealth playerFell = other.GetComponent<PlayerHealth>();
			playerFell.pushBackForce = 35f;
			playerFell.Death();
		}
	}
}
