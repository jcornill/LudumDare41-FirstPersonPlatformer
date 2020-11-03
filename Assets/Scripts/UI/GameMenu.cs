using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {

	public GameObject child;

	// Use this for initialization
	void Start () {
		Reprendre ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (child.activeSelf) {
				Reprendre ();
			} else {
				Pause ();
			}
		}
	}

	public void Pause()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 0;
		child.SetActive (true);
	}

	public void Reprendre()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Time.timeScale = 1;
		child.SetActive (false);
	}
}
