using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelJump : MonoBehaviour {

	public bool canJumpAgain;

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			player.canJump = canJumpAgain;
		}
	}
}
