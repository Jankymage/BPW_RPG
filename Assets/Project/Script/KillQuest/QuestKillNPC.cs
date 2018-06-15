using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script voor de fetch quest NPC
//checked de staat van de quest en spawned aan de hand daarvan een quest window om de quest te starten of af te sluiten

public class QuestKillNPC : MonoBehaviour {

	public Image quest;
	public Image questFinished;

	//voor plaatsing quest popup
	public GameObject canvas;  

	//om script van de quest uit te lezen (voor completion).
	public QuestKill QuestKill;
	
	//voor berekenen afstand tussen speler en NPC
	public Transform player;
	public float maxDistance = 5f;
	private float distance;

	//voor kijken of er al een quest te zien of actief is.
	private bool questView = false;
	private GameObject character;
	private bool questActive = false;
	private bool questComplete = false;

	// Use this for initialization
	void Start () {
		character = GameObject.FindWithTag("Player");
	}
	

	//als de linker muisklik word gedaan op de NPC van dit script.
	void OnMouseDown(){
		
		//checked of er al een questpopup is
		questView = GameObject.FindWithTag("QuestPopUp");

		//of dat de quest al actief is
		if (character.GetComponent<QuestKill>().enabled == true){
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

	//kijkt of het questComlete text bestaat in het QuestKill script (op de player)
		questComplete = QuestKill.questComplete;

		//Als de quest voldaan is, zal er een popup komen om de quest in te leveren.
		if(distance <= maxDistance && questComplete){
			Instantiate(questFinished, canvas.transform);
		}

	}

}
