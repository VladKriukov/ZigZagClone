using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public int score;
	public int highScore;
	public Text scoreDisplay;
	[Range(1,3)]
	public int numberOfLanes;
	int zigzagsForLane;
//	[Header ("Difficulty Settings")]
//	[Range(1,4)]
//	public float easySpeed = 2;
//	[Range(1,4)]
//	public float mediumSpeed = 2.5f;
//	[Range(1,4)]
//	public float hardSpeed = 3;

	CubeGenerator[] cubeGenerators;
	Ball[] balls;
	CameraController cameraMain;
	CanvasController canvasController;

	void Start () {
		cubeGenerators = FindObjectsOfType (typeof(CubeGenerator)) as CubeGenerator[];
		balls = FindObjectsOfType (typeof(Ball)) as Ball[];
		cameraMain = GameObject.FindObjectOfType <CameraController> ();
		canvasController = GameObject.FindObjectOfType <CanvasController> ();
	}

	public void StartGame () {
//		for (int i=0; i<cubeGenerators.Length -levelOfLanes+1; i++) {
//			cubeGenerators [i].enabled = true;
//			cubeGenerators [i].zigzaginess = zigzagsForLane;
//		}
		for (int i=0; i<numberOfLanes; i++) {
			cubeGenerators [i].enabled = true;
			cubeGenerators [i].zigzaginess = zigzagsForLane;
		}
		Invoke ("EnableEverythingElse", 1);
	}

	void EnableEverythingElse ()
	{
		for (int i = 0; i < balls.Length; i++) {
			balls [i].enabled = true;
		}
		cameraMain.enabled = true;
		canvasController.enabled = true;
	}

	public void GameOver () {
		Debug.Log ("Game Over");
		canvasController.EndGame ();
	}

	public void AddScore (int i) {
		score = score + i;
		scoreDisplay.text = "" + score;
	}

	public void SetGameDifficulty (int numOfGenerators, float speed, int zigzaginess) {
		numberOfLanes = numOfGenerators;
		cameraMain.speed = speed;
		zigzagsForLane = zigzaginess;
		canvasController.StartGame ();
	}

	public void OnHomeBtnClicked () {
		SceneManager.LoadScene("Game");
	}

	public void OnRetryBtnClicked () {
		
	}

//	public void Easy () {
//		numberOfLanes = 1;
//		canvasController.DisableUI ();
//		cameraMain.speed = easySpeed;
//	}
//
//	public void Medium () {
//		numberOfLanes = 2;
//		canvasController.DisableUI ();
//		cameraMain.speed = mediumSpeed;
//	}
//
//	public void Hard () {
//		numberOfLanes = 3;
//		canvasController.DisableUI ();
//		cameraMain.speed = hardSpeed;
//	}

}
