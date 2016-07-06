using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MagicWord : MonoBehaviour
{
	public CrosswordInputField[] magicLetters;

	public void lightSwtichOn ()
	{
		for (int i = 0; i < magicLetters.Length; i++) {
			magicLetters[i].makeHighlighted ();
		}
	}

	public void lightSwtichOff ()
	{
		for (int i = 0; i < magicLetters.Length; i++) {
			magicLetters[i].makeUnhighlighted ();
		}
	}
}
