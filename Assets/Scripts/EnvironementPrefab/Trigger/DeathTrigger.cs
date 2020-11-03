using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {

	private PlayerDeath playerDeathScript;

	void Start()
	{
		playerDeathScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerDeath> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			playerDeathScript.TriggerDeath ();
		}
	}
}
