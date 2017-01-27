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
	private bool shield;
	private Collider2D box;
	float cameraCheck;
	bool scroll;
	int isBonusShield;

	[SerializeField]
	public AudioClip fall;
	[SerializeField]
	public AudioClip end;
	[SerializeField]
	public AudioClip dashSound;
	[SerializeField]
	public AudioClip hitted;
	[SerializeField]
	public AudioClip shieldHitted;
	[SerializeField]
	public AudioClip takeShield;
	[SerializeField]
	public AudioClip empty;
	[SerializeField]
	public AudioClip passRoom;


	private AudioSource musicSource;

	[SerializeField]
	public GameObject deathCanvas;

	[SerializeField]
	public GameObject winCanvas;

	// declaration variables
	int[,] GrilleSalle1 = new int[120, 5]; // Tableau pour gestion salle1
	int[] EmplacementLanceHaut = new int[] { 13, 15, 17 }; // Gestion emplacement lances
	int[] EmplacementpiegesX = new int[] { 12, 14, 16 ,18 }; // Gestion emplacement autres pièges en X
	int[] EmplacementpiegesY = new int[] {2,3,4}; // Gestion emplacement autres pièges en Y
	GameObject[,] trapTable = new GameObject[120, 5];
	GameObject trap;
	int generateX = 0;
	int xP = 0;
	int yP = 0;
	int xPiege = 0;
	int yPiege = 0;
	int xPiege2 = 0;
	int yPiege2 = 0;
	int HautBas = 0;
	int ChoixPiegeCentre =0;
	int PiegePoseOk = 0;
	int roomNumber = 0;

	private Vector2 mousePosition;
	private float x;
	private float y;

	[SerializeField]
	GameObject throwSpearsDown;
	[SerializeField]
	GameObject throwSpearsUp;
	[SerializeField]
	GameObject tower;
	[SerializeField]
	GameObject hole;
	[SerializeField]
	GameObject sawDown;
	[SerializeField]
	GameObject sawUp;
	[SerializeField]
	GameObject bonusShield;
	[SerializeField]
	GameObject spikes;

	[SerializeField]
	RuntimeAnimatorController controller;

	// Use this for initialization
	void Start () {
		scroll = false;
		shield = true;
		rg = GetComponent<Rigidbody2D> ();
		box = GetComponent<Collider2D> ();
		deathCanvas.SetActive (false);
		winCanvas.SetActive (false);
		death = false;
		dash = false;
		canDash = true;
		moveSpeed = 100;
		musicSource = GetComponent<AudioSource> ();
		musicSource.Play ();
	}

	// Update is called once per frame
	void Update () {

		if (gameObject.transform.position.x > 65 && !death) {
			StartCoroutine (Win());
		}

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
		} else {
			rg.velocity = new Vector3 (0, 0, 0);
		}


		if (scroll) {
			Camera.main.transform.position = Vector3.MoveTowards (Camera.main.transform.position, Camera.main.transform.position + new Vector3 (10, 0, 0), 10 * Time.deltaTime);
		}

		if (transform.position.x > Camera.main.transform.position.x + 5) {
			musicSource.PlayOneShot (passRoom);
			if(gameObject.transform.position.x < 55)
				generateRoom ();
			roomNumber++;
			scroll = true;
			cameraCheck = Camera.main.transform.position.x;
		}

		if (cameraCheck + 10 <= Camera.main.transform.position.x) {
			scroll = false;
		}


		mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		x = mousePosition.x / Screen.width;
		y = mousePosition.y / Screen.height;
		if (x > 0.3f && x < 0.5f && y < 0.9f && y > 0.5f && Input.GetMouseButtonDown (0)) {
			if (trapTable [4 + roomNumber * 10, 4]) {
				trap = trapTable [4 + roomNumber * 10, 4];
				if (trap.GetComponent<Trap> () != null) {
					trap.GetComponent<Trap> ().Fire ();
				} else
					musicSource.PlayOneShot (empty);
					
			} else
				musicSource.PlayOneShot (empty);

		} else if (x > 0.1f && x < 0.3f && y < 0.9f && y > 0.5f && Input.GetMouseButtonDown (0)) {
			if (trapTable [2 + roomNumber * 10, 4]) {
				trap = trapTable [2 + roomNumber * 10, 4];
				if (trap.GetComponent<Trap> () != null) {
					trap.GetComponent<Trap> ().Fire ();
				} else
					musicSource.PlayOneShot (empty);

			} else
				musicSource.PlayOneShot (empty);
		} else if (x > 0.5f && x < 0.7f && y < 0.9f && y > 0.5f && Input.GetMouseButtonDown (0)) {
			if (trapTable [6 + roomNumber * 10, 4]) {
				trap = trapTable [6 + roomNumber * 10, 4];
				if (trap.GetComponent<Trap> () != null) {
					trap.GetComponent<Trap> ().Fire ();
				} else
					musicSource.PlayOneShot (empty);

			} else
				musicSource.PlayOneShot (empty);
		} else if (x > 0.7f && x < 0.9f && y < 0.9f && y > 0.5f && Input.GetMouseButtonDown (0)) {
			if (trapTable [8 + roomNumber * 10, 4]) {
				trap = trapTable [8 + roomNumber * 10, 4];
				if (trap.GetComponent<Trap> () != null) {
					trap.GetComponent<Trap> ().Fire ();
				} else
					musicSource.PlayOneShot (empty);

			} else
				musicSource.PlayOneShot (empty);
		} else if (x > 0.3f && x < 0.5f && y < 0.5f && y > 0.1f && Input.GetMouseButtonDown (0)) {
			if (trapTable [4 + roomNumber * 10, 2]) {
				trap = trapTable [4 + roomNumber * 10, 2];
				if (trap.GetComponent<Trap> () != null) {
					trap.GetComponent<Trap> ().Fire ();
				} else
					musicSource.PlayOneShot (empty);

			} else
				musicSource.PlayOneShot (empty);
		} else if (x > 0.1f && x < 0.3f && y < 0.5f && y > 0.1f && Input.GetMouseButtonDown (0)) {
			if (trapTable [2 + roomNumber * 10, 2]) {
				trap = trapTable [2 + roomNumber * 10, 2];
				if (trap.GetComponent<Trap> () != null) {
					trap.GetComponent<Trap> ().Fire ();
				} else
					musicSource.PlayOneShot (empty);

			} else
				musicSource.PlayOneShot (empty);
		} else if (x > 0.5f && x < 0.7f && y < 0.5f && y > 0.1f && Input.GetMouseButtonDown (0)) {
			if (trapTable [6 + roomNumber * 10, 2]) {
				trap = trapTable [6 + roomNumber * 10, 2];
				if (trap.GetComponent<Trap> () != null) {
					trap.GetComponent<Trap> ().Fire ();
				} else
					musicSource.PlayOneShot (empty);

			} else
				musicSource.PlayOneShot (empty);
		} else if (x > 0.7f && x < 0.9f && y < 0.5f && y > 0.1f && Input.GetMouseButtonDown (0)) {
			if (trapTable [8 + roomNumber * 10, 2]) {
				trap = trapTable [8 + roomNumber * 10, 2];
				if (trap.GetComponent<Trap> () != null) {
					trap.GetComponent<Trap> ().Fire ();
				} else
					musicSource.PlayOneShot (empty);

			} else
				musicSource.PlayOneShot (empty);
		}

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "danger" && !dash) {
			if(!death)
				musicSource.PlayOneShot (hitted);
				StartCoroutine (Death ());
		} else if (coll.gameObject.tag == "lesserDanger" && !dash) {
			if (shield) {
				musicSource.PlayOneShot (shieldHitted);
				shield = false;
				gameObject.GetComponent<Animator> ().SetBool ("shield", false);

			}
			else
				if(!death)
					StartCoroutine (Death ());
		} 
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "danger" && !dash) {
			musicSource.PlayOneShot (hitted);
			if(!death)
				StartCoroutine (Death());
		} else if (coll.gameObject.tag == "shield") {
			if (!shield) {
				musicSource.PlayOneShot (takeShield);
				shield = true;
				gameObject.GetComponent<Animator> ().SetBool ("shield", true);
				Destroy (coll.gameObject);
			}
		} else if (coll.gameObject.tag == "hole" && !dash) {
			gameObject.GetComponent<SpriteRenderer> ().sortingOrder = -1;
			StartCoroutine (Fall ());
		}
	}

	IEnumerator Dash(){
		musicSource.PlayOneShot (dashSound);
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
		yield return new WaitForSeconds(2);
		musicSource.PlayOneShot (end);
		deathCanvas.SetActive (true);
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene ("menu");
	}

	IEnumerator Win(){
		death = true;
		yield return new WaitForSeconds(2);
		musicSource.PlayOneShot (end);
		winCanvas.SetActive (true);
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene ("menu");
	}

	IEnumerator Fall(){
		death = true;
		yield return new WaitForSeconds(1);
		musicSource.PlayOneShot (fall);
		yield return new WaitForSeconds(1);
		musicSource.Stop ();
		musicSource.PlayOneShot (end);
		deathCanvas.SetActive (true);
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene ("menu");
	}

	void generateRoom(){
		PiegePoseOk = 0;

		if (EmplacementpiegesX [0] > 50 && shield) {
			generateX = Random.Range(0, 4);
			xPiege = EmplacementpiegesX[generateX];
			HautBas = Random.Range(0, 2);

			if (HautBas > 0)
			{
				// Attribution des coordonnées y en fonction si haut ou bas (0 ou 1)
				yPiege = 4;

				// Creation du piege sur les coordonnées définis
				// Si la place est déjà occupé, rien n'est placé
				if (PiegePoseOk <= 8)
				{
					if (GrilleSalle1 [xPiege, yPiege] == 0) {
						PiegePoseOk = PiegePoseOk + 2;
						Vector3 pos0 = new Vector3 (xPiege + 0.3f, yPiege + 0.1f, 0);
						Quaternion rot0 = Quaternion.identity;
						GameObject Saw0 = (GameObject)Instantiate (sawDown, pos0, rot0);
						GrilleSalle1 [xPiege, yPiege] = PiegePoseOk;
						trapTable [xPiege, yPiege] = Saw0;
					} 
				}
			}
			else
			{
				// Attribution des coordonnées y en fonction si haut ou bas (0 ou 1)
				yPiege = 2;

				// Creation du piege sur les coordonnées définis
				// Si la place est déjà occupé, rien n'est placé
				if (PiegePoseOk <= 8)
				{
					if (GrilleSalle1[xPiege, yPiege] == 0)
					{
						PiegePoseOk = PiegePoseOk + 2;
						Vector3 pos0 = new Vector3(xPiege + 0.3f, yPiege + 0.1f, 0);
						Quaternion rot0 = Quaternion.identity;
						GameObject Saw0 = (GameObject)Instantiate(sawUp, pos0, rot0);
						GrilleSalle1[xPiege, yPiege] = PiegePoseOk;
						trapTable [xPiege, yPiege] = Saw0;
					}
				}
			}

		}

		/************************
        * Autres pieges  salle 1*
        *************************/


		for (int j = 0; j <= 1; j++)
		{
			// Attribution des coordonnées x et y
			xP = Random.Range(0, 4);
			xPiege2 = EmplacementpiegesX [xP];    

			yP = Random.Range(0, 3);
			yPiege2 = EmplacementpiegesY[yP];

			// Definition type de piege
			if (shield)
				isBonusShield = 3;
			else
				isBonusShield = 4;
			ChoixPiegeCentre = Random.Range(0, isBonusShield);

			// Creation du piege sur les coordonnées définis
			// Si la place est déjà occupé, rien n'est placé
			if (PiegePoseOk <= 8)
			{
				if (GrilleSalle1 [xPiege2, yPiege2] == 0) {
					PiegePoseOk++;
					Vector3 pos1 = new Vector3 (xPiege2 + 0.3f, yPiege2 + 0.1f, 0);
					Quaternion rot1 = Quaternion.identity;
					//  Spawn du piege en fonction du type
					if (ChoixPiegeCentre == 0) {
						GameObject tower0 = (GameObject)Instantiate (tower, pos1, rot1);
						trapTable [xPiege2, yPiege2] = tower0;
					}
					if (ChoixPiegeCentre == 1) {
						GameObject hole0 = (GameObject)Instantiate (hole, pos1, rot1);
						trapTable [xPiege2, yPiege2] = hole0;
					}
					if (ChoixPiegeCentre == 2) {
						GameObject spikes0 = (GameObject)Instantiate (spikes, pos1, rot1);
						if (yPiege2 == 3)
							yPiege2--;
						trapTable [xPiege2, yPiege2] = spikes0;
					}
					if (ChoixPiegeCentre == 3) {
						GameObject bonusShield0 = (GameObject)Instantiate (bonusShield, pos1, rot1);
						trapTable [xPiege2, yPiege2] = bonusShield0;
					}
					// remplissage du tableau
					GrilleSalle1 [xPiege2, yPiege2] = PiegePoseOk;




					// gestion emplacement pour que 2 pieges ne sois pas cote à cote en y
					if (yPiege2 == 3) {
						PiegePoseOk++;
						GrilleSalle1 [xPiege2, yPiege2 + 1] = PiegePoseOk;
						GrilleSalle1 [xPiege2, yPiege2 - 1] = PiegePoseOk;
					}
					if (yPiege2 == 2) {
						GrilleSalle1 [xPiege2, yPiege2 + 1] = PiegePoseOk;                      
					}
					if (yPiege2 == 4) {
						GrilleSalle1 [xPiege2, yPiege2 - 1] = PiegePoseOk;
					}


				} else {
					j--;
				}
			}


		}

		// Gestion emplacement alélatoire des pièges
		for (int i = 0; i <= 2; i++)       
		{
			// Attribution des coordonnées x 
			generateX = Random.Range(0, 4);
			xPiege = EmplacementpiegesX[generateX];

			HautBas = Random.Range(0, 2);

			if (HautBas > 0)
			{
				// Attribution des coordonnées y en fonction si haut ou bas (0 ou 1)
				yPiege = 4;

				// Creation du piege sur les coordonnées définis
				// Si la place est déjà occupé, rien n'est placé
				if (PiegePoseOk <= 8)
				{
					if (GrilleSalle1 [xPiege, yPiege] == 0) {
						PiegePoseOk++;
						Vector3 pos0 = new Vector3 (xPiege + 0.3f, yPiege + 0.1f, 0);
						Quaternion rot0 = Quaternion.identity;
						GameObject Lance0 = (GameObject)Instantiate (throwSpearsDown, pos0, rot0);
						GrilleSalle1 [xPiege, yPiege] = PiegePoseOk;
						trapTable [xPiege, yPiege] = Lance0;
					} else {
						i--;
					}
				}
			}
			else
			{
				// Attribution des coordonnées y en fonction si haut ou bas (0 ou 1)
				yPiege = 2;

				// Creation du piege sur les coordonnées définis
				// Si la place est déjà occupé, rien n'est placé
				if (PiegePoseOk <= 8)
				{
					if (GrilleSalle1[xPiege, yPiege] == 0)
					{
						PiegePoseOk++;
						Vector3 pos0 = new Vector3(xPiege + 0.3f, yPiege + 0.1f, 0);
						Quaternion rot0 = Quaternion.identity;
						GameObject Lance0 = (GameObject)Instantiate(throwSpearsUp, pos0, rot0);
						GrilleSalle1[xPiege, yPiege] = PiegePoseOk;
						trapTable [xPiege, yPiege] = Lance0;
					} else {
						i--;
					}
				}
			}
		}      
			
			for (int i = 0; i < 4; i++) {
				EmplacementpiegesX [i] = EmplacementpiegesX [i] + 10;
			}

	}


}
