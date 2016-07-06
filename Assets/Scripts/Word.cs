using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Word : MonoBehaviour
{
    public CrosswordInputField[] inputLetters;

    public void inputUpdate ()
    {
        // if word not full
        if (!checkWordFull ()) {
            clearSolution ();
            return;
        }
        if (checkLetters ()) {
            acceptSolution ();
        } else {
            rejectSolution ();
        }
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
            input.setColor (Color.green);
            //input.makeUninteractable ();
        }
    }

    void rejectSolution ()
    {
        foreach (CrosswordInputField input in inputLetters) {
            input.setColor (Color.red);
        }
    }

    void clearSolution ()
    {
        foreach (CrosswordInputField input in inputLetters) {
            input.setColor (Color.white);
        }
    }
}
