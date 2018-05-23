using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public GameObject mainMenuObj;
	public GameObject optionsMenuObj;
	public GameObject instructionsMenuObj;

	public void PlayGame() {
		SceneManager.LoadScene("Main");
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
