using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	public Text standingDisplay;
	public GameObject pinSet;

	private bool ballOutOfPlay = false;
	private float distanceToRaise = 50f;
	private float lastChangeTime;
	private int lastStandingCount = -1;
	private int lastSettledCount = 10;
	private Ball ball;
	private Animator animator;
	private ActionMaster actionMaster = new ActionMaster ();

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType <Ball>();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballOutOfPlay) {
			UpdateStandingCountAndSettle ();
			standingDisplay.color = Color.red;
		}
	}

	public void SetBallOutOfPlay () {
		ballOutOfPlay = true;
	}

	public void RaisePins() {
		Pin[] pins = GameObject.FindObjectsOfType<Pin> ();

		foreach (Pin pin in pins) 
		{
			pin.RaiseIfStanding ();
			pin.transform.rotation = Quaternion.Euler(270f, 0f, 0f);
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


	void UpdateStandingCountAndSettle () {
		int currentStanding = CountStanding ();

		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
		} else {
			float settleTime = 3f;

			bool moreThanThreeSeconds = (Time.time - lastChangeTime) > settleTime;

			if (moreThanThreeSeconds) {
				PinsHaveSettled ();
			}
		}
	}

	void PinsHaveSettled () {
		int standing = CountStanding ();
		int pinFall = lastSettledCount - standing;

		lastSettledCount = standing;

		ActionMaster.Action action = actionMaster.Bowl (pinFall);
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
			lastSettledCount = 10;
		} else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
			lastSettledCount = 10;
		} else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException ("Don't know how to handle end game yet!");
		}

		ball.Reset ();
		lastStandingCount = -1;
		ballOutOfPlay = false;
		standingDisplay.color = Color.green;
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
}
