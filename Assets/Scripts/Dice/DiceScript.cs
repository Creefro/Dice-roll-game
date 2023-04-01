using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{

	static Rigidbody rb;
	public static Vector3 diceVelocity;

	public GameObject dice;

	Vector3 accelerationDir;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		transform.rotation = Random.rotation;
	}

	// Update is called once per frame
	void Update()
	{
		diceVelocity = rb.velocity;
		accelerationDir = Input.acceleration;

		if (RollNumberTextScript.roll == 0)
		{
			Debug.Log("Hakkýnýz doldu");
			dice.SetActive(false);
		}
		if (Input.GetKeyDown(KeyCode.Space) || accelerationDir.sqrMagnitude >= 5f)
		{
			RollNumberTextScript.roll--;

			DiceNumberTextScript.diceNumber = 0;

			float dirX = Random.Range(0, 500);
			float dirY = Random.Range(0, 500);
			float dirZ = Random.Range(0, 500);
			transform.position = new Vector3(0, 20, 0);
			transform.rotation = Quaternion.identity;
			rb.AddForce(transform.up * 500);
			rb.AddTorque(dirX, dirY, dirZ);

		}
	}
}
