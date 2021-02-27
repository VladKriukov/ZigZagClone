using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float speed = 2;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (-speed * Time.deltaTime, 0, speed * Time.deltaTime), Space.World);
	}
}
