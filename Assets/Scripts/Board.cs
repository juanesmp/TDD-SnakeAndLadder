using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board
{
	private Dice dice;
	private Token token;
	private List<Teleporter> ladders;

	private int finalPosition;

	public int LastRollResult
	{
		get{ return dice.LastRollResult; }
	}

	public IToken WinnerToken 
	{
		get;
		private set;
	}

	public IToken Token
	{
		get { return token; }
	}

	public Board(Dice dice, List<Teleporter> ladders, int finalPosition)
	{
		this.dice = dice;
		this.ladders = ladders;
		this.finalPosition = finalPosition;
		token = new Token();
	}

	public void RollDice()
	{
		dice.Roll();
	}

	public void MoveToken()
	{
		if (token.Position + LastRollResult <= finalPosition)
			token.Move (LastRollResult);

		ApplyTeleporter();
		CheckWinCondition ();
	}

	private void ApplyTeleporter()
	{
		Teleporter teleporter = ladders.Find (l => l.initialPosition == token.Position);
		if (teleporter != null)
			token.Move (teleporter.finalPosition - teleporter.initialPosition);
	}

	private void CheckWinCondition ()
	{
		if (token.Position == finalPosition)
			WinnerToken = token;
	}
}
