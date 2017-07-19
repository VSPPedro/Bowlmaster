using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	void OnTriggerExit (Collider collider) {
		bool notABall = !collider.GetComponent<Ball> ();

		if (notABall) {
			GameObject thingleft = collider.transform.gameObject;
			if (thingleft.GetComponent<Pin> ()) {
				Destroy (thingleft);
			}
		}
	}
}
