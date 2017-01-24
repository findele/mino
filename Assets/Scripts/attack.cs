using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {

	private bool attacked;
	private string target;

	void Start(){
		gameObject.GetComponent<Collider2D> ().enabled = false;

		attacked = false;
	}

	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			StartCoroutine (attacking());
		}
	}
		


	IEnumerator attacking(){
		attacked = true;
		gameObject.GetComponent<Collider2D> ().enabled = true;
		yield return new WaitForSeconds (0.5f);
		gameObject.GetComponent<Collider2D> ().enabled = false;
		attacked = false;
	}
}
