using UnityEngine;
using System.Collections;

public class PuzzleTwoManager : MonoBehaviour
{
    public GameObject clockHint;
    public GameObject numberLock;

    public void activateClockHint ()
    {
        clockHint.SetActive (true);
    }

    public void finishClockPuzzle ()
    {
        //numberLock.SetActive (true);
    }

    public void finishNumberLock ()
    {
        GameManager.gm.SolvePuzzle ();
    }
}
