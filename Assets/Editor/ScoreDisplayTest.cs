using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {

	[Test]
	public void T00PassingTest() {
		Assert.AreEqual (2, 2);
	}

	[Test]
	public void T01Bowl1() {
		int[] rolls = { 1 };
		string rollsString = "1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}
}
