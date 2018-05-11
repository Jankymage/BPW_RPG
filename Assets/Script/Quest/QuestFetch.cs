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
	//tracker > fixen dat hij goed update

	//voor het tellen van de objecten.
	private int count;
	public int countMax = 10;
	public Text questText;
	public GameObject canvas; //voor plaatsing questText

	// Use this for initialization
	void Start () {
		count  = 0;
		Debug.Log("quest actief");
		Instantiate(questText, canvas.transform);
	}
	
	// Update is called once per frame
	void Update () {
		//voor weergeven huidige status telling
		 SetCountText();
	}

	private void OnTriggerEnter(Collider other){

		//zorgt dat dit deel niet word uitgevoerd als het script niet enabled is.
		if (!enabled) return;

		//als er een collectable gepakt word, gaat de count omhoog
		if(other.CompareTag("Collectable")){
			count += 1;
			other.gameObject.SetActive(false);
			
			
			Debug.Log(count);
		}

		if(count >= countMax){
			Debug.Log("quest complete!");
		}
		
	}

	private void SetCountText(){
		//questText.text = count.ToString();
		questText.text = "Count: " + count.ToString() + " / " + countMax.ToString();
	}

}
