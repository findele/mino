using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generation : MonoBehaviour {

	[SerializeField]
	public GameObject block;
	[SerializeField]
	public GameObject theTrap;
	private Vector2 mousePosition;
	private float x;
	private float y;
	public GameObject[] traps;
	public Trap trap;
	public Vector3 cameraDecal = new Vector3(5.33f, 2.99f, 0);


	// Use this for initialization
	void Start() {
		traps = new GameObject[10];
		Instantiate (block, cameraDecal, Quaternion.identity);
		for(int i = 1; i <= 6; i++){
			Instantiate (block, new Vector3(10*i, 0, 0) + cameraDecal, Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {
		

	}
}
