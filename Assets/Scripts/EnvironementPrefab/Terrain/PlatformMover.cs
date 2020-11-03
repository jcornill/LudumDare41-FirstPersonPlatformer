using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour {

	public bool linkPlayerToPlatform;
	public bool teleportAtEnd;
	public bool startMoveWhenPlayer;
	public bool stopMoveWhenPlayerExit;
	public bool stopAtEnd;
	public bool unlinkPlayerWhenTP;

	public float speed;
	public List<Vector3> patrolPoint;

	private bool move;
	private bool atEnd;
	private int i;

	private bool playerOnIt;
	// Use this for initialization
	void Start () {
		i = 0;
		if (startMoveWhenPlayer)
			move = false;
		else
			move = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (move) {
			if (stopAtEnd && atEnd)
				return;
			transform.position = Vector3.MoveTowards (transform.position, patrolPoint [i], speed * Time.deltaTime);
			if (Vector3.Distance (transform.position, patrolPoint [i]) < 0.1f) {
				if (patrolPoint.Count > i + 1) {
					i++;
				} else {
					if (teleportAtEnd) {
						if (unlinkPlayerWhenTP && playerOnIt)
							GameObject.FindGameObjectWithTag("Player").transform.SetParent (null);
						transform.position = patrolPoint [0];
					}
					i = 0;
					atEnd = true;
				}
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Player" && linkPlayerToPlatform) {
			playerOnIt = true;
			collision.collider.transform.SetParent (transform);
		}
		if (collision.collider.tag == "Player" && startMoveWhenPlayer) {
			move = true;
		}
	}

	void OnCollisionExit(Collision collision)
	{
		if (collision.collider.tag == "Player" && linkPlayerToPlatform) {
			playerOnIt = false;
			collision.collider.transform.SetParent (null);
		}
		if (collision.collider.tag == "Player" && stopMoveWhenPlayerExit) {
			move = false;
		}
	}
}
