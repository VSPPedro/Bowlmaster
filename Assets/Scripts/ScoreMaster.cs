using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster : MonoBehaviour {

	//Returns a list of cumulative scores, like a normal score card.
	public static List<int> ScoreCumulative (List<int> rolls) {
		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames (rolls)) {
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}

		return cumulativeScores;
	}

	//Return a list of individual frame scores, NOT cumulative.
	public static List<int> ScoreFrames(List<int> rolls){
		List<int> frames = new List<int> ();

		for (int i = 0; i < rolls.Count; i+= 2) {

			if (frames.Count == 10) { break; }

			if (rolls [i - 1] + rolls [i] < 10) {
				frames.Add (rolls [i - 1] + rolls [i]);
			}

			if (rolls.Count - i <= 1) { break; }

			if (rolls [i - 1] == 10) {
				frames.Add (10 +  rolls [i] + rolls [i + 1]);
			} else if (rolls [i - 1] + rolls [i] == 10) {
				frames.Add (10 +  rolls [i + 1]);
			}

		}

		return frames;
	}
}
