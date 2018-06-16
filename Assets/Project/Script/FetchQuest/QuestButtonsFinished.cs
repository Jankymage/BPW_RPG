using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script voor de quest afsluiting popup, voor grootste gedeelte gecopieerd van unity documentatie

public class QuestButtonsFinished : MonoBehaviour {

	//voor de knop
    public Button m_Accept;

    //voor het uitzetten van de quest op de player
    private GameObject character;

    //om de parent van de quest complete text te verwijderen
    private GameObject questTextParent;

    //om script van de quest uit te lezen (voor resetten quest).
	public QuestFetch QuestFetch;

    void Start()
    {
        //initializatie knop
        Button accept = m_Accept.GetComponent<Button>();
        accept.onClick.AddListener(TaskAccept);

        //voor verwijzing naar quest script
        character = GameObject.FindWithTag("Player");
    }

    //voor het afsluiten van de quest
    void TaskAccept()
    {
        //Output this to console when the Button is clicked

        //verwijderen de quest complete text
		questTextParent = GameObject.Find("QuestFetchText(Clone)");
		Destroy(questTextParent);

        //reset de quest.
        character.GetComponent<QuestFetch>().questTextUpdateBool = true;

        //zet de quest uit.
        character.GetComponent<QuestFetch>().enabled = false;

        //voor finish script
        character.GetComponent<QuestFetch>().questFinish = true;

        Destroy(gameObject);
    }

    
}