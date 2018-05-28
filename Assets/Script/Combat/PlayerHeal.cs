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
		if(Input.GetKeyDown(KeyCode.Alpha2)){
				
		//checked of player niet max health is.
		if(gameObject.GetComponent<PlayerStats>().health < gameObject.GetComponent<PlayerStats>().startHealth){
			
				if(cooldown <= 0){
				
					//healt de player.
					gameObject.GetComponent<PlayerStats>().health += healAmount;
					//zorgt er voor dat de cooldown gaat lopen
					cooldown = cooldownMax;
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
