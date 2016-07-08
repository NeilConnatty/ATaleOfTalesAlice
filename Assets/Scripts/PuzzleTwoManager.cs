using UnityEngine;
using System.Collections;

public class PuzzleTwoManager : MonoBehaviour
{
    public GameObject clockHint;
    public GameObject numberLock;
    public GameObject clockImage;

    public void activateClockHint ()
    {
        clockHint.SetActive (true);
        clockImage.SetActive (true);
    }

    public void finishNumberLock ()
    {
        GameManager.gm.SolvePuzzle ();
    }
}
