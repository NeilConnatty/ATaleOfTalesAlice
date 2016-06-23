using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PuzzleTwoManager : NetworkBehaviour
{
    public GameObject clockHint;
    public GameObject numberLock;

    public void activateClockHint ()
    {
        clockHint.SetActive (true);
    }

    public void finishClockPuzzle ()
    {
        numberLock.SetActive (true);
    }
}
