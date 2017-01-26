using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawDown : Trap {

	public Vector3 target;
	private bool fired = false;

	// Use this for initialization
	void Start () {
		target = new Vector3 (gameObject.transform.position.x,gameObject.transform.position.y - 2,0);
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.back * 10);
		if(fired)
			transform.position = Vector3.MoveTowards (transform.position, target, 1 * Time.deltaTime);
	}

	public override void Fire(){
		fired = true;
	}
}
