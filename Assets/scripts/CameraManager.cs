using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {


	public GameObject player;
	private Vector3 playerPos;
	public Transform playerPlay;
	public Vector3 zOffset;

	public float forwardOffset;

	public player_move_proto  playerScript;

	public float smoothTime;
	Vector3 smoothVelocity = Vector3.zero;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void FixedUpdate () {

		CameraMovement ();

	}

	void CameraMovement()
	{
		zOffset.x = playerScript.rb.velocity.x;

		playerPos = player.transform.position + zOffset * forwardOffset;

		transform.position = Vector3.SmoothDamp (transform.position, playerPos, ref smoothVelocity, smoothTime);
	}

}
