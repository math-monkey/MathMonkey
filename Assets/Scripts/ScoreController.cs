﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public GameObject scoreUI;

    public static void AppendScore() {
        int score1 = PlayerPrefs.GetInt("score1");
        int score2 = PlayerPrefs.GetInt("score2");
        int score3 = PlayerPrefs.GetInt("score3");

        if (PlayerScore.playerScore > score1) {
            PlayerPrefs.SetInt("score2", score1);
            PlayerPrefs.SetInt("score3", score2);
            PlayerPrefs.SetInt("score1", PlayerScore.playerScore);
        } else if (PlayerScore.playerScore > score2) {
            PlayerPrefs.SetInt("score3", score2);
            PlayerPrefs.SetInt("score2", PlayerScore.playerScore);
        } else if (PlayerScore.playerScore > PlayerPrefs.GetInt("score3")) {
            PlayerPrefs.SetInt("score3", PlayerScore.playerScore);
        }

        Debug.Log("score1 = " + PlayerPrefs.GetInt("score1"));
        Debug.Log("score2 = " + PlayerPrefs.GetInt("score2"));
        Debug.Log("score3 = " + PlayerPrefs.GetInt("score3"));
    }
}
