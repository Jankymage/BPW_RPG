using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	//script voor op targets met stats

	//voor het bijhouden van health
	public int health = 100;

	//voor het resetten van de health
	public int startHealth = 100;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//als health 0 of lager is verdwijnt de target
		if(health <= 0){
			gameObject.SetActive(false);
		}

	}
}
