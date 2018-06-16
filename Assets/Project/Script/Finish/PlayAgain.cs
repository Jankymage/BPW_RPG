using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script om info uit te zetten en camera weer te switchen

public class PlayAgain : MonoBehaviour {

	//voor camera switch
	public GameObject mainCamera;
	public GameObject finishCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//als de muis 0 word geklikt switched de camera en word de info weer uitgezet.
		if(Input.GetMouseButtonDown(0)){
			mainCamera.SetActive(true);
			finishCamera.SetActive(false);
			gameObject.SetActive(false);
		}
	}
}
