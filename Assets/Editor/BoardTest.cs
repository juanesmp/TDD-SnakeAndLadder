using UnityEngine;
using System.Collections;
using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class BoardTest
{
	private Board board;
	private Dice dice;

	[SetUp]
	public void Setup()
	{
		dice = Substitute.For<Dice> ();
		dice.Roll ().Returns (3);
		board = new Board(dice);
	}

	[Test]
	public void InitialPositionIsOne()
	{
		Assert.AreEqual(1, board.Token.Position);
	}

	[Test]
	public void PositionIsFiveAfterMovingThreeSpaces()
	{
		board.RollDice ();
		board.MoveToken ();
		Assert.AreEqual(4, board.Token.Position);
	}

	[Test]
	public void PositionisTenAfterMovingFourTheFiveSpaces()
	{
		dice.Roll ().Returns (4);
		board.RollDice ();
		board.MoveToken ();

		dice.Roll ().Returns (5);
		board.RollDice ();
		board.MoveToken ();

		Assert.AreEqual(10, board.Token.Position);
	}

	[Test]
	public void DiceRollIsBetweenOneAndSix()
	{
		board = new Board(new Dice());
		for (int i=0; i<100; i++)
		{
			board.RollDice();
			Assert.That(board.LastRollResult, Is.InRange (1, 6));
		}
	}
}
