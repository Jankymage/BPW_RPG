using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetFrame : MonoBehaviour {

	//scipt voor de target frames

	public Targeting Targeting;
	public Stats Stats;

	public GameObject targetFrame;

	public Text targetName;
	public Text targetHealth;

	// Use this for initialization
	void Start () {
		targetFrame.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		//zet het frame actief als er een target is en vult de gegevens van naam en health in.
		if(Targeting.targeted){
			targetFrame.SetActive(true);
			targetName.text = Targeting.targetNew.ToString();
			targetHealth.text = Targeting.targetNew.GetComponent<Stats>().health.ToString();
		}

		// //als de health van de target 0 is word het frame nonactief.
		// if(Targeting.targetNew.GetComponent<Stats>().health <= 0){
		// 	targetFrame.SetActive(false);
		// }
		
		//als er geen target is word het frame nonactief
		if(!Targeting.targeted){
			targetFrame.SetActive(false);
		}

	}
}
