using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedEffect : MonoBehaviour {

	public static SpeedEffect activeEffect;

	public bool oneActivation;
	[Tooltip("If set to true, the effect will decrease over time else the effect stop instant")]
	public bool fadeOverTime;
	public float effectTime;
	public float boostSpeedValue;
	public bool dontPlaySound;

	public AudioClip speedSound;
	public AudioClip slowSound;

	private PlayerController player;
	private float actTime;
	public float startTime {get; set;}
	private bool isActive;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		actTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive && activeEffect == this) {
			if (effectTime != -1 && actTime + effectTime < Time.time) {
				actTime = Time.time;
				isActive = false;
				player.boostSpeed = 0;
				activeEffect = null;
				if (oneActivation) {
					GameObject.Destroy (gameObject);
				}
			} else if (fadeOverTime) {
				player.boostSpeed = boostSpeedValue * (1 - ((Time.time - startTime) / effectTime));
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			if (dontPlaySound == false) {
				if (boostSpeedValue > 0) {
					GetComponent<AudioSource> ().clip = speedSound;
					GetComponent<AudioSource> ().Play ();
				} else {
					GetComponent<AudioSource> ().clip = slowSound;
					GetComponent<AudioSource> ().Play ();
				}
			}
			activeEffect = this;
			player.boostSpeed = boostSpeedValue;
			isActive = true;
			actTime = Time.time;
			startTime = Time.time;
		}
	}
}
