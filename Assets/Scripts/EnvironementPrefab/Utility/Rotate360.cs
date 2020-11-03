using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate360 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rot = transform.eulerAngles;
        rot.y += 1;
        transform.eulerAngles = rot;
    }
}
