using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakable : MonoBehaviour {

	[SerializeField]
	public int life;

	void OnCollisionEnter2D(Collision2D coll) {
		print (coll.collider.tag);

		if (coll.collider.tag == "hit") {
			life--;
			if (life == 0) {
				Destroy (gameObject);
			}

		}
	}
}
