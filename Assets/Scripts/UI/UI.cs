using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UI : MonoBehaviour 
{
	private Board board = new Board(new Dice(), new List<Teleporter>() { new Teleporter(2, 12), new Teleporter(8, 3) }, 100);

	private void OnGUI()
	{
		Rect rect = new Rect(10, 10, 200, 30);
		GUI.Label (rect, "Token position: " + board.Token.Position);

		rect.y += rect.height + 5;
		GUI.Button (rect, "Roll");
	}
}
