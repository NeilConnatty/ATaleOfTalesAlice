using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{
    public static GameManager gm;
    public static NetworkManager nm;
    public GameObject humptyDumptyPiece;

    [SyncVar(hook="StateChange")] int noPuzzlesSolved = 0;

    void Awake ()
    {
        if (gm == null)
            gm = this.GetComponent<GameManager> ();

        if (nm == null)
            nm = GameObject.FindWithTag("NetworkManager").GetComponent<NetworkManager> ();

        humptyDumptyPiece.SetActive(false);
    }

    public void SolvePuzzle ()
    {
        noPuzzlesSolved += 1;
    }

    public void PickUpPiece ()
    {
        GameState.gs.loadNextScene ();
    }

    void StateChange (int newState)
    {
        noPuzzlesSolved = newState;
        humptyDumptyPiece.SetActive (true);
    }
}
