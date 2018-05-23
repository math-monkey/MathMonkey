using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {
    
    //player life
	public Image[] playerLives;
	public RectTransform playerUI;
    public RectTransform scoreUI;
	public RectTransform gameOverUI;
    public Slider healthSlider;
    public AudioSource gameAudio;
    public static AudioSource mainAudio;
    public AudioClip gameoverAudio;

    public static int lives;
    public static int countLives;

    // Use this for initialization
    void Start () {
        PlayerLife.mainAudio = gameAudio;
        PlayerLife.mainAudio.loop = true;
        PlayerLife.mainAudio.Play();
		if (PlayerLife.countLives != 0) {
           checkLife();
        }
    }
    
    // Update is called once per frame
    void Update () {
        
    }
    
	public void checkLife() {
		if (PlayerLife.lives == 2 && playerLives.Length >= 2) {
			removeLife(playerLives[2]);
		} else if (PlayerLife.lives == 1 && playerLives.Length >= 1) {
			removeLife(playerLives[2]);
            removeLife(playerLives[1]);
        }else if (PlayerLife.lives == 0) {
            gameOver();
        }
    }

    void removeLife(Image playerLifeImg) {
        playerLifeImg.enabled = false;
        float difference = healthSlider.transform.position.x - playerLifeImg.transform.position.x;
        Vector3 temp = healthSlider.transform.position; // copy to an auxiliary variable...
        temp.x = healthSlider.transform.position.x - difference + 5; // modify the component you want in the variable...
        healthSlider.transform.position = temp;
    }

	void gameOver() {
        PlayerLife.mainAudio.Stop();
        AudioSource.PlayClipAtPoint(gameoverAudio, transform.position, 1f);
        transform.gameObject.SetActive(false);
        playerUI.gameObject.SetActive(false);
        scoreUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);
	}
}
