﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectInstantiateList : MonoBehaviour {

//script voor het instantiaten van plekken rondom NPC
// en respawnen van de collectables als deze opgepakt zijn.

	//voor het aanmaken van de lijst en het vullen met de collectables
	public int amount;
	List <GameObject> objects;
	public GameObject collectable;
	public float locationX = 15;
	public float locationZ = 15;

	//voor het respawnen
	List <float> timers;
	public float respawnTimer = 5f;

	// Use this for initialization
	void Start () {

		timers = new List<float>();
		for(int i = 0; i < amount; i++){
			timers.Add(0f);
		}

		//maakt de lijst en vult deze met collactables op random location rondom de NPC.
		objects = new List<GameObject>();
		for(int i = 0; i < amount; i++){
			Vector3 location = transform.position;
			location.x += Random.Range(-locationX, locationX);
			location.z += Random.Range(-locationZ, locationZ);
			objects.Add( Instantiate(collectable, location, transform.rotation) );
		}
	}
	
	// Update is called once per frame
	void Update () {

		//zet een timer als een object in de objects lijst niet actief is
		//als deze timer is afgelopen word het object weer actief.
		for(int i = 0; i < amount; i++){
			if(!objects[i].activeSelf){
				if(timers[i] <= 0){
					timers[i] = respawnTimer;
				}
				if(timers[i] > 0){
					timers[i] -= Time.deltaTime;
						if(timers[i] <= 0){
						objects[i].SetActive(true);
					}
				}
			}
		}
	}
}
