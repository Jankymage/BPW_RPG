﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestButtons : MonoBehaviour {

	//Make sure to attach these Buttons in the Inspector
    public Button m_Accept, m_Cancel;

    void Start()
    {
        Button accept = m_Accept.GetComponent<Button>();
        Button cancel = m_Cancel.GetComponent<Button>();
        //Calls the TaskAccept method when you click the accept Button
        accept.onClick.AddListener(TaskAccept);

		//Calls the TaskCancel method when you click the cencel Button
        cancel.onClick.AddListener(TaskCancel);
    }

    void TaskAccept()
    {
        //Output this to console when the Button is clicked
        Debug.Log("ACCEPTED!");
    }

    void TaskCancel()
    {
        //Output this to console when the Button is clicked
        Debug.Log("cancel");
		Destroy(gameObject);
	}
}