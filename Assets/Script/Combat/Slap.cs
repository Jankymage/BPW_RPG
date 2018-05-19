using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slap : MonoBehaviour {

	//script voor basic combat move

	public float cooldown = 2;
	private float cooldownCurrent = 0;

	public Text cooldownText;


	//button press
	//check cooldown
	//check distance to target
	//deal damage
	//set cooldown

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//als cooldown niet 0 is kan skill niet gebruikt
		//als cooldown boven 0 is timer laten lopen

		if(cooldownCurrent > 0){
			cooldownCurrent -= Time.deltaTime;
		}

		cooldownText.text = "Slap Cooldown: " + (Mathf.CeilToInt(cooldownCurrent)).ToString();

		if(Input.GetKeyDown(KeyCode.Alpha1) && cooldownCurrent <= 0){
			Debug.Log("1");

			cooldownCurrent = cooldown;

		}
		
	}
}
