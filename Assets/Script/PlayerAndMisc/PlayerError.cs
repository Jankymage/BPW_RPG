using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerError : MonoBehaviour {

	//script voor player error text element

	//leegmaken text object na enige tijd dat er een error weergegeven word.
	//zodat deze niet tot in de eeuwigheid blijft staan.

	//voor basic timer
	public bool change = false; //voor externe scripts
	private float timer;
	public int timeShown;

	public Text errorText;


	// Use this for initialization
	void Start () {
		errorText.text = " ";
	}
	
	// Update is called once per frame
	void Update () {
		
		//om de timer te beginnen, change word aangezet door extern script, maakt text leeg als timer is afgelopen
		if(change){
			timer = timeShown;
			change = false;
		}

		if(timer > 0){
			timer -= Time.deltaTime;
		}

		if(timer <= 0){
			errorText.text = " ";
		}


	}
}
