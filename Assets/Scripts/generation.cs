using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generation : MonoBehaviour {

	[SerializeField]
	public GameObject block;
	private Vector2 mousePosition;
	private float x;
	private float y;


	// Use this for initialization
	void Start() {
		Instantiate (block, new Vector3(0, 0, 0), Quaternion.identity);
		for(int i = 1; i <= 10; i++){
			Instantiate (block, new Vector3(10*i, 0, 0), Quaternion.identity);
		}
	}

	// Update is called once per frame
	void Update () {
		mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		x = mousePosition.x / Screen.width;
		y = mousePosition.y / Screen.height;
		if (x > 0.3f && x < 0.5f && y < 0.9f && y > 0.5f && Input.GetMouseButtonDown (0))
			print ("case 1-2");
		else if (x > 0.1f && x < 0.3f && y < 0.9f && y > 0.5f && Input.GetMouseButtonDown (0))
			print ("case 1-1");
		else if (x > 0.5f && x < 0.7f && y < 0.9f && y > 0.5f && Input.GetMouseButtonDown (0))
			print ("case 1-3");
		else if (x > 0.7f && x < 0.9f &&  y < 0.9f && y > 0.5f && Input.GetMouseButtonDown (0))
			print ("case 1-4");
		else if (x > 0.3f && x < 0.5f && y < 0.5f && y > 0.1f && Input.GetMouseButtonDown (0))
			print ("case 2-2");
		else if (x > 0.1f && x < 0.3f && y < 0.5f && y > 0.1f && Input.GetMouseButtonDown (0))
			print ("case 2-1");
		else if (x > 0.5f && x < 0.7f && y < 0.5f && y > 0.1f && Input.GetMouseButtonDown (0))
			print ("case 2-3");
		else if (x > 0.7f && x < 0.9f &&  y < 0.5f && y > 0.1f && Input.GetMouseButtonDown (0))
			print ("case 2-4");

	}
}
