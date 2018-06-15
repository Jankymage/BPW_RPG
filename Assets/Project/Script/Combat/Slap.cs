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

	//voor het weergeven van errors
	public Text errorText;
	public PlayerError PlayerError;

	//voor het gebruiken van de skill op de target
	public Targeting Targeting;

	//voor het aanpassen van de stats op target
	public Stats Stats;
	
	//voor de animatie en geluid
	public Animation anim;
	public AudioSource SlapSound;


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

		if(Input.GetKeyDown(KeyCode.Space)){

			if(cooldownCurrent <= 0){
				
				//kijkt of er een target is
				if(Targeting.targeted){

					//kijkt of target dichtbij genoeg is en er niet een skill word gebruikt
					if(Vector3.Distance(Targeting.targetNew.transform.position, transform.position) <= maxDistance && !anim.IsPlaying("skill")){
					
						//zorgt er voor dat de cooldown gaat lopen
						cooldownCurrent = cooldown;

						//zorgt er voor dat de damage aan de healt van de target word gedaan
						Targeting.targetNew.GetComponent<Stats>().health -= damage;
						
						//speelt de animatie
						anim.Play("attack");

						//speelt het geluid
						SlapSound.Play();

						//zorgen dat de target nonactief word als target dood gaat.
						if(Targeting.targetNew.GetComponent<Stats>().health <= 0){
							Targeting.targeted = false;
						}

					}

			//else statements voor player errors, plaatst de text en zet de timer aan van de text
					else{
					errorText.text = "Target Too Far Away";
					PlayerError.change = true;
					}
					
				}

				else{
				errorText.text = "No Target";
				PlayerError.change = true;
				}

			}

			else{
				errorText.text = "On Cooldown";
				PlayerError.change = true;
			}
			
		}
		
	}
	
}
