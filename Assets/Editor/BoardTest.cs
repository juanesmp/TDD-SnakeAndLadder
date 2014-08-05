using UnityEngine;
using System.Collections;
using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

[TestFixture]
public class BoardTest
{
	private Board board;
	private Dice dice;
	private List<Teleporter> ladders;

	[SetUp]
	public void Setup()
	{
		dice = Substitute.For<Dice> ();
		ladders = new List<Teleporter>() { new Teleporter(2, 12), new Teleporter(8, 3) };
		board = new Board(dice, ladders);
	}

	[Test]
	public void InitialPositionIsOne()
	{
		Assert.AreEqual(1, board.Token.Position);
	}

	[Test]
	public void PositionIsFiveAfterMovingThreeSpaces()
	{
		MoveSpaces(3);
		Assert.AreEqual(4, board.Token.Position);
	}

	[Test]
	public void PositionisTenAfterMovingFourTheFiveSpaces()
	{
		MoveSpaces(4);
		MoveSpaces(5);

		Assert.AreEqual(10, board.Token.Position);
	}

	[Test]
	public void DiceRollIsBetweenOneAndSix()
	{
		board = new Board(new Dice(), ladders);
		for (int i=0; i<100; i++)
		{
			board.RollDice();
			Assert.That(board.LastRollResult, Is.InRange (1, 6));
		}
	}

	[Test]
	public void PositionChangeToTheEndOfLadder()
	{
		MoveSpaces(1);
		Assert.AreEqual(12, board.Token.Position);
	}

	[Test]
	public void PositionChangeToTheBegginingOfSnake()
	{
		MoveSpaces(2);
		MoveSpaces(5);
		Assert.AreEqual(3, board.Token.Position);
	}
	
	private void MoveSpaces(int spaces)
	{
		dice.Roll ().Returns (spaces);
		board.RollDice ();
		board.MoveToken ();
	}
}
