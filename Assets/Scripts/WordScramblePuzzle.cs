using UnityEngine;
using System.Collections;

public class WordScramblePuzzle : MonoBehaviour
{
    public int solutionLength;
    public string[] solutionLetters;
    public GameObject[] letterTexts;

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
        if (_solved) GameManager.gm.SolvePuzzle ();
    }
}
