using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeahtBallMeter : MonoBehaviour {

	public DeathBall deathBallScript;
	public PlayerController player;

	private Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (deathBallScript.gameObject.activeSelf)
			text.text = Vector3.Distance (new Vector3 (deathBallScript.transform.position.x, 0, 0), new Vector3 (player.transform.position.x, 0, 0)) + " m";
		else
			text.text = "";
	}
}
