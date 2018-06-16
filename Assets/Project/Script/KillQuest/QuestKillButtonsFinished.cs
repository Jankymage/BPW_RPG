using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//script voor de quest afsluiting popup, voor grootste gedeelte gecopieerd van unity documentatie

public class QuestKillButtonsFinished : MonoBehaviour {

	//Voor de knop
    public Button m_Accept;

    //voor het aanzetten op quest script op character
    private GameObject character;

    //om de parent van de quest complete text te verwijderen
    private GameObject questTextParent;

    //om script van de quest uit te lezen (voor resetten quest).
	public QuestKill QuestKill;

    void Start()
    {
        //initializatie van knop
        Button accept = m_Accept.GetComponent<Button>();
        accept.onClick.AddListener(TaskAccept);

        //voor quest script op speler
        character = GameObject.FindWithTag("Player");
    }

    //voor het afsluiten van de quest
    void TaskAccept()
    {
        //verwijderd de quest complete text
		questTextParent = GameObject.Find("QuestKillText(Clone)");
		Destroy(questTextParent);

        //reset de quest.
        character.GetComponent<QuestKill>().questTextUpdateBool = true;

        //zet de quest uit.
        character.GetComponent<QuestKill>().enabled = false;

        //voor finish script
        character.GetComponent<QuestKill>().questFinish = true;

        Destroy(gameObject);
    }

    
}