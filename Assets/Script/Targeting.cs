using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour {

//script voor clickable targeting


//TODO:
//alleen als in buurt is
//BOVEN target spawnen (parenting?)
//actief/deactief (dood of in buurt)
//

	//voor visuele weergave target
	public Transform targetIndicate;

	private GameObject targetOld;
	private GameObject targetNew;

	// Use this for initialization
	void Start () {
		//Instantiate(targetIndicate);
	}
	
	// Update is called once per frame
	void Update () {

		//als linker muis geklikt word
		if(Input.GetMouseButtonDown(0)){

			//raycast targeting based on tag copied from https://answers.unity.com/questions/1311004/onmousedown-with-tags.html
			//checked of het geklikte object targetable is aan de hand van "Target" tag.
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			
			if (Physics.Raycast(ray, out hitInfo))
			{

					if (hitInfo.collider.gameObject.tag == "Target")
					{

					Debug.Log(hitInfo.collider.gameObject);

					targetNew = hitInfo.collider.gameObject;

					//als er een nieuwe target is
					if(targetOld != targetNew){
						targetOld = targetNew;

						//plaatst de targetIndicator boven de target.
						targetIndicate.position = (targetNew.transform.position);

					}

				}
			}

		}
	}
}
