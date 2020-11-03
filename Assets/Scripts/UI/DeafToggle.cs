using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeafToggle : MonoBehaviour {

	public Toggle toggle;


	private bool updateToggle;
	// Use this for initialization
	void Start () {
		toggle.isOn = !(PlayerPrefs.GetInt ("Sound", 0) == 0);
		Toggle (toggle.isOn);
	}

	void Update()
	{
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("Sound"))
			go.GetComponent<AudioSource> ().enabled = !updateToggle;
		GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource> ().enabled = !updateToggle;
	}

	public void Toggle(bool toggle)
	{
		updateToggle = toggle;
		PlayerPrefs.SetInt ("Sound", toggle ? 1 : 0);
		PlayerPrefs.Save ();
	}
}
