using UnityEngine;
using System.Collections;

public interface IToken
{
	int Position { get; }
}

public class Token : IToken
{
	public int Position
	{
		get;
		private set;
	}

	public Token()
	{
		Position = 1;
	}

	public void Move(int spaces)
	{
		Position += spaces;
	}
}
