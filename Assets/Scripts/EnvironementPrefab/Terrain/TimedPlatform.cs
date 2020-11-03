using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedPlatform : MonoBehaviour {

	public bool DarkSoulMode;
	public float startDelay;
	public float actifTime;
	public float inactifTime;

	private float actTime;
	private float actTimeON;
	private float actTimeOFF;
	private bool actif;

	// Use this for initialization
	void Start () {
		actTimeON = Time.time;
		actTimeOFF = Time.time;
		actTime = Time.time;
		actif = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (actTime + startDelay < Time.time) {
			if (actif) {
				if (actTimeON + actifTime < Time.time) {
					actTimeOFF = Time.time;
					actif = false;
					GetComponent<MeshRenderer> ().enabled = actif;
					if (DarkSoulMode)
						GetComponent<BoxCollider> ().enabled = actif;
				}
			} else {
				if (actTimeOFF + inactifTime < Time.time) {
					actTimeON = Time.time;
					actif = true;
					GetComponent<MeshRenderer> ().enabled = actif;
					if (DarkSoulMode)
						GetComponent<BoxCollider> ().enabled = actif;
				}
			}
		} else {
			actTimeON = Time.time;
			actTimeOFF = Time.time;
		}
	}
}
