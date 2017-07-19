﻿using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster actionMaster;
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;

	[SetUp]
	public void Setup() {
		actionMaster = new ActionMaster ();
	}

	[Test]
	public void T00PassingTest() {
		Assert.AreEqual (2, 2);
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn() {
		Assert.AreEqual (endTurn, actionMaster.Bowl(10));
	}

	[Test]
	public void T02Bowl8ReturnsTidy() {
		Assert.AreEqual (tidy, actionMaster.Bowl(8));
	}

	[Test]
	public void T03Bowl28ReturnsEndTurn() {
		Assert.AreEqual (tidy, actionMaster.Bowl(8));
		Assert.AreEqual (endTurn, actionMaster.Bowl(2));
	}
}
