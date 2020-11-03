using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour {

	public GameObject levelCompletePanel;

	private PlayerController player;

	public AudioClip VictorySound;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		levelCompletePanel.SetActive (false);
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			player.isDead = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			levelCompletePanel.SetActive (true);
			int levelUnlock = PlayerPrefs.GetInt ("Level", 1);
			int currentLevel = SceneManager.GetActiveScene ().buildIndex;
			if (levelUnlock < currentLevel + 1){
				PlayerPrefs.SetInt ("Level", currentLevel + 1);
				PlayerPrefs.Save ();
			}
			source.clip = VictorySound;
			source.Play ();
		}
	}
}
