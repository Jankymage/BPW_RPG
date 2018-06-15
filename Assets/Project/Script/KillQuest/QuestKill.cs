using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//quest voor de kill quest, moet non actief op de player geplaats worden

public class QuestKill : MonoBehaviour {

	//voor het tellen van de objecten.
	private int count = 0;
	public int countMax = 10;
	public Text questText;
	private Text questTextUpdate;
	public Text questComplete; //public voor andere scripts
	public GameObject canvas; //voor plaatsing questText

	//om de parent van de questTextUpdate te vermoorden
	private GameObject questTextParent;

	//voor herspeelbare quest
	public bool questTextUpdateBool = false;

	//voor geluid
	public AudioSource collectSound;
	public AudioSource completeSound;

	// Use this for initialization
	void Start () {
		
		//maakt een text aan om de status van de quest bij te houden en zet deze op 0
		questTextUpdate = Instantiate(questText, canvas.transform);
		SetCountText();

	}
	
	// Update is called once per frame
	void Update () {
		
		//zorgt dat questTextUpdate bestaat als de quest gereset is.
		if(questTextUpdateBool){
			questTextUpdate = Instantiate(questText, canvas.transform);
			count = 0;
			SetCountText();
			questTextUpdateBool = false;
		}

		//als de quest is afgerond
		if(count >= countMax && !questComplete){

			//vermoord de quest update text
			questTextParent = GameObject.Find("QuestKillText(Clone)");
			Destroy(questTextParent);

			//maak een nieuwe text aan (bestaan van deze text werkt ook als bool)
			questComplete = Instantiate(questText, canvas.transform);
			questComplete.text = "Quest Complete!";

			//speelt geluid af
			completeSound.Play();

		}
		 
	}

	private void OnTriggerEnter(Collider other){

		//zorgt dat dit deel niet word uitgevoerd als het script niet enabled is.
		if (!enabled) return;

		//als er een collectable gepakt word en de quest nog niet afgerond is,
		//gaat de count omhoog
		if(other.CompareTag("KillCollectable") && !questComplete){
			count += 1;
			Destroy(other.gameObject);

			//speelt geluid af
			collectSound.Play();
			
			SetCountText();
		}
		
	}

	//update de quest text
	private void SetCountText(){
		questTextUpdate.text = "Count: " + count.ToString() + " / " + countMax.ToString();
	}

}
