using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameMode : MonoBehaviour {

	[Range (1,3)]
	public int numberOfLanes = 1;
	[Range (1.5f,4)]
	public float speedOfGame = 1.5f;
	[Range (3, 25)]
	public int zigzaginessOfLane = 10;
	GameController gamecontroller;

	public void SendDataToGameController () {
		gamecontroller = FindObjectOfType <GameController> ();
		gamecontroller.SetGameDifficulty (numberOfLanes, speedOfGame, zigzaginessOfLane);
	}

}
