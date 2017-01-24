using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killTheHero : MonoBehaviour {

	public Vector3 target;

	// Use this for initialization
	void Start () {
		target = new Vector3 (1000,0,0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, target, 1 * Time.deltaTime);
	}
}
