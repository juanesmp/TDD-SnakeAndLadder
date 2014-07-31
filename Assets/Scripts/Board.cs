using UnityEngine;
using System.Collections;

public class Board
{
	public int Position
	{
		get;
		private set;
	}

	public Board()
	{
		Position = 1;
	}

	public void Move(int spaces)
	{
		Position = 4;
	}
}
