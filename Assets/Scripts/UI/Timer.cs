using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


	private float startTime;
	private Text text;
	PlayerController player;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		text = GetComponent<Text> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.isDead == false) {
			float time = (Time.time - startTime);
			text.text = "Time : " + ConvertFloatTimeToText (time);
		}
	}

	public string ConvertFloatTimeToText(float time)
	{
		int seconds = ((int)time) % 60;
		int minutes = ((int)time) / 60;
		int millis = (int)((time - (int)time) * 1000);
		string secondStr = (seconds < 10) ? ("0" + seconds.ToString()) : seconds.ToString();
		string minutesStr = (minutes < 10) ? ("0" + minutes.ToString()) : minutes.ToString();
		string millisStr = (millis < 100) ? ("0" + millis.ToString()) : millis.ToString();
		millisStr = (millis < 10) ? ("00" + millis.ToString()) : millisStr;
		string result;
		if (minutes > 0)
			result = minutesStr + ":" + secondStr + "." + millisStr;
		else
			result = secondStr + "." + millisStr;
		return result;
	}
}
