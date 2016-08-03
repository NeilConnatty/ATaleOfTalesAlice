using UnityEngine;
using System.Collections;

/*
 * Script that manages activating significant game objects in room two
 */
public class PuzzleTwoManager : MonoBehaviour
{
    public GameObject clockHint;
    public GameObject numberLock;
    public GameObject clockImage;

    public void activateClockHint ()
    {
        clockHint.SetActive (true);
        clockImage.SetActive (true);
        numberLock.SetActive (true);
    }

    public void finishNumberLock ()
    {
        GameManager.gm.SolvePuzzle ();
    }
}
