using UnityEngine;
using System.Collections;

public class Dice
{
	public virtual int Roll ()
	{
		return Random.Range (1, 7);
	}
}
