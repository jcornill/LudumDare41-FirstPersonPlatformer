using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonLevelSelectorManager : MonoBehaviour {

	public GameObject buttonPrefab;
	public GameObject panelContainer;

	// Use this for initialization
	void Start () {
		int levelUnlock = PlayerPrefs.GetInt ("Level", 1);
		for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++) {
			GameObject button = GameObject.Instantiate (buttonPrefab);
			button.transform.SetParent (panelContainer.transform);
			button.transform.Find ("Text").GetComponent<Text> ().text = i.ToString ();
			if (i <= levelUnlock) {
				button.GetComponent<Image> ().color = Color.green;
				int j = i;
				button.GetComponent<Button> ().onClick.AddListener (() => {
					LevelSelector.LoadLevelStatic(j);
				});
			} else {
				button.GetComponent<Image> ().color = Color.red;
			}
		}
	}
}
