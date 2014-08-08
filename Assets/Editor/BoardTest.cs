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
	private const int FINAL_POSITION = 100;

	[SetUp]
	public void Setup()
	{
		dice = Substitute.For<Dice> ();
		ladders = new List<Teleporter>() { new Teleporter(2, 12), new Teleporter(8, 3) };
		board = new Board(dice, ladders, FINAL_POSITION);
	}

	[Test]
	public void InitialPositionIsOne()
	{
		Assert.AreEqual(1, board.Token.Position);
	}

	[Test]
	public void PositionIsFiveAfterMovingThreeSpaces()
	{
		CheckPositionAfterMovingSpaces(4, 3);
	}

	[Test]
	public void PositionisTenAfterMovingFourTheFiveSpaces()
	{
		CheckPositionAfterMovingSpaces(10, 4, 5);
	}

	[Test, Repeat(100)]
	public void DiceRollIsBetweenOneAndSix()
	{
		board = new Board(new Dice(), ladders, FINAL_POSITION);
		board.RollDice();
		Assert.That(board.LastRollResult, Is.InRange (1, 6));
	}

	[Test]
	public void PositionChangeToTheEndOfLadder()
	{
		CheckPositionAfterMovingSpaces(12, 1);
	}

	[Test]
	public void PositionChangeToTheBegginingOfSnake()
	{
		CheckPositionAfterMovingSpaces(3, 2, 5);
	}

	[Test]
	public void IfLastMoveEqualsToFinalPositionPlayerWins()
	{
		MoveToPosition (FINAL_POSITION - 3);
		MoveSpaces(3);
		Assert.AreEqual(board.Token, board.WinnerToken);
	}

	[Test]
	public void IfLastMoveExceedsFinalPositionTokenStaysInCurrentPosition()
	{
		MoveToPosition (FINAL_POSITION - 3);
		MoveSpaces(4);
		Assert.AreEqual(FINAL_POSITION - 3, board.Token.Position);
	}

	private void CheckPositionAfterMovingSpaces(int expectedPosition, params int[] spaces)
	{
		foreach (int space in spaces)
			MoveSpaces(space);
		Assert.AreEqual(expectedPosition, board.Token.Position);
	}

	private void MoveSpaces(int spaces)
	{
		dice.LastRollResult.Returns (spaces);
		board.RollDice ();
		board.MoveToken ();
	}

	private void MoveToPosition (int position)
	{
		while (board.Token.Position < position)
			MoveSpaces (1);
	}
}
