using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Script describing word in crossword puzzle
 */
public class Word : MonoBehaviour
{
    // array of input fields that compose word
    public CrosswordInputField[] inputLetters;
    // reference to CrosswordPuzzle script
    public CrosswordPuzzle puzzle;

    public Color editingColor;
    public Color correctColor;
    public Color incorrectColor;

    private bool _isCorrect;

    void Awake ()
    {
        _isCorrect = false;
    }

    /*
     * Called whenever a letter's input is changed in word
     */
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
