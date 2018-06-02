using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

	//script voor de start screen

	public Button m_startGame, m_quitGame;

	// Use this for initialization
	void Start () {

		Button startgame = m_startGame.GetComponent<Button>();
		startgame.onClick.AddListener(StartGame);

		Button quitgame = m_quitGame.GetComponent<Button>();
		quitgame.onClick.AddListener(QuitGame);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StartGame(){
		SceneManager.LoadScene("Main");
	}

	void QuitGame(){
		Application.Quit();
	}
}
