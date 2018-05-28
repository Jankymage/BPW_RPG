using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Dit is het script uit de les van Valentijn, aangepast naar mijn wensen.

public enum State { Idle, Move, Attack}

public class EnemyAI : MonoBehaviour {

    public State currentState;
	public float aggroRange = 15f;
	public float slapRange = 3f;
    // public float attackRange;
    // public float maxCooldown = 1;
    // public float senseRange = 10;
	//public int damage = 20;

	//voor de respawnlocatie
	public Vector3 respawnLocation;

    private NavMeshAgent agent;
    private GameObject player;
    // private float coolDown;
    // private float distanceToTarget;
    // // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
		respawnLocation = gameObject.transform.position;
    }
	
	//Update is called once per frame
	void Update () {

        CheckState();
     
	}

    void CheckState()
    {
        //bekijken of player ver genoeg is.

		if(Vector3.Distance(transform.position, player.transform.position) < slapRange){
			Debug.Log("slapslap");
			currentState = State.Attack;
		}

		else if(Vector3.Distance(transform.position, player.transform.position) < aggroRange){
			Debug.Log("aggro");
			currentState = State.Move;
		}

		else{
			Debug.Log("no aggro");
			currentState = State.Idle;
		}

		

		


        // if (target == null)
        // {
        //     distanceToTarget = float.MaxValue;
        //     Collider[] cols = Physics.OverlapSphere(transform.position, senseRange);
        //     foreach (Collider c in cols)
        //     {
        //         if (c.gameObject == gameObject) { continue; }
        //         Health hp = c.gameObject.GetComponent<Health>();
        //         if (hp != null)
        //         {
        //             Debug.Log("Health found!");
        //             float distToHealthScript = Vector3.Distance(transform.position, hp.transform.position);
        //             if (distToHealthScript < distanceToTarget)
        //             {
        //                 target = hp;
        //                 distanceToTarget = distToHealthScript;
        //             }
        //         }
        //     }
        //     if(target == null)
        //     {
        //         currentState = State.Idle;
        //     }

        // }else{
        //     distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        //     if(distanceToTarget > senseRange)
        //     {
        //         target = null;
        //     }
        // }
       
    //     //States
    //     switch (currentState)
    //     {
    //         case State.Attack:
    //             //Action
    //             if (coolDown > 0)
    //             {
    //                 coolDown -= Time.deltaTime;
    //             }
                    
    //             //Do Damage
    //             if(distanceToTarget < attackRange && coolDown <= 0)
    //             {
    //                 Debug.Log("Do attack!");
    //                 target.DoDamage(gameObject, damage);
    //                 coolDown = maxCooldown;
    //             }

    //             //Transition
    //             if(distanceToTarget > 2* attackRange)
    //             {
    //                 currentState = State.Move;
    //             }

    //             break;
    //         case State.Idle:

    //             //if we are close pick a new position to walk to
    //             if(agent.remainingDistance > agent.stoppingDistance)
    //             {
    //                 break;
    //             }
    //             else
    //             {
    //                 agent.SetDestination(transform.position + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)));
    //             }
    //             if(distanceToTarget < senseRange)
    //             {
    //                 currentState = State.Move;
    //             }

                
    //             break;
    //         case State.Move:
    //             //Move to the target
    //             if(target != null)
    //             {
    //                 agent.SetDestination(target.transform.position);
    //             }
                

    //             if(distanceToTarget < attackRange)
    //             {
    //                 currentState = State.Attack;
    //             }

    //             break;

    //     }

    }
}


// void CheckState()
//     {
//         //Sensing
//         if (target == null)
//         {
//             distanceToTarget = float.MaxValue;
//             Collider[] cols = Physics.OverlapSphere(transform.position, senseRange);
//             foreach (Collider c in cols)
//             {
//                 if (c.gameObject == gameObject) { continue; }
//                 Health hp = c.gameObject.GetComponent<Health>();
//                 if (hp != null)
//                 {
//                     Debug.Log("Health found!");
//                     float distToHealthScript = Vector3.Distance(transform.position, hp.transform.position);
//                     if (distToHealthScript < distanceToTarget)
//                     {
//                         target = hp;
//                         distanceToTarget = distToHealthScript;
//                     }
//                 }
//             }
//             if(target == null)
//             {
//                 currentState = State.Idle;
//             }

//         }else{
//             distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
//             if(distanceToTarget > senseRange)
//             {
//                 target = null;
//             }
//         }