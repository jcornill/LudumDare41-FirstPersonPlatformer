using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSided : MonoBehaviour {

	private float timeBeforeComeBack = 0.5f;

	private float actTimeComeback;
	private float startTime;
	private float vanishPercent;

	private bool isVanished;
	private bool isPlayerOn;
	// Use this for initialization
	void Start () {
		actTimeComeback = Time.time;
		isVanished = false;
		isPlayerOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isVanished) {
			if (actTimeComeback + timeBeforeComeBack < Time.time) {
				isVanished = false;
				transform.parent.GetComponent<BoxCollider> ().enabled = true;
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player") {
			isVanished = true;
			transform.parent.GetComponent<BoxCollider> ().enabled = false;
			actTimeComeback = Time.time;
		}
	}
}
