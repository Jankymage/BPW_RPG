using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//om credits weer af te sluiten

public class CreditsMenu : MonoBehaviour {

	public Button m_Back;

	// Use this for initialization
	void Start () {

		//voor initializatie knoppen
		Button back = m_Back.GetComponent<Button>();
		back.onClick.AddListener(Back);

	}
	
	private void Back(){
		gameObject.SetActive(false);
	}
}
