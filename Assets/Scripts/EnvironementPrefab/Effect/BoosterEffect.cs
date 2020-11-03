using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterEffect : MonoBehaviour {

	public float power;
	public bool cancelPlayerMouvement;

	private Rigidbody playerBody;
	private PlayerController player;

	void Start()
	{
		playerBody = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			if ((int)playerBody.transform.rotation.eulerAngles.y == 0)
				playerBody.AddForce (power, 0, 0);
			else
				playerBody.AddForce (-power, 0, 0);
			if (cancelPlayerMouvement)
				player.boosterNoMove = true;
		}
	}
}
