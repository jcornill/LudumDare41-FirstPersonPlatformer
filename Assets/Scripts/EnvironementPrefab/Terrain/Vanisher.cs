using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vanisher : MonoBehaviour {

	public float timeBeforeVanish;
	public bool comeBackAfterVanish;
	public float timeBeforeComeBack;


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
		GetComponent<MeshRenderer> ().material.color = new Color (0.8f, 0.8f, 1, 0.8f);
	}
	
	// Update is called once per frame
	void Update () {
		if (isPlayerOn) {
			vanishPercent = (1 - (Time.time - startTime) / timeBeforeVanish);
			vanishPercent = Mathf.Clamp (vanishPercent, 0f, 0.8f);
			//vanishPercent = Mathf.Max (0f, vanishPercent - 0.2f);
			GetComponent<MeshRenderer> ().material.color = new Color (0.8f, 0.8f, 1, vanishPercent);
			if (startTime + timeBeforeVanish < Time.time) {
				isVanished = true;
				GetComponent<BoxCollider> ().enabled = false;
				actTimeComeback = Time.time;
				isPlayerOn = false;
				GetComponent<MeshRenderer> ().material.color = new Color (0.8f, 0.8f, 1f, 0f);
			}
		}
		if (comeBackAfterVanish && isVanished) {
			if (actTimeComeback + timeBeforeComeBack < Time.time) {
				isVanished = false;
				GetComponent<MeshRenderer> ().material.color = new Color (0.8f, 0.8f, 1f, 0.8f);
				GetComponent<BoxCollider> ().enabled = true;
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Player") {
			startTime = Time.time;
			actTimeComeback = Time.time;
			isPlayerOn = true;
		}
	}
}
