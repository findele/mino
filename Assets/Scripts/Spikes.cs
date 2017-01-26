using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Trap {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Collider2D> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Fire () {
		StartCoroutine (launchSpikes());
	}

	IEnumerator launchSpikes(){
		yield return new WaitForSeconds (0.5f);
		gameObject.GetComponent<Collider2D> ().enabled = true;
		yield return new WaitForSeconds (2);
		gameObject.GetComponent<Collider2D> ().enabled = false;
	}
}
