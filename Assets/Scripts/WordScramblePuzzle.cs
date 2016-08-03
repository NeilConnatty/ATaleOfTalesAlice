using UnityEngine;
using System.Collections;

/*
 * Script describing word scramble puzzle in room one
 */
public class WordScramblePuzzle : MonoBehaviour
{
    public int solutionLength;
    // array representing solution word
    public string[] solutionLetters;
    public GameObject[] letterTexts;
    public GameObject[] letterBoxes;
    public Material greenMat;

    private TextMesh[] _letters;

    void Start ()
    {
        _letters = new TextMesh[solutionLength];

        for (int i = 0; i < solutionLength; i++) {
            _letters[i] = letterTexts[i].GetComponent<TextMesh>();
        }
    }

    void Update ()
    {
        bool _solved = false;

        for (int i = 0; i < solutionLength; i++) {
            if (solutionLetters[i].Equals(_letters[i].text)) {
                _solved = true;
            } else {
                _solved = false;
                break;
            }
        }
        if (_solved) {
            LockInPuzzle ();
            GameManager.gm.SolvePuzzle ();
        }
    }

    void LockInPuzzle ()
    {
        for (int i=0; i<letterBoxes.Length; i++)
        {
            letterBoxes[i].GetComponent<Renderer>().material = greenMat;
        }
    }
}
