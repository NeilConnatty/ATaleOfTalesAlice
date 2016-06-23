using UnityEngine;
using System.Collections;

public class TeapotPuzzle : MonoBehaviour
{
    public SmokeColor[] solution;

    private int _numberCorrect;

    void Awake ()
    {
        _numberCorrect = 0;
    }

    public void submitSmoke (SmokeColor color)
    {
        if (solution[_numberCorrect] == color) {
            _numberCorrect++;
            if (_numberCorrect == 4) {
                solvePuzzle ();

            }
        } else {
            _numberCorrect = 0;
        }


    }

    public void solvePuzzle ()
    {
        Debug.Log("solved teapot puzzle");
        // TODO
    }
}
