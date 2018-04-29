using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest1 : MonoBehaviour {

	public Image quest;
	public GameObject canvas; //voor plaatsing quest popup 
	
	//voor berekenen afstand tussen speler en NPC
	public Transform player;
	private float distance;
	//voor kijken of er al een quest te zien is.
	private bool questView = false;


	//checken of er LMB op OBJECT gebruikt wordt
	//afstand berekenen > zodat niet vanaf overal geklikt kan worden
	//als quest nog niet geacepteerd is screen poppen

	//TODO:
	//zorgen dat quest popup iets doet


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	//als de linker muisklik word gedaan op de NPC van dit script.
	void OnMouseDown(){
		
		//checked of er al een questpopup is
		questView = GameObject.FindWithTag("QuestPopUp");

		//berekende de afstand tussen speler en NPC
		distance = Vector3.Distance(player.position, transform.position);

		//als de afstand tussen NPC en speler kleiner is dan 5f en er niet al een quest te zien is
		//word er een questobject opgeroepen.
		if(distance <= 5f && !questView){
			Instantiate(quest, canvas.transform);
		}

	}

	
}
