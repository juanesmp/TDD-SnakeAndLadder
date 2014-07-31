using UnityEngine;
using System.Collections;
using NUnit.Framework;

[TestFixture]
public class BoardTest
{
	[Test]
	public void InitialPositionIsOne()
	{
		Board board = new Board();
		Assert.AreEqual(1, board.Position);
	}

	[Test]
	public void PositionIsFourAfterMovingThreeSpaces()
	{
		Board board = new Board();
		board.Move (3);
		Assert.AreEqual(4, board.Position);
	}
}
