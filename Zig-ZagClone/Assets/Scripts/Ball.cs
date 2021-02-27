using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	bool turn = false;
	float speed;
	CameraController cam;
	public GameController gameController;
	public bool inPlay = true;
	Vector3 startPos;

	void Start () {
		cam = FindObjectOfType <CameraController> ();
		gameController = GameObject.FindObjectOfType <GameController> ();
		InvokeRepeating ("AddScore", 0.1f, 0.1f);
		startPos = transform.position;
	}
		
	// Update is called once per frame
	void Update () {
		if (inPlay == true) {
			speed = cam.speed * 2;
			if (Input.GetMouseButtonDown (0)) {
				turn = !turn;
			}
			if (transform.position.y < -2) {
				//UnityEngine.SceneManagement.SceneManager.LoadScene ("Game");
				inPlay = false;
				CancelInvoke ();
				gameController.GameOver ();
				transform.position = startPos;
			}
			MoveBall ();
		}
	}

	void MoveBall () {
		if (turn == false) {
			transform.Translate (new Vector3 (0, 0, speed * Time.deltaTime), Space.World);
		} 
		if (turn == true) {
			transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0), Space.World);
		}
	}

	void AddScore () {
		gameController.AddScore (1);
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Bonus")) {
			if (other.gameObject.name == "Bonus(Clone)") {
				gameController.AddScore (100);
				//scoreDisplay.GetComponent <Score> ().AddScore (100);
			}
			Destroy (other.gameObject);
		}
	}

}
