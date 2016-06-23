using UnityEngine;
using System.Collections;

public class TeapotPuzzle : MonoBehaviour
{
    public SmokeColor[] solution;
    public PuzzleTwoManager pm;
    public GameObject particleSystem;

    private int _numberCorrect;

    void Awake ()
    {
        _numberCorrect = 0;
    }

    public void makeSmoke (SmokeColor color, Vector3 position)
    {
        GameObject ps = Instantiate (particleSystem);
        ps.transform.position = position;
        Destroy(ps, 10.0f);
    }

    public void submitSmoke (SmokeColor color)
    {
        if (solution[_numberCorrect] == color) {
            _numberCorrect++;
            if (_numberCorrect == 4) {
                solvePuzzle ();
                _numberCorrect = 0;
            }
        } else {
            _numberCorrect = 0;
        }
    }

    public void solvePuzzle ()
    {
        pm.activateClockHint ();
    }



}
