using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDuMecRelou : MonoBehaviour {

	private float y;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		y++;
		transform.Rotate (0, 1, 0);
    }
}
