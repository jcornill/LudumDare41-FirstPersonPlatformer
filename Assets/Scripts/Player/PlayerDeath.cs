using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

	public AudioClip deathSound;

	public GameObject deathText;

	// Use this for initialization
	void Start () {
		deathText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -5 && deathText.activeSelf == false) {
			TriggerDeath ();
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			//SceneManager.UnloadScene (SceneManager.GetActiveScene ());
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex, LoadSceneMode.Single);
		}
	}

	public void TriggerDeath()
	{
		GetComponent<AudioSource> ().clip = deathSound;
		GetComponent<AudioSource> ().Play ();
		deathText.SetActive (true);
		GetComponent<PlayerController> ().isDead = true;
	}
}
