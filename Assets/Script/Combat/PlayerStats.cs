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

	public Text healthText;


	// Use this for initialization
	void Start () {
		health  = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
		//als health 0 of lager is verdwijnt de target
		if(health <= 0){
			gameObject.SetActive(false);
		}

	healthText.text = "Health: " + health.ToString();

	}
}
