using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script voor het bijhouden van de health stat van enemies

public class Stats : MonoBehaviour {

	//voor het bijhouden van health
	public int health;

	//voor het resetten van de health
	public int startHealth = 100;

	//voor het afsprelen van geluid
	private AudioSource deathSound;
	private GameObject audioFind;

	// Use this for initialization
	void Start () {
		health  = startHealth;

		//zoekt het object waar de audiosource aan hangt en pakt de audiosource.
		audioFind = GameObject.Find("EnemyDead");
		deathSound = audioFind.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//als health 0 of lager is verdwijnt de target
		if(health <= 0){
			gameObject.SetActive(false);

			//speelt geluid af als enemy dood gaat
			deathSound.Play();
		}

	}
}
