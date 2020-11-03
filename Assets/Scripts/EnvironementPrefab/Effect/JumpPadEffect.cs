using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadEffect : MonoBehaviour {

	public float power;
	public bool resetVelocity;

	public bool dontPlaySound;

	private Rigidbody playerBody;

	void Start()
	{
		playerBody = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			if (resetVelocity)
				playerBody.velocity = new Vector3 (playerBody.velocity.x, 0, 0);
			playerBody.AddForce (0, power, 0);
			if (dontPlaySound == false)
				GetComponent<AudioSource> ().Play ();
		}
	}
}
