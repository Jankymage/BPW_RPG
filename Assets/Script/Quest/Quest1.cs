using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest1 : MonoBehaviour {

	public Image quest;
	public Image questFinished;
	public GameObject canvas; //voor plaatsing quest popup 
	//om cript van de quest uit te lezen (voor completion).
	public QuestFetch QuestFetch;
	
	//voor berekenen afstand tussen speler en NPC
	public Transform player;
	public float maxDistance = 5f;
	private float distance;
	//voor kijken of er al een quest te zien of actief is.
	private bool questView = false;
	private GameObject character;
	private bool questActive = false;
	private bool questComplete = false;


	//checken of er LMB op OBJECT gebruikt wordt
	//afstand berekenen > zodat niet vanaf overal geklikt kan worden
	//als quest nog niet geacepteerd is screen poppen



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
		if(distance <= maxDistance && !questView && !questActive){
			Instantiate(quest, canvas.transform);
		}

	//kijkt of het questComlete text bestaat in het QuestFetch script (op de player)
		questComplete = QuestFetch.questComplete;

		//Als de quest voldaan is, zal er een popup komen om de quest in te leveren.
		if(distance <= maxDistance && questComplete){
			Debug.Log("ingeleverd!");
			Instantiate(questFinished, canvas.transform);
		}

		// if(distance <= maxDistance && !questView && !questActive){
		// 	Instantiate(quest, canvas.transform);
		// }

	}

	
}
