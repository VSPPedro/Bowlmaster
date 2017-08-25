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

	//Return a list of individual frame scroes, NOT cumulative.
	public static List<int> ScoreFrames(List<int> rolls){
		List<int> frameList = new List<int> ();



		return frameList;
	}
}
