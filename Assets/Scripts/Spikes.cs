using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : Trap {

	private AudioSource musicSource;

	[SerializeField]
	Sprite spikeDown;

	[SerializeField]
	Sprite spikeUp;

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
		musicSource = GetComponent<AudioSource> ();
		yield return new WaitForSeconds (0.5f);
		musicSource.Play ();
		foreach (Transform child in transform)
			child.GetComponent<SpriteRenderer>().sprite = spikeUp;
		gameObject.GetComponent<Collider2D> ().enabled = true;
		yield return new WaitForSeconds (2);
		foreach (Transform child in transform)
			child.GetComponent<SpriteRenderer>().sprite = spikeUp;
		gameObject.GetComponent<Collider2D> ().enabled = false;
		Destroy (this);
	}
}
