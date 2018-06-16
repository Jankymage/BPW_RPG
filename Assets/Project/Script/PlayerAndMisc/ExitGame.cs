using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script om het menu actief te maken waarmee je naar het startscherm gaat (en menu laat controlls zien)

public class ExitGame : MonoBehaviour {

	public GameObject menu;

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			menu.SetActive(true);
		}
	}
}
