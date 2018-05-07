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
	//voor kijken of er al een quest te zien of actief is.
	private bool questView = false;
	private GameObject character;
	private bool questActive = false;


	//checken of er LMB op OBJECT gebruikt wordt
	//afstand berekenen > zodat niet vanaf overal geklikt kan worden
	//als quest nog niet geacepteerd is screen poppen

	//TODO:
	//checken of de quest nog niet actief is.


	// Use this for initialization
	void Start () {
		character = GameObject.FindWithTag("Player");
	}
	

	//als de linker muisklik word gedaan op de NPC van dit script.
	void OnMouseDown(){
		
		//checked of er al een questpopup is
		questView = GameObject.FindWithTag("QuestPopUp");
		//of dat de quest al actief is
		if (character.GetComponent<QuestFetch>().enabled == true){
			questActive = true;
		}
		else{
			questActive = false;
		}

		//berekende de afstand tussen speler en NPC
		distance = Vector3.Distance(player.position, transform.position);

		//als de afstand tussen NPC en speler kleiner is dan 5f en er niet al 
		//een quest te zien of actief is word er een questobject opgeroepen.
		if(distance <= 5f && !questView && !questActive){
			Instantiate(quest, canvas.transform);
		}

	}

	
}
