using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//script voor het game menu
//bevat instructies en laat je naar het start scherm gaan
//moet actief zijn bij eerste laden scene, zodat speler het menu krijg te zien bij begin spel

public class GameMenu : MonoBehaviour {

	//Voor de knoppen
	public Button m_Close, m_Start;

	// Use this for initialization
	void Start () {
		
		//voor het initalizeren van de buttons
        Button accept = m_Close.GetComponent<Button>();
        Button cancel = m_Start.GetComponent<Button>();
        accept.onClick.AddListener(CloseMenu);
        cancel.onClick.AddListener(ReturnStart);

	}
	
	//functie voor het uitzetten van het menu
    void CloseMenu()
    {
        gameObject.SetActive(false);
    }

	//functie voor het uitzetten van het menu
    void ReturnStart()
    {
        SceneManager.LoadScene("StartScreen");
    }
	
}
