using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script om schene aan eind van het spel weer te geven.

public class Finish : MonoBehaviour {

	//spawned brouw als beide quest scripts een finished bool true hebben
	//zet nieuwe camera aan om het te filmen
	//animation controller > brouw naar beneden > brouw deinend
	//quest bools weer false zodat opnieuw gespeeld kan worden
	//text met "game finished" oid
	//particle effect op brouw

	//voor instantiate brouw
	public GameObject brouw;
	private Vector3 spawnlocation;

	//voor checken eind spel
	public QuestKill questKill;
	public QuestFetch questFetch;

	public GameObject mainCamera;
	public GameObject finishCamera;

	//timer voor aanzetten info
	public float waitTime = 3.5f;
	private float timer = 0;
	public GameObject finishInfo;
	private bool infoBool = false;

	// Use this for initialization
	void Start () {
		spawnlocation = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		//als beide quests compleet zijn instantiate de "prijs"
		if(questKill.questFinish && questFetch.questFinish){
			
			//switched van camera
			mainCamera.SetActive(false);
			finishCamera.SetActive(true);

			//Instantiate het brouw object.
			Instantiate(brouw, spawnlocation, transform.rotation);

			//reset de bools van de scripts, zodat quest opnieuw volbracht kan worden
			questKill.questFinish = false;
			questFetch.questFinish = false;

			//zorgt er voor dat het nieuwe object naast het vorige geins
			spawnlocation.z += 5;

			//voor timer info
			timer = waitTime;
			infoBool = true;

		}

		//timer voor info laten lopen
		if(timer > 0){
			timer -= Time.deltaTime;
		}

		//als de timer is afgelopen zet hij de text op actief. bool zorgt er voor dat text niet blijft spawnen.
		if(timer <= 0 && infoBool){
			finishInfo.SetActive(true);
			infoBool = false;
		}

	}
}
