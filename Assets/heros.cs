using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heros : MonoBehaviour {

	public float moveSpeed = 1f;
	private float movement;
	private float movement2;
	public Rigidbody2D rg;

	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {



		movement = Input.GetAxis("Vertical") * moveSpeed;
		movement2 = Input.GetAxis("Horizontal") * moveSpeed;
		movement *= Time.deltaTime;
		movement2 *= Time.deltaTime;
		//transform.Translate(movement2, movement, 0.0f);
		rg.velocity = new Vector3 (movement2, movement, 0.0f);

	}
}
