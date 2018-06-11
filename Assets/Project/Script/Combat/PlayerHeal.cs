using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeal : MonoBehaviour {

	//script voor een healskill;

	public float cooldownMax = 5f;
	private float cooldown;
	public int healAmount;

	public Text cooldownText;
	public Text errorText;
	public PlayerError PlayerError;

	public Animation anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//als de cooldown niet klaar is, word de cooldown gereset
		if(cooldown > 0){
			cooldown -= Time.deltaTime;
		}
		
		//geeft de cooldowntijd weer in seconden
		cooldownText.text = "Heal Cooldown: " + (Mathf.CeilToInt(cooldown)).ToString();

		//als de knop ingedrukt word.
		if(Input.GetKeyDown(KeyCode.Q)){
				
		//checked of player niet max health is en er niet een attack word gedaan.
		if(gameObject.GetComponent<PlayerStats>().health < gameObject.GetComponent<PlayerStats>().startHealth  && !anim.IsPlaying("attack")){
			
				if(cooldown <= 0){
				
					//healt de player.
					gameObject.GetComponent<PlayerStats>().health += healAmount;
					//zorgt er voor dat de cooldown gaat lopen
					cooldown = cooldownMax;
					//speelt de animatie
					anim.Play("skill");
					
				}
				
				else{
					errorText.text = "On Cooldown";
					PlayerError.change = true;
				}
			}

			else{
				errorText.text = "Max health";
				PlayerError.change = true;
			}

		}
		
	}

}
