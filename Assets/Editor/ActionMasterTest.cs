using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;

	[Test]
	public void T00PassingTest() {
		Assert.AreEqual (2, 2);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn() {
		ActionMaster actionMaster = new ActionMaster ();
		Assert.AreEqual (endTurn, actionMaster.Bowl(10));
	}
}
