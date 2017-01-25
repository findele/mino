using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour {

	[SerializeField]
	public GameObject spearUp;
	[SerializeField]
	public GameObject spearDown;
	[SerializeField]
	public GameObject spearLeft;
	[SerializeField]
	public GameObject spearRight;

	// Use this for initialization
	void Start () {
		StartCoroutine (FireAtWill());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator FireAtWill(){
		while (true) {
			Instantiate (spearUp, gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
			Instantiate (spearDown, gameObject.transform.position + new Vector3(0, -1, 0), Quaternion.identity);
			Instantiate (spearRight, gameObject.transform.position + new Vector3(1, 0, 0), Quaternion.identity);
			Instantiate (spearLeft, gameObject.transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
			yield return new WaitForSeconds (0.75f);
		}
	}
}
