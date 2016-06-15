using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MagicWord : MonoBehaviour
{
	public CrosswordInputField[] magicLetters;

	private Color[] _previousColors;

	void Start ()
	{
		_previousColors = new Color[magicLetters.Length];
	}

	public void lightSwtichOn ()
	{
		for (int i = 0; i < magicLetters.Length; i++) {
			_previousColors[i] = magicLetters[i].getColor ();
			magicLetters[i].setColor (Color.yellow);
		}
	}

	public void lightSwtichOff ()
	{
		for (int i = 0; i < magicLetters.Length; i++) {
			magicLetters[i].setColor (_previousColors[i]);
		}
	}

}
