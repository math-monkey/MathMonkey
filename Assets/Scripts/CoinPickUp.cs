using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour {

    public static int coinValue;
    public AudioClip coinAudio;

    // Use this for initialization
    void Start () {
        coinValue = 10;
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            AudioSource.PlayClipAtPoint(coinAudio, other.transform.position, 1f);
            PlayerScore playerScore = other.gameObject.GetComponent<PlayerScore>();
            playerScore.AddScore(coinValue);
            Destroy(gameObject);
        }
    }
}
