using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSpearsDown : Trap {

	[SerializeField]
	public GameObject spear;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public override void Fire () {
		Instantiate (spear, gameObject.transform.position + new Vector3(0, 0.25f, 0), Quaternion.identity);
		Instantiate (spear, gameObject.transform.position + new Vector3(-0.6f, 0.25f, 0), Quaternion.identity);
		Instantiate (spear, gameObject.transform.position + new Vector3(0.5f, 0.25f, 0), Quaternion.identity);
	}
}
