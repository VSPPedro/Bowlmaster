using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;

	private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();
	}

	public int CountStanding()
	{
		int standing = 0;

		Pin[] pins = GameObject.FindObjectsOfType<Pin> ();

		foreach (Pin pin in pins) {
			if (pin.IsStanding ()) {
				standing++;
			}
		}

		return standing;
	}

	void OnTriggerEnter (Collider collider) {
		GameObject thingHit = collider.gameObject;

		if (thingHit.GetComponent<Ball> ()) {
			ballEnteredBox = true;
			standingDisplay.color = Color.green;
		}
	}

	void OnTriggerExit (Collider collider) {
		bool notABall = !collider.GetComponent<Ball> ();

		if (notABall) {
			GameObject thingleft = collider.transform.parent.gameObject;
			if (thingleft.GetComponent<Pin> ()) {
				Destroy (thingleft);
			}
		}
	}
}
