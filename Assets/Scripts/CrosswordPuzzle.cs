using UnityEngine;
using System.Collections;

/*
 * Script describing behaviour of crossword puzzle
 */
public class CrosswordPuzzle : MonoBehaviour
{
    public Word[] words;

    private bool _isSolved;

    void Awake ()
    {
        _isSolved = false;
    }

    public void checkIfSolved ()
    {
        if (_isSolved) return;
        foreach (Word word in words) {
            if (!word.isWordCorrect ()) return;
        }
        _isSolved = true;
    }
}
