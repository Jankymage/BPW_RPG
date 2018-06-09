using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

	//script wat er voor zorgt dat de speler wederkeert uit de dood.

	public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.GetComponent<PlayerStats>().health <= 0){
			Player.GetComponent<PlayerStats>().health = Player.GetComponent<PlayerStats>().startHealth;
			Player.SetActive(true);
			Player.transform.position = transform.position;
		}
	}
}
