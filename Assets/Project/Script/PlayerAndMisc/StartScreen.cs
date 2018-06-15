using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//script voor de start screen

public class StartScreen : MonoBehaviour {

	//variablen voor de knoppen
	public Button m_startGame, m_quitGame;

	// Use this for initialization
	void Start () {

		//initialiseerd de knoppen
		Button startgame = m_startGame.GetComponent<Button>();
		startgame.onClick.AddListener(StartGame);
		Button quitgame = m_quitGame.GetComponent<Button>();
		quitgame.onClick.AddListener(QuitGame);

	}

	//start het spel
	void StartGame(){
		SceneManager.LoadScene("Main");
	}

	//sluit af
	void QuitGame(){
		Application.Quit();
	}
}
