using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberController : MonoBehaviour {

	public Text enemyNumberUI;
	int enemyNumber;

	void Start() {
		int idx = Random.Range(0, NumberHelper.availableNumbers.Length);
		enemyNumber = NumberHelper.availableNumbers[idx];
		enemyNumberUI.text = enemyNumber.ToString();
	}

	public int GetNumber() {
		return enemyNumber;
	}
}
