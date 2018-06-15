using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Dit is het script uit de les van Valentijn, aangepast naar mijn wensen.

public enum State { Idle, Move, Attack}

public class EnemyAI : MonoBehaviour {

    //voor states
    public State currentState;
	public float aggroRange = 15f;
	public float slapRange = 3f;
    public float leashRange = 40f;

    //voor animatie en geluid
    private AudioSource damageSound;
    private GameObject audioFind;
    public Animation anim;
    
    //voor aanval
    public float maxCooldown = 1;
    private float cooldown;
	public int damage = 20;

	//voor de respawnlocatie en idlestate
	public Vector3 respawnLocation;
    // private bool idleOnWay = false;
    // private float idleRandomX;
    // private float idleRandomZ;
    // private Vector3 idleRandomPosition;
    // public float IdleLocationX;
    // public float IdleLocationZ;

    private NavMeshAgent agent;
    private GameObject player;
    // private float coolDown;
    // private float distanceToTarget;
    // // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
		respawnLocation = gameObject.transform.position;
        
        //enemy start idle
        currentState = State.Idle;

        //voor het opzoeken object met audiosource
        audioFind = GameObject.Find("PlayerHurt");
		damageSound = audioFind.GetComponent<AudioSource>();
    }
	
	//Update is called once per frame
	void Update () {

        CheckState();
     
	}

    void CheckState()
    {
       
        //States
        switch (currentState)
        {
            
            case State.Idle:

                //agent keert terug naar spawnlocatie
                agent.SetDestination(respawnLocation);

                //BONUS
                // //bewegen naar random punten rond respawnlocation 
                // //pak random locatie rond spawn en set destination
                // if(!idleOnWay){
                //     idleRandomPosition = respawnLocation;
                //     idleRandomPosition.x += Random.Range(-IdleLocationX, IdleLocationX);
			    //     idleRandomPosition.z += Random.Range(-IdleLocationZ, IdleLocationZ);
                //     agent.SetDestination(idleRandomPosition);
                //     idleOnWay = true;
                //     Debug.Log(idleRandomPosition);
                // }
                // //zolang locatie nog niet bereikt is geen nieuwe locatie zetten (distance)
                // if(idleOnWay && Vector3.Distance(idleRandomPosition, transform.position) <= 0f ){
                //     idleOnWay = false;
                // }

                //zolang locatie nog niet bereikt is geen nieuwe locatie zetten (distance)

                //als in move range naar move
                if(Vector3.Distance(transform.position, player.transform.position) < aggroRange){
                    currentState = State.Move;
                }

                //animatie
                anim.Play("Idle");
                
                break;

            case State.Move:

                //set destination naar speler
                agent.SetDestination(player.transform.position);

                //als speler buiten leash range gaat naar idle
                if(Vector3.Distance(transform.position, player.transform.position) > leashRange){
                    currentState = State.Idle;
                }

                //als speler binnen attack range komt naar attack state
                if(Vector3.Distance(transform.position, player.transform.position) < slapRange){
                    currentState = State.Attack;
                }

                //animatie
                anim.Play("Run");

                break;

            case State.Attack:

                //aanvallen  = var damage met var cooldown op stats health player
                
                if(cooldown <= 0){
                    //zorgt er voor dat de cooldown gaat lopen
                    cooldown = maxCooldown;

                    //zorgt er voor dat de damage aan de healt van de target word gedaan
                    player.GetComponent<PlayerStats>().health -= damage;

                    //animatie en geluid
                    anim.Play("Attack");
                    damageSound.Play();
                }

                else{
                    cooldown -= Time.deltaTime;
                    //animatie
                    if(!anim.isPlaying)
                    anim.Play("Idle");
                }

                //als uit range naar move to
                if(Vector3.Distance(transform.position, player.transform.position) > slapRange){
                    currentState = State.Move;
                }

                break;


        }

    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;


// public enum State { Idle, Move, Attack}

// public class AI : MonoBehaviour {

//     public State currentState;
//     public int damage = 20;
//     public float attackRange;
//     public float maxCooldown = 1;
//     public float senseRange = 10;

//     private NavMeshAgent agent;
//     private Health target;
//     private float coolDown;
//     private float distanceToTarget;
//     // Use this for initialization
//     void Start () {
//         agent = GetComponent<NavMeshAgent>();
//         //player = GameObject.FindGameObjectWithTag("Player");

//     }
	
// 	// Update is called once per frame
// 	void Update () {

//         CheckState();
     
// 	}

//     void CheckState()
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
       
//         //States
//         switch (currentState)
//         {
//             case State.Attack:
//                 //Action
//                 if (coolDown > 0)
//                 {
//                     coolDown -= Time.deltaTime;
//                 }
                    
//                 //Do Damage
//                 if(distanceToTarget < attackRange && coolDown <= 0)
//                 {
//                     Debug.Log("Do attack!");
//                     target.DoDamage(gameObject, damage);
//                     coolDown = maxCooldown;
//                 }

//                 //Transition
//                 if(distanceToTarget > 2* attackRange)
//                 {
//                     currentState = State.Move;
//                 }

//                 break;
//             case State.Idle:

//                 //if we are close pick a new position to walk to
//                 if(agent.remainingDistance > agent.stoppingDistance)
//                 {
//                     break;
//                 }
//                 else
//                 {
//                     agent.SetDestination(transform.position + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)));
//                 }
//                 if(distanceToTarget < senseRange)
//                 {
//                     currentState = State.Move;
//                 }

                
//                 break;
//             case State.Move:
//                 //Move to the target
//                 if(target != null)
//                 {
//                     agent.SetDestination(target.transform.position);
//                 }
                

//                 if(distanceToTarget < attackRange)
//                 {
//                     currentState = State.Attack;
//                 }

//                 break;

//         }

//     }
// }