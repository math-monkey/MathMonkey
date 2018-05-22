using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    public Text scoreText;

    public static int playerScore;

    // Use this for initialization
    void Start () {
        PlayerScore.playerScore = 0;
		scoreText.text = PlayerScore.playerScore.ToString();
    }
   
    // Update is called once per frame
    void Update () {
		
    }

	public void AddScore(int score) {
		PlayerScore.playerScore += score;
		scoreText.text = PlayerScore.playerScore.ToString();
	}
}
