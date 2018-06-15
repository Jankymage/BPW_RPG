using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script wat er voor zorgt dat de speler wederkeert uit de dood.

public class PlayerRespawn : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//als de speler dood is, keert deze terug naar een spawnpoint en is health gereset
		if(Player.GetComponent<PlayerStats>().health <= 0){
			Player.GetComponent<PlayerStats>().health = Player.GetComponent<PlayerStats>().startHealth;
			Player.transform.position = transform.position;
		}
	}
}
