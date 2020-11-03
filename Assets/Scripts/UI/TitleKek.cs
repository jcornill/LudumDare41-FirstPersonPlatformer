using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleKek : MonoBehaviour {

	private float turn;

	// Use this for initialization
	void Start () {
		turn = 0.15f;
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (0, turn, 0);
		if (transform.rotation.eulerAngles.y < 10 && transform.rotation.eulerAngles.y > 5)
			turn = -0.15f;
		else if (transform.rotation.eulerAngles.y < 360-5 && transform.rotation.eulerAngles.y > 5)
			turn = 0.15f;
	}
}
