using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//script voor de start screen

public class StartScreen : MonoBehaviour {

	//variablen voor de knoppen
	public Button m_startGame, m_quitGame, m_Credits;

	//voor het laten zien van de credits
	public GameObject creditsObject;

	// Use this for initialization
	void Start () {

		//initialiseerd de knoppen
		Button startgame = m_startGame.GetComponent<Button>();
		startgame.onClick.AddListener(StartGame);
		Button quitgame = m_quitGame.GetComponent<Button>();
		quitgame.onClick.AddListener(QuitGame);
		Button credits = m_Credits.GetComponent<Button>();
		credits.onClick.AddListener(Credits);

	}

	//start het spel
	void StartGame(){
		SceneManager.LoadScene("Main");
	}

	//sluit af
	void QuitGame(){
		Application.Quit();
	}

	//laat de credits zien
	void Credits(){
		Debug.Log("credits");
		creditsObject.SetActive(true);
	}

}
