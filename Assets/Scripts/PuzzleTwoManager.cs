using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PuzzleTwoManager : NetworkBehaviour
{
    public GameObject clockHint;

    public void activateClockHint ()
    {
        clockHint.SetActive (true);
    }
}
