using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFetch : MonoBehaviour {

	//als quest accepted: deze quest actief maken
		//instantiate tracker
	//als object opgepakt > update tracker
	//als alles gepakt > quest complete	

	private int count;
	public int countMax = 10;

	// Use this for initialization
	void Start () {
		count  = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other){
		if(other.CompareTag("Collectable")){
			count += 1;
			other.gameObject.SetActive(false);
		}
	}
}
