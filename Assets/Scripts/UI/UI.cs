using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI : MonoBehaviour 
{
	private Board board;

	private void Awake()
	{
		List<Teleporter> teleporters = new List<Teleporter>() { new Teleporter(2, 12), new Teleporter(8, 3) };
		int finalPosition = 100;
		Dice dice = new Dice();
		board = new Board(dice, teleporters, finalPosition);
	}

	private void OnGUI()
	{
		Rect rect = new Rect(10, 10, 200, 30);

		if (board.WinnerToken == null)
			DrawGameplayUI (rect);
		else
			GUI.Label (rect, "You won");
	}

	private void DrawGameplayUI (Rect rect)
	{
		GUI.Label (rect, "Token position: " + board.Token.Position);

		rect.y += rect.height;
		GUI.Label (rect, "Last Roll Result: " + board.LastRollResult);

		rect.y += rect.height + 5;
		DrawRollButton (rect);
	}

	private void DrawRollButton (Rect rect)
	{
		bool clicked = GUI.Button (rect, "Roll");
		if (clicked) 
		{
			board.RollDice ();
			board.MoveToken ();
		}
	}
}
