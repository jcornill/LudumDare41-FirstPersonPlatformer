using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityResetTrigger : MonoBehaviour {

	public bool resetXVelocity;
	public bool resetYVelocity;

	private Rigidbody playerBody;

	// Use this for initialization
	void Start () {
		playerBody = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			if (resetXVelocity)
				playerBody.velocity = new Vector3 (0, playerBody.velocity.y, 0);
			if (resetYVelocity)
				playerBody.velocity = new Vector3 (playerBody.velocity.x, 0, 0);
		}
	}
}
