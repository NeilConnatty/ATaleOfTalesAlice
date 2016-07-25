using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{
    public static GameManager gm;
    public GameObject humptyDumptyPiece;
    public Door door;

    [SyncVar(hook="StateChange")] int noPuzzlesSolved = 0;

    void Awake ()
    {
        if (gm == null)
            gm = this.GetComponent<GameManager> ();

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
        door.OpenDoor ();
    }
}
