using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//scipt voor de target frames

public class TargetFrame : MonoBehaviour {

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
		
		//als er geen target is word het frame nonactief
		if(!Targeting.targeted){
			targetFrame.SetActive(false);
		}

	}
}
