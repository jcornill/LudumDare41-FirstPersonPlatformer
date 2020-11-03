using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpPower;
	public bool isDead;
	public GameObject Arrow;

	public float boostSpeed { get; set; }

	public AudioClip jumpSound;
	public AudioClip hitSound;
	public AudioClip turnSound;
	private AudioSource source;

	private float actualSpeed;
	private bool jumpAvailable;

	private bool animTurnOn;
	private int turn;
	private int counter = 0;
	private bool canMove;
	public bool boosterNoMove { get; set; }
	public bool canJump { get; set; }

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		jumpAvailable = true;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		isDead = false;
		animTurnOn = false;
		canMove = true;
		boosterNoMove = false;
		turn = 1;
		canJump = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isDead == false && canMove && boosterNoMove == false) {
			actualSpeed = speed;
			actualSpeed += boostSpeed;
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.Z)) {
				transform.Translate (Time.deltaTime * actualSpeed, 0, 0);
			} else if (Input.GetKey (KeyCode.S)) {
				transform.Translate (Time.deltaTime * -actualSpeed, 0, 0);
			}
		}
		if ((Input.GetKeyDown (KeyCode.X) || Mathf.Abs(Input.GetAxis ("Mouse X")) > 15f) && animTurnOn == false) {
			StartAnimTurn ();
		}
		Quaternion oldCameraRotation = Camera.main.transform.rotation;
		bool positive = Input.GetAxis ("Mouse Y") > 0;
		float test;
		if (positive)
			test = Mathf.Min (Input.GetAxis ("Mouse Y"), 10f);
		else
			test = Mathf.Max (Input.GetAxis ("Mouse Y"), -10f);
		Camera.main.transform.Rotate (Vector3.left * test);
		if (Camera.main.transform.rotation.eulerAngles.x > 70 && Camera.main.transform.rotation.eulerAngles.x < 280) {
			Camera.main.transform.rotation = oldCameraRotation;
		}
	}

	void Update()
	{
		if (isDead == false && boosterNoMove == false && canJump) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (jumpAvailable) {
					source.clip = jumpSound;
					source.Play ();
					GetComponent<Rigidbody> ().AddForce (0, jumpPower, 0);
					jumpAvailable = false;
				}
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				GetComponent<Rigidbody> ().AddForce (0, -300, 0);
			}
		}

		if (Input.GetKeyDown (KeyCode.Tab)) {
			Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
			Cursor.visible = !Cursor.visible;
		}
		if (animTurnOn) {
			if (counter < 20) {
				counter++;
				transform.Rotate (0, 9 * turn, 0);
				if (Arrow != null)
					Arrow.transform.Rotate (0, 9 * turn, 0);
			} else {
				counter = 0;
				animTurnOn = false;
				canMove = true;
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Platform") {
			if (boosterNoMove)
				boosterNoMove = false;
			if (collision.collider.transform.position.y < transform.position.y) {
				if (jumpAvailable == false) {
					if (source.clip.name != "Death") {
						source.clip = hitSound;
						source.Play ();
					}
				}
				jumpAvailable = true;
			}
				
		}
	}

	private void StartAnimTurn()
	{
		source.clip = turnSound;
		source.Play ();
		turn = Input.GetAxis ("Mouse X") < 0 ? -1 : 1;
		canMove = false;
		animTurnOn = true;
	}

	public void turnBack()
	{
		if ((int)transform.rotation.eulerAngles.y != 180)
			StartAnimTurn ();
	}

	public void turnFace()
	{
		if (transform.rotation.eulerAngles.y != 0)
			StartAnimTurn ();
	}
}
