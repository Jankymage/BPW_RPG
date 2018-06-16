using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//script voor de enemy AI's
//Dit is het script uit de les van Valentijn, aangepast naar mijn wensen.

public enum State { Idle, Move, Attack}

public class EnemyAI : MonoBehaviour {

    //voor states
    public State currentState;
	public float aggroRange = 15f;
	public float slapRange = 3f;
    public float leashRange = 40f;

    //voor name
    public string enemyName;

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

    //voor de navmesh
    private NavMeshAgent agent;
    private GameObject player;

    // Use this for initialization
    void Start () {

        //initalistatie AI
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
		respawnLocation = gameObject.transform.position;
        currentState = State.Idle;

        //voor het opzoeken object met audiosource
        audioFind = GameObject.Find("PlayerHurt");
		damageSound = audioFind.GetComponent<AudioSource>();

        //om object naam te geven voor targeting
        gameObject.name = enemyName;
    }
	
	//Update is called once per frame
	void Update () {

        //voert de acties van de AI uit
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
