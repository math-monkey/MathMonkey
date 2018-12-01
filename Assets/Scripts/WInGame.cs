using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WInGame : MonoBehaviour {

    public GameObject character;
    PlayerController playerController;
    public GameObject playerUI;
    public GameObject winUI;
    public AudioClip winSound;

    // Use this for initialization
	void Start () {
        playerController = character.GetComponent<PlayerController>();
	}

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            StartCoroutine("WalkAway");
        }
    }

    IEnumerator WalkAway() {
        ScoreController.AppendScore();
        playerController.myAnim.SetTrigger("Win");
        yield return new WaitForSeconds(1.5f);
        character.gameObject.SetActive(false);
        playerUI.SetActive(false);
        winUI.SetActive(true);
        PlayerLife.mainAudio.Stop();
        AudioSource.PlayClipAtPoint(winSound, transform.position, 1f);
    }
}
