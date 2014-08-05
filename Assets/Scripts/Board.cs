using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board
{
	private Dice dice;
	private Token token;
	private List<Teleporter> ladders;

	public int LastRollResult
	{
		get;
		private set;
	}

	public IToken Token
	{
		get { return token; }
	}

	public Board(Dice dice, List<Teleporter> ladders)
	{
		this.dice = dice;
		this.ladders = ladders;
		token = new Token();
	}

	public void RollDice()
	{
		LastRollResult = dice.Roll();
	}

	public void MoveToken()
	{
		token.Move (LastRollResult);
		Teleporter ladder = ladders.Find (l => l.initialPosition == token.Position);
		if (ladder != null)
			token.Move (ladder.finalPosition - ladder.initialPosition);
	}
}
