using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTrigger : MonoBehaviour {

	public static TextTrigger activeTrigger;

    public string textToDisplay;
    public float nbOfSecToStay;
    public bool onlyOneTrigger;
    public bool doDiscardTheMessageOnExit;
	public Color colorText;
	public bool PlaySong;

	public Text text;

	private float actSecond;
	private bool isTextActive;

	// Use this for initialization
	void Start () {
		actSecond = Time.time;
		isTextActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (nbOfSecToStay != -1 && isTextActive && actSecond + nbOfSecToStay < Time.time) {
			actSecond = Time.time;
			HideMessage ();
		}
	}

	private void HideMessage()
	{
		actSecond = Time.time;
		isTextActive = false;
		if (activeTrigger == this)
			text.gameObject.SetActive (false);
		if (onlyOneTrigger)
			GameObject.Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			if (PlaySong)
				GetComponent<AudioSource> ().Play ();
			activeTrigger = this;
			actSecond = Time.time;
			isTextActive = true;
			text.gameObject.SetActive (true);
			text.text = textToDisplay;
			text.color = colorText;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player" && doDiscardTheMessageOnExit) {
			HideMessage ();
		}
	}
}
