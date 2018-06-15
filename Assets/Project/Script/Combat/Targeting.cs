using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script voor clickable targeting

public class Targeting : MonoBehaviour {

	//voor visuele weergave target
	public GameObject targetIndicate;

	//om oude targets goed te verwerken
	private GameObject targetOld;
	public GameObject targetNew; //public voor andere scripts (skills)

	//afstand voor selectie bijhouden
	private float distance;
	public float maxDistance = 15;

	//om afstand van huidige target bij te houden.
	public bool targeted = false; //public voor andere scripts (skills)
	private float targetedDistance;
	public float targetedDistanceMax = 25;
	
	// Update is called once per frame
	void Update () {

		//kijkt of de targeted bool true is (wat betekend dat er een target is)
		if(targeted){

			//kijkt wat de afstand tussen de player en de target is.
			targetedDistance = Vector3.Distance(targetNew.transform.position, transform.position);

			//als de afstand te groot is word alle target informat gereset en de targetIndicate gedeactiveerd.
			if(targetedDistance > targetedDistanceMax){
				TargetReset();
			}

		}

		//als linker muis geklikt word
		if(Input.GetMouseButtonDown(0)){

			//raycast targeting based on tag copied from https://answers.unity.com/questions/1311004/onmousedown-with-tags.html
			//checked of het geklikte object targetable is aan de hand van "Target" tag.
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			
			//kijkt of er iets geraakt word
			if (Physics.Raycast(ray, out hitInfo))
			{

				//kijkt of wat er geraakt is een target is
				if (hitInfo.collider.gameObject.tag == "Target")
				{
					//maakt een variable van de target
					targetNew = hitInfo.collider.gameObject;

					//als er een nieuwe target is
					if(targetOld != targetNew){
						targetOld = targetNew;

						//bekijkt afstand tussen target en speler
						distance = Vector3.Distance(targetNew.transform.position, transform.position);

						//vergelijkt de afstand met de maximale afstand
						if(distance < maxDistance){

							//plaatst de targetIndicator boven de target en parent die.
							targetIndicate.transform.position = new Vector3(targetNew.transform.position.x, targetNew.transform.position.y + 3, targetNew.transform.position.z);
							targetIndicate.transform.SetParent(targetNew.transform);
							
							//zet de targetIndicate op actief
							targetIndicate.SetActive(true);

							//zorgt dat de targeted bool true is.
							targeted = true;

						}

					}

				}
			}

		}
	}

	//voor het resetten van target
	void TargetReset(){
		targetIndicate.transform.parent = null;
		targetNew = null;
		targetOld = null;
		targetIndicate.SetActive(false);
		targeted = false;
	}
}
