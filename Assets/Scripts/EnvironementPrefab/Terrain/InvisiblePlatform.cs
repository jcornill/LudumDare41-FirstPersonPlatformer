using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour {

	public bool vanish;
	public float timeToVanish;

	private float actTime;
	private float vanishPercent;
	private bool isSeen;

	// Use this for initialization
	void Start () {
		isSeen = false;
		GetComponent<MeshRenderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (vanish && isSeen) {
			vanishPercent = (1 - (Time.time - actTime) / timeToVanish);
			GetComponent<MeshRenderer> ().material.color = new Color (1, 1, 1, vanishPercent);
			if (actTime + timeToVanish < Time.time) {
				GetComponent<MeshRenderer> ().enabled = false;
			}
		}
	}

	void OnCollisionStay(Collision collision)
	{
		if (collision.collider.tag == "Player") {
			GetComponent<MeshRenderer> ().material.color = new Color (1, 1, 1, 1);
			GetComponent<MeshRenderer> ().enabled = true;
			isSeen = true;
			actTime = Time.time;
		}
	}
}
