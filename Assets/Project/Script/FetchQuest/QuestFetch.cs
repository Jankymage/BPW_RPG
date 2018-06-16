using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//de fetchquest zelf, moet non actief op de player geplaatst worden.

public class QuestFetch : MonoBehaviour {

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

	//voor afspelen eind animatie
	public bool questFinish = false;

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
			questTextParent = GameObject.Find("QuestFetchText(Clone)");
			Destroy(questTextParent);

			//maak een nieuwe text aan (bestaan van deze text werkt ook als bool)
			questComplete = Instantiate(questText, canvas.transform);
			questComplete.text = "Quest Complete!";

			//speelt geluid af
			completeSound.Play();

			//voor finish script
			questFinish = true;

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
