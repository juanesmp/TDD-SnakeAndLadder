using UnityEngine;
using System.Collections;

public class Dice
{
	public virtual int LastRollResult
	{
		get;
		private set;
	}

	public void Roll ()
	{
		LastRollResult = Random.Range (1, 7);
	}
}
