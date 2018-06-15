using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script om de speler errors te geven, want wie wil dat nou niet!

public class PlayerError : MonoBehaviour {

		//voor basic timer
	public bool change = false; //voor externe scripts
	private float timer;
	public int timeShown;

	//geeft de text weer
	public Text errorText;

	//voor geluid
	public AudioSource errorSound;

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

			//speelt een error geluid af als dat niet al gebeurt
			if(!errorSound.isPlaying){
				errorSound.Play();
			}

		}

		if(timer > 0){
			timer -= Time.deltaTime;
		}

		if(timer <= 0){
			errorText.text = " ";
		}


	}
}
