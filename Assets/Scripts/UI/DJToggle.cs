using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DJToggle : MonoBehaviour {

	public Toggle toggleComponent;

	private bool updateToggle;

	// Use this for initialization
	void Start () {
		bool on = PlayerPrefs.GetInt ("Music", 0) == 0;
		PressToggle (!on);
		toggleComponent.isOn = !on;

	}
	
	// Update is called once per frame
	void Update () {
		if (updateToggle) {
			GetComponent<AudioSource> ().Pause ();
		} else {
			GetComponent<AudioSource> ().UnPause ();
		}
	}

	public void PressToggle(bool toggle)
	{
		updateToggle = toggle;
		PlayerPrefs.SetInt ("Music", toggle ? 1 : 0);
		PlayerPrefs.Save ();
	}
}
