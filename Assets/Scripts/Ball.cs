using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchSpeed;
	public bool inPlay = false;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		rigidBody = GetComponent<Rigidbody> ();
		rigidBody.useGravity = false;
		initialPosition = transform.position;
	}

	public void Launch (Vector3 velocity)
	{
		inPlay = true;
		audioSource.Play ();
		rigidBody.velocity = velocity;
		rigidBody.useGravity = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset(){
		transform.position = initialPosition;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity = false;
		inPlay = false;
	}
}
