using UnityEngine;
using System.Collections;

/*
 * Script to allow game to have custom cursor
 */
public class CustomCursor : MonoBehaviour
{
	public Texture2D cursor;
	public int cursorSizeX = 20;
	public int cursorSizeY = 20;

	void OnGUI ()
	{
		Cursor.SetCursor (cursor, Vector2.zero, CursorMode.ForceSoftware);
	}
}
