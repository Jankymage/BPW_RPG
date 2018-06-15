using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script voor de quest acceptatie popup, voor grootste gedeelte gecopieerd van unity documentatie

public class QuestButtons : MonoBehaviour {

	//button variables
    public Button m_Accept, m_Cancel;

    //voor het aanzetten op quest script op character
    private GameObject character;

    void Start()
    {
        //voor het initalizeren van de buttons
        Button accept = m_Accept.GetComponent<Button>();
        Button cancel = m_Cancel.GetComponent<Button>();
        accept.onClick.AddListener(TaskAccept);
        cancel.onClick.AddListener(TaskCancel);

        //om het quest script op de speler aan te zetten.
        character = GameObject.FindWithTag("Player");
    }

    //functie voor het accepteren van de quest
    void TaskAccept()
    {
        character.GetComponent<QuestFetch>().enabled = true;
        Destroy(gameObject);
    }

    //functie voor het alleen verwijderen van de window, zonder acceptatie
    void TaskCancel()
    {
		Destroy(gameObject);
	}
}