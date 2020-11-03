using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("Level", 0) > 0)
			transform.GetChild(0).GetComponent<Text>().text = "Continue";
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
			PlayerPrefs.DeleteAll ();
		}
	}

	public void LoadContinueLevel()
	{
		LevelSelector.LoadLevelStatic (PlayerPrefs.GetInt ("Level", 1));
	}
}
