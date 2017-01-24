using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generation : MonoBehaviour {

	[SerializeField]
	public GameObject block;

	// Use this for initialization
	void Start() {
		Instantiate (block, new Vector3(0, 0, 0), Quaternion.identity);
		for(int i = 1; i <= 10; i++){
			Instantiate (block, new Vector3(10*i, 0, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
