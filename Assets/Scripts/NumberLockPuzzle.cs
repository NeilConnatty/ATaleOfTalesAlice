using UnityEngine;
using System.Collections;

public class NumberLockPuzzle : MonoBehaviour
{
    public PuzzleTwoManager pm;

    public string[] solutionNumbers;
    public TextMesh[] numberTexts;

    void Update ()
    {
        bool _solved = false;

        for (int i = 0; i < solutionNumbers.Length; i++) {
            if (solutionNumbers[i].Equals(numberTexts[i].text)) {
                _solved = true;
            } else {
                _solved = false;
                break;
            }
        }
        if (_solved) {
            LockInPuzzle ();
            pm.finishNumberLock ();
        }
    }

    void LockInPuzzle ()
    {
        // TODO
    }
}
