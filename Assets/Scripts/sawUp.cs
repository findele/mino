using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawUp : Trap {

	public Vector3 target;
	private bool fired = false;
	private AudioSource musicSource;
	[SerializeField]
	public AudioClip saw;

	// Use this for initialization
	void Start () {
		target = new Vector3 (gameObject.transform.position.x,gameObject.transform.position.y + 2,0);
		musicSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.back * 10);
		if(fired)
			transform.position = Vector3.MoveTowards (transform.position, target, 1 * Time.deltaTime);
	}

	public override void Fire(){
		if (fired) {
			musicSource.Play ();
		} else {
			fired = true;
			musicSource.PlayOneShot (saw);
		}
	}
}
