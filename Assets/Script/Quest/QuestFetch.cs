using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestFetch : MonoBehaviour {

	//als quest accepted: deze quest actief maken
		//instantiate tracker
	//als object opgepakt > update tracker
	//als alles gepakt > quest complete	
	
	//TODO:
	//quest inleveren.

	//voor het tellen van de objecten.
	private int count = 0;
	public int countMax = 10;
	public Text questText;
	private Text questTextUpdate;
	public Text questComplete; //public voor Quest1 script
	public GameObject canvas; //voor plaatsing questText

	// Use this for initialization
	void Start () {

		count  = 0;
		
		//maakt een text aan om de status van de quest bij te houden en zet deze op 0
		questTextUpdate = Instantiate(questText, canvas.transform);
		SetCountText();
	}
	
	// Update is called once per frame
	void Update () {

		//als de quest is afgerond
		if(count >= countMax && !questComplete){

			//vermoord de quest update text
			Destroy(questTextUpdate);

			//maak een nieuwe text aan (bestaan van deze text werkt ook als bool)
			questComplete = Instantiate(questText, canvas.transform);
			questComplete.text = "Quest Complete!";
		}
		 
	}

	private void OnTriggerEnter(Collider other){

		//zorgt dat dit deel niet word uitgevoerd als het script niet enabled is.
		if (!enabled) return;

		//als er een collectable gepakt word en de quest nog niet afgerond is,
		//gaat de count omhoog
		if(other.CompareTag("Collectable") && !questComplete){
			count += 1;
			other.gameObject.SetActive(false);
			
			SetCountText();
		}
		
	}

	//update de quest text
	private void SetCountText(){
		questTextUpdate.text = "Count: " + count.ToString() + " / " + countMax.ToString();
	}

}
