using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;
	private float distanceToRaise = 50f;
	private Ball ball;
	private Animator animator;
	private PinCounter pinCounter;
	private ActionMaster actionMaster = new ActionMaster ();

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		pinCounter = GameObject.FindObjectOfType<PinCounter> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RaisePins() {
		Pin[] pins = GameObject.FindObjectsOfType<Pin> ();

		foreach (Pin pin in pins) 
		{
			pin.RaiseIfStanding ();
		}
	}

	public void LowerPins() {
		Pin[] pins = GameObject.FindObjectsOfType<Pin> ();

		foreach (Pin pin in pins) 
		{
			pin.Lower ();
		}
	}

	public void RenewPins() {
		Vector3 initialPosition = new Vector3 (pinSet.transform.position.x, distanceToRaise, pinSet.transform.position.z);
		Instantiate (pinSet, initialPosition, Quaternion.identity);
	}

	public void PerformAction (ActionMaster.Action action)
	{
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		} else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		} else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("Don't know how to handle end game yet!");
		}
	}
}
