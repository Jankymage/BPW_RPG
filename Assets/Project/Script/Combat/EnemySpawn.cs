using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//dit script spawned en respawned de enemies 

public class EnemySpawn : MonoBehaviour {

	//voor het spawnen van de enemies
	public int amount;
	List <GameObject> objects;
	public GameObject enemy;
	public float locationX = 15;
	public float locationZ = 15;

	public GameObject KillCollectable;

	//voor het respawnen
	List <float> timers;
	public float respawnTimer = 5f;


    // Use this for initialization
    void Start () {
		//maakt de lijst en vult deze met collactables op random location rondom de NPC.
		objects = new List<GameObject>();
		for(int i = 0; i < amount; i++){
			Vector3 location = transform.position;
			location.x += Random.Range(-locationX, locationX);
			location.z += Random.Range(-locationZ, locationZ);
			objects.Add( Instantiate(enemy, location, transform.rotation) );
		}

		//timer lijst aanmaken.
		timers = new List<float>();
		for(int i = 0; i < amount; i++){
			timers.Add(0f);
		}
    }
	
	// Update is called once per frame
	void Update () {

		
		//zet een timer als een object in de objects lijst niet actief is
		//als deze timer is afgelopen word het object weer actief en reset de health.
		for(int i = 0; i < amount; i++){
			if(!objects[i].activeSelf){
				if(timers[i] <= 0){
					timers[i] = respawnTimer;
					Instantiate(KillCollectable, objects[i].transform.position, objects[i].transform.rotation);
				}
				if(timers[i] > 0){
					timers[i] -= Time.deltaTime;
						if(timers[i] <= 0){
						objects[i].SetActive(true);
						objects[i].transform.position = objects[i].GetComponent<EnemyAI>().respawnLocation;
						//health reset
						objects[i].GetComponent<Stats>().health = objects[i].GetComponent<Stats>().startHealth;
					}
				}
			}
		}     
	}
}