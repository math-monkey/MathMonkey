using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenuObj;
	public GameObject optionsMenuObj;
	public GameObject instructionsMenuObj;
    public GameObject nameCanvasUI;
    public Input playerName;

    private void Start() {
        if (!PlayerPrefs.HasKey("score1")) {
            PlayerPrefs.SetInt("score1", 0);
            PlayerPrefs.SetInt("score2", 0);
            PlayerPrefs.SetInt("score3", 0);
        }
    }

    public void PlayGame() {
        PlayerPrefs.SetString("playerName", playerName.ToString());
		SceneManager.LoadScene("Level 1");
	}

    public void EnterName() {
        instructionsMenuObj.SetActive(false);
        mainMenuObj.SetActive(false);
        nameCanvasUI.SetActive(true);
    }

    public void QuitGame() {
		Application.Quit();
		Debug.Log("Quit");
	}

	public void OptionsMenu() {
		mainMenuObj.SetActive(false);
		optionsMenuObj.SetActive(true);
	}

	public void InstructionsMenu() {
		mainMenuObj.SetActive(false);
		instructionsMenuObj.SetActive(true);
	}

	public void Back() {
		optionsMenuObj.SetActive(false);
		instructionsMenuObj.SetActive(false);
		mainMenuObj.SetActive(true);
	}
}
