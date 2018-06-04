using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestKillButtons : MonoBehaviour {

	//Make sure to attach these Buttons in the Inspector
    public Button m_Accept, m_Cancel;

    //voor het aanzetten op quest script op character
    private GameObject character;

    void Start()
    {
        Button accept = m_Accept.GetComponent<Button>();
        Button cancel = m_Cancel.GetComponent<Button>();
        //Calls the TaskAccept method when you click the accept Button
        accept.onClick.AddListener(TaskAccept);

		//Calls the TaskCancel method when you click the cencel Button
        cancel.onClick.AddListener(TaskCancel);

        character = GameObject.FindWithTag("Player");
    }

    void TaskAccept()
    {
        //Output this to console when the Button is clicked

        //zet de quest aan.
        character.GetComponent<QuestKill>().enabled = true;

        Destroy(gameObject);
    }

    void TaskCancel()
    {
        //Output this to console when the Button is clicked
		Destroy(gameObject);
	}
}