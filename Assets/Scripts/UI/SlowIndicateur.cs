using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowIndicateur : MonoBehaviour {

	private PlayerController player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (SpeedEffect.activeEffect != null) {
			transform.GetChild (0).GetComponent<MeshRenderer> ().enabled = SpeedEffect.activeEffect.boostSpeedValue < 0;
			/*
			if (SpeedEffect.activeEffect.effectTime > 0 && SpeedEffect.activeEffect.effectTime - Time.time - SpeedEffect.activeEffect.startTime < 10f) {
				float value = (1 - ((Time.time - SpeedEffect.activeEffect.startTime) / SpeedEffect.activeEffect.effectTime));
				value = value / 3f;
				transform.GetChild (0).localScale = new Vector3 (value, value, value);
			}
			*/
		} else {
			transform.GetChild (0).GetComponent<MeshRenderer> ().enabled = false;
		}
	}
}
