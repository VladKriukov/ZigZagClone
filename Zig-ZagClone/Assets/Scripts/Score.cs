using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public int multiplier = 1;
	//public GameObject scoreDisplay;
	Text text;
	int score;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		keepAddingScore ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = (score.ToString ());
	}

	void keepAddingScore () {
		InvokeRepeating ("AddScore", 0.1f, 0.1f);
	}

	void AddScore () {
		score = score + 1 * multiplier;
	}

	public void AddScore (int i){
		score = score + i;
	}

	public void StopScores () {
		CancelInvoke ();
	}

}
