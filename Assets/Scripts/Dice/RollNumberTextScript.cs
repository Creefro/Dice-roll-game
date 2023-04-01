using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollNumberTextScript : MonoBehaviour
{
	Text text;
	public static int roll;

	// Use this for initialization
	void Start()
	{
		text = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update()
	{
		text.text = Mathf.Ceil(roll/2).ToString();
	}
}
