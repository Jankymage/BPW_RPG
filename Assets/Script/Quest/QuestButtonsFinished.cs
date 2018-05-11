using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButtonsFinished : MonoBehaviour {

	//Make sure to attach these Buttons in the Inspector
    public Button m_Accept;

    //voor het aanzetten op quest script op character
    private GameObject character;

    void Start()
    {
        Button accept = m_Accept.GetComponent<Button>();
        
        //Calls the TaskAccept method when you click the accept Button
        accept.onClick.AddListener(TaskAccept);

        character = GameObject.FindWithTag("Player");
    }

    void TaskAccept()
    {
        //Output this to console when the Button is clicked
        Debug.Log("ACCEPTED!");

        //zet de quest uit.
        character.GetComponent<QuestFetch>().enabled = false;

        Destroy(gameObject);
    }

    
}