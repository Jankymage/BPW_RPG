using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//om het spel af te sluiten met esc zonder waarschuwing (it's not a bug, it's a feature)

public class ExitGame : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
