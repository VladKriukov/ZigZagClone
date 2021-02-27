using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

	public GameObject cube;
	public GameObject newCube;
	public GameObject[] bonuses;
	public GameObject newBonus;
	public Vector3 posOfCube;
	public bool turn;
	public int howWide = 5;
	[Range (3,25)]
	public int zigzaginess;
	public int randomBonusRange = 15;
	//public bool gameStarted;
	int howWideIsNow = 5;
	int startingNumberOfBlocks = 26;

	// Use this for initialization
	void Start () {
		posOfCube = cube.transform.position;
		newCube = cube;
	}
	
	// Update is called once per frame
	void Update () {
		if (startingNumberOfBlocks > 0) {
			CreatePath ();
		}
	}

	public void CreatePath () {
		if (turn == false) {
			TurnRight ();
		} else {
			TurnLeft ();
		}
		TurnRandomiser ();
		Check ();
	}

	void TurnRandomiser (){
		float randNumber = Random.Range (0f, zigzaginess);
		if (randNumber < 1) {
			turn = !turn;
		}
	}

	void TurnLeft () {
		newCube = Instantiate (cube, new Vector3 (posOfCube.x-1, -2, posOfCube.z), Quaternion.identity);
		newCube.transform.SetParent (gameObject.transform);
		posOfCube = new Vector3 (posOfCube.x - 1, 0, posOfCube.z);
		startingNumberOfBlocks--;
		howWideIsNow--;
		RandomBonus ();
	}

	void TurnRight () {
		newCube = Instantiate (cube, new Vector3 (posOfCube.x, -2, posOfCube.z+1), Quaternion.identity);
		newCube.transform.SetParent (gameObject.transform);
		posOfCube = new Vector3 (posOfCube.x, 0, posOfCube.z + 1);
		startingNumberOfBlocks--;
		howWideIsNow++;
		RandomBonus ();
	}

	void RandomBonus () {
		if (Random.Range (0, randomBonusRange) < 1) {
			int rndBonus = Random.Range (0, bonuses.Length);
			newBonus = Instantiate (bonuses [rndBonus], posOfCube + new Vector3 (0, -2, 0), Quaternion.identity);
			newBonus.transform.SetParent (newCube.transform.GetChild (0));
		}
	}

	void Check () {
		if (howWideIsNow > howWide) {
			turn = true;
		}
		if (howWideIsNow < -howWide) {
			turn = false;
		}
	}
}
