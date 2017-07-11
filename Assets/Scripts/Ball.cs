using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float launchSpeed = 5f;

	private Rigidbody rigidBody;
	private AudioSource audioSource;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();

		Launch ();
	}

	public void Launch ()
	{
		rigidBody.velocity = new Vector3 (0f, 0f, launchSpeed);
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
