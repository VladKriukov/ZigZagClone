using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	//public GameManager gameManager;
	Animator animator;

	// Use this for initialization
	void Start () {
		//gameManager = FindObjectOfType <GameManager> ();
		animator = GetComponent<Animator> ();
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("MainCamera")) {
			//gameManager.CreatePath ();
			gameObject.transform.parent.parent.GetComponent <CubeGenerator>().CreatePath ();
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.CompareTag ("MainCamera")) {
			Invoke ("ChangeAnimatorVariable", 0.4f);
		}
	}

	void ChangeAnimatorVariable () {
		animator.SetBool ("End", true);
		Invoke ("DestroyMe", 2f);
	}

	void DestroyMe () {
		Destroy (gameObject.transform.parent.gameObject, 0.1f);
	}

}
