using UnityEngine;
using System.Collections;

public class Board
{
	private Dice dice;
	private Token token;

	public int LastRollResult
	{
		get;
		private set;
	}

	public IToken Token
	{
		get { return token; }
	}

	public Board(Dice dice)
	{
		this.dice = dice;
		token = new Token();
	}

	public void RollDice()
	{
		LastRollResult = dice.Roll();
	}

	public void MoveToken()
	{
		token.Move (LastRollResult);
	}
}
