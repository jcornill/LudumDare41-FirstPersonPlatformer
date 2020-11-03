using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBall : MonoBehaviour {

	public float minSpeed;
	public bool isStart;

	public MeshRenderer body;
	public Material opak;
	public Material transparent;

	private float speed;
	private GameObject playerObject;

	private float clign = 0.5f;
	private float actClign;
	private bool toggle = false;

	// Use this for initialization
	void Start () {
		playerObject = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (isStart) {
			float distance = Vector3.Distance (new Vector3 (transform.position.x, 0, 0), new Vector3 (playerObject.transform.position.x, 0, 0));
			speed = distance / 100f;
			speed = Mathf.Max (speed, minSpeed);
			speed = Mathf.Min (speed, 100);
			transform.Translate (speed, 0, 0);
			if (actClign + clign < Time.time) {
				actClign = Time.time;
				body.material = toggle ? opak : transparent;
				toggle = !toggle;
			}
		}
	}
}
