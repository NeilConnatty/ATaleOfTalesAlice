using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PuzzleOneManager : NetworkBehaviour
{
    public GameObject wordLock;

    [SyncVar(hook="StateChange")] bool crosswordSolved;

    private NetworkIdentity _myIdentity;

    void Awake ()
    {
        wordLock.SetActive (false);
        _myIdentity = GetComponent<NetworkIdentity> ();
    }

    void OnStartClient ()
    {
        Debug.Log ("called on start client in pm");
        int count = _myIdentity.observers.Count;
        if (_myIdentity.AssignClientAuthority (_myIdentity.observers[count-1])) return;
        Debug.LogError ("didnt assign client authority");
    }

    [Server]
    void InitState ()
    {
        crosswordSolved = false;
    }

    public void CompleteCrosswordPuzzle ()
    {
        Debug.Log ("PuzzleOneManager.CompleteCrosswordPuzzle () called");
        CmdChangeState ();
        //crosswordSolved = true;
        //wordLock.SetActive (true);
    }

    [Command]
    void CmdChangeState ()
    {
        crosswordSolved = true;
    }

    void StateChange (bool newState)
    {
        crosswordSolved = newState;
        Debug.Log ("Setting word lock to active");
        wordLock.SetActive (true);
    }

}
