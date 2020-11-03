using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTriggerDeathBall : MonoBehaviour {

	public DeathBall deathBallScript;
	public float delayBeforeDeathBallStart;

	public PlayerController player;
	public bool turnPlayer;
	public bool activateOnce;

	private float actTime;
	private bool triggered;
	private bool hasActivated;

	// Use this for initialization
	void Start () {
		actTime = Time.time;
		triggered = false;
		hasActivated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (triggered && actTime + delayBeforeDeathBallStart < Time.time) {
			deathBallScript.isStart = true;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && (activateOnce == false || (activateOnce && hasActivated == false))) {
			GetComponent<AudioSource> ().Play ();
			deathBallScript.gameObject.SetActive (true);
			hasActivated = true;
			triggered = true;
			actTime = Time.time;
			if (turnPlayer) {
				player.turnBack ();
			}
		}
	}
}
