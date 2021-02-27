using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

	public GameController gameController;
	GameObject startBtn;
	GameObject selectLevel3lane;
	GameObject selectLevel2lane;
	GameObject selectLevel1lane;
	GameObject gameOver;

	// Use this for initialization
	void Start () {
		//Time.timeScale = 0;
		selectLevel3lane = gameObject.transform.Find ("SelectLevel_3_lane").gameObject;
		selectLevel2lane = gameObject.transform.Find ("SelectLevel_double").gameObject;
		selectLevel1lane = gameObject.transform.Find ("SelectLevel_classic").gameObject;
		gameOver = gameObject.transform.Find ("GameOver").gameObject;
		startBtn = gameObject.transform.Find ("StartBtn").gameObject;
		gameController = GameObject.FindObjectOfType<GameController> ();

	}

	public void StartGame () {
		//Time.timeScale = 1;
		startBtn.SetActive (false);
		selectLevel3lane.SetActive (false);
		selectLevel2lane.SetActive (false);
		selectLevel1lane.SetActive (false);
		gameController.StartGame ();
	}

	public void EndGame () {
		// TODO: Show menu, stats and save the score. //Then after 5 seconds, restart the game
		gameOver.SetActive (true);

		//Invoke ("RestartGame", 5);
	}

	void RestartGame () {
		//startBtn.SetActive (true);
	}
}
