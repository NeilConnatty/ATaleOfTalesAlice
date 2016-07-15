using UnityEngine;
using System.Collections;

public class CrosswordPuzzle : MonoBehaviour
{
    public Word[] words;
    public PuzzleOneManager pm;

    private bool _isSolved;

    void Awake ()
    {
        _isSolved = false;
    }

    public void checkIfSolved ()
    {
        if (_isSolved) return;
        Debug.Log ("Checking if solved");
        foreach (Word word in words) {
            if (!word.isWordCorrect ()) return;
        }
        _isSolved = true;
        Debug.Log ("solved: " + _isSolved);
        pm.CompleteCrosswordPuzzle ();
    }
}
