using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour {

	Vector3 diceVelocity;

	// Update is called once per frame
	void FixedUpdate () {
		diceVelocity = DiceScript.diceVelocity;
	}

	void OnTriggerStay(Collider col)
	{
		if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
		{
			switch (col.gameObject.name) {
			case "Side 1":
				DiceNumberTextScript.diceNumber = 1;
				break;
			case "Side 2":
				DiceNumberTextScript.diceNumber = 2;
				break;
			case "Side 3":
				DiceNumberTextScript.diceNumber = 3;
				break;
			case "Side 4":
				DiceNumberTextScript.diceNumber = 4;
				break;
			case "Side 5":
				DiceNumberTextScript.diceNumber = 5;
				break;
			case "Side 6":
				DiceNumberTextScript.diceNumber = 6;
				break;
			}
		}
	}
}
