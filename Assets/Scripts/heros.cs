using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class heros : MonoBehaviour {

	private float moveSpeed;
	private float movement;
	private float movement2;
	private float lastMovement;
	private float lastMovement2;
	private Rigidbody2D rg;
	private bool death;
	private bool dash;
	private bool canDash;
	private Collider2D box;
	float cameraCheck;
	bool scroll;

	[SerializeField]
	public GameObject deathCanvas;

	// Use this for initialization
	void Start () {
		scroll = false;
		rg = GetComponent<Rigidbody2D> ();
		box = GetComponent<Collider2D> ();
		deathCanvas.SetActive (false);
		death = false;
		dash = false;
		canDash = true;
		moveSpeed = 100;
	}

	// Update is called once per frame
	void Update () {


		if (!death && !scroll) {

			if (!dash) {
				movement = Input.GetAxis ("Vertical") * moveSpeed;
				movement2 = Input.GetAxis ("Horizontal") * moveSpeed;
				movement *= Time.deltaTime;
				movement2 *= Time.deltaTime;
			} else {
				movement = lastMovement;
				movement2 = lastMovement2;
			}

			lastMovement = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
			lastMovement2 = Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;


			rg.velocity = new Vector3 (movement2, movement, 0);

			if (Input.GetButtonDown ("Jump") && canDash && !(Input.GetAxis ("Vertical") == 0 && Input.GetAxis ("Horizontal") == 0)) {
				StartCoroutine (Dash ());
			}
		} else if (!death && scroll) {
			rg.velocity = new Vector3 (0, 0, 0);
		}


		if (scroll) {
			Camera.main.transform.position = Vector3.Slerp (Camera.main.transform.position, Camera.main.transform.position + new Vector3 (10, 0, 0), 1 * Time.deltaTime);
		}

		if (transform.position.x > Camera.main.transform.position.x + 5) {
			scroll = true;
			cameraCheck = Camera.main.transform.position.x;
		}

		if (cameraCheck + 10 <= Camera.main.transform.position.x) {
			scroll = false;
		}


	}

	void OnCollisionEnter2D(Collision2D coll){
		if ((coll.gameObject.tag == "danger" || coll.gameObject.tag == "lesserDanger") && !dash) {
			StartCoroutine (Death());
		}
	}

	void OnCollisionStay2D(Collision2D coll){
		if ((coll.gameObject.tag == "danger" || coll.gameObject.tag == "lesserDanger") && !dash) {
			StartCoroutine (Death());
		}
	}

	IEnumerator Dash(){
		dash = true;
		box.enabled = false;
		canDash = false;
		moveSpeed = 600;
		yield return new WaitForSeconds(0.1f);
		dash = false;
		moveSpeed = 0;
		yield return new WaitForSeconds(0.1f);
		box.enabled = true;
		yield return new WaitForSeconds(0.5f);
		moveSpeed = 100;
		yield return new WaitForSeconds(1.5f);
		canDash = true;

	}

	IEnumerator Death(){
		death = true;
		yield return new WaitForSeconds(3);
		deathCanvas.SetActive (true);
		yield return new WaitForSeconds(4);
		SceneManager.LoadScene ("menu");
	}


}
