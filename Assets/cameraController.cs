using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	float cameraCheck;
	bool scroll;

	// Use this for initialization
	void Start () {
		scroll = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (scroll) {
			Camera.main.transform.position = Vector3.Slerp (Camera.main.transform.position, Camera.main.transform.position + new Vector3 (10, 0, 0), 1 * Time.deltaTime);
		}

		if (transform.position.x > Camera.main.transform.position.x + 5) {
			scroll = true;
			cameraCheck = Camera.main.transform.position.x;
		}

		if (cameraCheck + 10 <= Camera.main.transform.position.x)
			scroll = false;



	}
}
