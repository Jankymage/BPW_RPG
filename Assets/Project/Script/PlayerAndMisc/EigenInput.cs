using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script voor het bewegen van de speler

public class EigenInput : MonoBehaviour
{

    //Alle public variables
    [Range(0.1f,0.5f)]
    public float moveMulti;
    public Transform playerCam, character, viewPoint;
    public float mouseSpeed = 10f;

    //voor animatie en geluid
    public Animation anim;
    public AudioSource stepSound;
    
    //variables voor het bewegen
    private Rigidbody rb;
    private float moveSpeedForward = 0;
    private float moveSpeedSide = 0;
    private CapsuleCollider coll;
    private Vector3 movement;

    //variables voor de camera
    private float mouseY;
    private float mouseX;
    private float zoom = -3;
    private float zoomSpeed = 2;
    private float zoomMin = -2f;
    private float zoomMax = -10f;
    private float camYOffset = 1;

    void Start()
    {
        //voor het aanspreken van de speler en de collider voor de grounded raycast
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        //zorgt dat het stappen geluid speelt als de character beweegt.
        if(moveSpeedForward != 0 | moveSpeedSide != 0){
            if(!stepSound.isPlaying){
                stepSound.Play();
            }
        }

        //zorgt dat het afspelen van het stappen geluid stopt als de character stil staat
        if (moveSpeedForward == 0f && moveSpeedSide == 0f){
            stepSound.Stop();
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Voor het zoomen van de muis (met clamp)
        zoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoom = Mathf.Clamp(zoom, zoomMax, zoomMin);
        playerCam.transform.localPosition = new Vector3(0, 0, zoom);

        //beweegt de muis als de rechtermuisknop is ingedrukt en verbergt dat de muis
        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
            mouseY -= Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
            Cursor.visible = false;
        }
        else { Cursor.visible = true; }

        //Clampt de muis op boven en onderst as
        mouseY = Mathf.Clamp(mouseY, -60f, 60f);
        //zorgt dat de camera naar de centerpoint blijft kijken
        playerCam.LookAt(viewPoint);
        //draait de camera afhankelijk van de muis stand
        viewPoint.localRotation = (Quaternion.Euler(mouseY, mouseX, 0));
        //zet de positie van de viewpoint afhankelijk van de positie van de character
        viewPoint.position = new Vector3(character.position.x, character.position.y + camYOffset, character.position.z);

        //zorgt dat de character vooruit beweegt en speelt de loop animatie af
        //character kan alleen bewegen als er geen skill 
        if (Input.GetKey(KeyCode.W) && !anim.IsPlaying("skill") && !anim.IsPlaying("attack"))
        {
            moveSpeedForward = moveMulti;
            anim.Play("walk");
        }

        else
        {
            moveSpeedForward = 0;
        }

        //zorgt dat de character zijwaards beweegt
        if (Input.GetKey(KeyCode.A) && !anim.IsPlaying("skill") && !anim.IsPlaying("attack"))
        {
            moveSpeedSide = -moveMulti;
            anim.Play("walk");
        }
        else if (Input.GetKey(KeyCode.D) && !anim.IsPlaying("skill") && !anim.IsPlaying("attack"))
        {
            moveSpeedSide = moveMulti;
            anim.Play("walk");
        }
        else
        {
            moveSpeedSide = 0;
        }
        
        //als de character niet beweegt en er geen aanval of skill word gebruikt: free animatie spelen
        if (moveSpeedForward == 0f && moveSpeedSide == 0f && !anim.IsPlaying("skill") && !anim.IsPlaying("attack")){
            anim.Play("free");
        }

        //draait de character aan de hand van de camera
        character.rotation = Quaternion.Euler(0, viewPoint.eulerAngles.y, 0);

        //zorgt dat de character vooruit, achteruit en zijwaards beweegt aan de hand van de input
        movement = (character.forward * moveSpeedForward) + (character.right * moveSpeedSide);
        rb.MovePosition(movement + rb.position);

    }

}
