using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Word : MonoBehaviour
{
    public CrosswordInputField[] inputLetters;
    public CrosswordPuzzle puzzle;

    public Color editingColor;
    public Color correctColor;
    public Color incorrectColor;

    private bool _isCorrect;

    void Awake ()
    {
        _isCorrect = false;
    }

    public void inputUpdate ()
    {
        // if word not full
        if (!checkWordFull ()) {
            clearSolution ();
            return;
        }
        if (checkLetters ()) {
            _isCorrect = true;
            acceptSolution ();
            puzzle.checkIfSolved ();
        } else {
            _isCorrect = false;
            rejectSolution ();
        }
    }

    public bool isWordCorrect ()
    {
        return _isCorrect;
    }

    // returns true if there is an input for every letter of the word
    bool checkWordFull ()
    {
        foreach (CrosswordInputField input in inputLetters) {
            if (!input.hasInput ()) return false;
        }
        return true;
    }

    // returns true if every letter in the word is correct
    bool checkLetters ()
    {
        foreach (CrosswordInputField input in inputLetters) {
            if (!input.isSolution ()) return false;
        }
        return true;
    }

    void acceptSolution ()
    {
        foreach (CrosswordInputField input in inputLetters) {
            input.setColor (correctColor);
            //input.makeUninteractable ();
        }
    }

    void rejectSolution ()
    {
        foreach (CrosswordInputField input in inputLetters) {
            input.setColor (incorrectColor);
        }
    }

    void clearSolution ()
    {
        foreach (CrosswordInputField input in inputLetters) {
            input.setColor (editingColor);
        }
    }
}
