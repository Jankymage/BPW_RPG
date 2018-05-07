using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFetch : MonoBehaviour {

	//als quest accepted: deze quest actief maken
		//instantiate tracker
	//als object opgepakt > update tracker
	//als alles gepakt > quest complete	

	//voor het tellen van de objecten.
	private int count;
	public int countMax = 10;

	// Use this for initialization
	void Start () {
		count  = 0;
		Debug.Log("quest actief");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other){

		//zorgt dat dit deel niet word uitgevoerd als het script niet enabled is.
		if (!enabled) return;

		//als er een collectable gepakt word, gaat de count omhoog
		if(other.CompareTag("Collectable")){
			count += 1;
			other.gameObject.SetActive(false);
		}

		if(count >= countMax){
			Debug.Log("quest complete!");
		}
		
	}
}
