using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	//script voor op targets met stats

	//voor het bijhouden van health
	public int health;

	//voor het resetten van de health
	public int startHealth = 100;

	//voor het weergeven van de healt
	public Text healthText;

	//voor de audio
	public AudioSource deathSound;


	// Use this for initialization
	void Start () {
		health  = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
		//als player dood is speelt er een geluid (ander script reset de player)
		if(health <= 0){

			deathSound.Play();
		}

	healthText.text = "Health: " + health.ToString();

	}
}
