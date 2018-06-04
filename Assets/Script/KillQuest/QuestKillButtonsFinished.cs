using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestKillButtonsFinished : MonoBehaviour {

	//Make sure to attach these Buttons in the Inspector
    public Button m_Accept;

    //voor het aanzetten op quest script op character
    private GameObject character;

    //om de parent van de quest complete text te vermoorden
    private GameObject questTextParent;

    //om cript van de quest uit te lezen (voor resetten quest).
	public QuestKill QuestKill;

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

        //vermoord de quest complete text
		questTextParent = GameObject.Find("QuestKillText(Clone)");
		Destroy(questTextParent);

        //reset de quest.
        character.GetComponent<QuestKill>().questTextUpdateBool = true;


        //zet de quest uit.
        character.GetComponent<QuestKill>().enabled = false;

        Destroy(gameObject);
    }

    
}