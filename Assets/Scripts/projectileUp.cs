using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileUp : MonoBehaviour {

	private Rigidbody2D rg;

	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		rg.velocity = new Vector3 (0, 200 * Time.deltaTime, 0);
	}

	void OnCollisionEnter2D(Collision2D coll){
		Destroy (gameObject);
	}

}
