using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchSpeed;

	private Rigidbody rigidBody;
	private AudioSource audioSource;


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.useGravity = false;

		Launch (launchSpeed);
	}

	public void Launch (Vector3 velocity)
	{
		audioSource.Play ();
		rigidBody.velocity = velocity;
		rigidBody.useGravity = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
