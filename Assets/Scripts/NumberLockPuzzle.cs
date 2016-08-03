using UnityEngine;
using System.Collections;

/*
 * script describing behaviour of number lock puzzle in room two
 */
public class NumberLockPuzzle : MonoBehaviour
{
    // reference to puzzle manager
    public PuzzleTwoManager pm;
    // array of strings representing solution
    public string[] solutionNumbers;
    // the 3d text objects representing numbers diplayed
    public TextMesh[] numberTexts;
    // the game object boxes housing the texts
    public GameObject[] letterBoxes;
    // a green material
    public Material greenMat;

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
        for (int i=0; i<letterBoxes.Length; i++)
        {
            letterBoxes[i].GetComponent<Renderer>().material = greenMat;
        }
    }
}
