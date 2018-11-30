using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberController : ObjectController {

	public Text enemyNumberUI;
	int enemyNumber;

	void Start() {
        UpdateValue();
	}

	public override int GetNumber() {
		return enemyNumber;
	}

	public override void UpdateValue() {
		int idx = Random.Range(0, NumberHelper.availableNumbers.Length);
		enemyNumber = NumberHelper.availableNumbers[idx];
		enemyNumberUI.text = enemyNumber.ToString();
	}
}
