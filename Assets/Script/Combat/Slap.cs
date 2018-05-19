using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slap : MonoBehaviour {

	//script voor basic combat move

	//voor het berekenen van de cooldown
	public float cooldown = 2;
	private float cooldownCurrent = 0;

	//voor voor berekenen maximale afstand skill
	public float maxDistance = 3;

	//voor instellen hoeveel damage
	public int damage = 10;

	//voor het weergeven van de cooldown
	public Text cooldownText;

	//voor het gebruiken van de skill op de target
	public Targeting Targeting;

	//voor het aanpassen van de stats op target
	public Stats Stats;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log(Targeting.targetNew.transform.position);

		//als de cooldown niet klaar is, word de cooldown gereset
		if(cooldownCurrent > 0){
			cooldownCurrent -= Time.deltaTime;
		}
		
		//geeft de cooldowntijd weer in seconden
		cooldownText.text = "Slap Cooldown: " + (Mathf.CeilToInt(cooldownCurrent)).ToString();

		if(Input.GetKeyDown(KeyCode.Alpha1) && cooldownCurrent <= 0){
			
			//kijkt of er een target is
			if(Targeting.targeted){

				//kijkt of target dichtbij genoeg is.
				if(Vector3.Distance(Targeting.targetNew.transform.position, transform.position) <= maxDistance){
				
					//zorgt er voor dat de cooldown gaat lopen
					cooldownCurrent = cooldown;

					//zorgt er voor dat de damage aan de healt van de target word gedaan
					Targeting.targetNew.GetComponent<Stats>().health -= damage;

				}
				
			}
			
		}
		
	}
	
}
