using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PuzzleOneManager : NetworkBehaviour
{
    public GameObject wordLock;

    [SyncVar(hook="StateChange")] int crosswordSolved = 0;

    void Awake ()
    {
        wordLock.SetActive (false);
    }

    public void CompleteCrosswordPuzzle ()
    {
        Debug.Log ("PuzzleOneManager.CompleteCrosswordPuzzle () called");
        crosswordSolved += 1;
    }

    void StateChange (int newState)
    {
        crosswordSolved = newState;
        Debug.Log ("Setting word lock to active");
        wordLock.SetActive (true);
    }
}
