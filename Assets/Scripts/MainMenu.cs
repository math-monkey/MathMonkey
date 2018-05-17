using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
	public GameObject mainMenuObj;
	public GameObject optionsMenuObj;

	public void PlayGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
	}

	public void QuitGame() {
		Application.Quit();
		Debug.Log("Quit");
	}
    
	public void OptionsMenu() {
		SceneManager.LoadScene("OptionsMenu");
	}

	public void Back() {
		SceneManager.LoadScene("MainMenu");
	}
}
