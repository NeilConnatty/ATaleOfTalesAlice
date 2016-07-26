using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{
    public static GameManager gm;
    public GameObject humptyUI;
    public Door door;

    [SyncVar(hook="StateChange")] int noPuzzlesSolved = 0;
    [SyncVar(hook="ActivateHumpty")] bool doorEntered = false;

    void Awake ()
    {
        if (gm == null)
            gm = this.GetComponent<GameManager> ();

        humptyUI.SetActive(false);
    }

    public void SolvePuzzle ()
    {
        noPuzzlesSolved += 1;
    }

    public void PickUpPiece ()
    {
        GameState.gs.loadNextScene ();
    }

    public void EnterDoor ()
    {
        doorEntered = true;
        StartCoroutine (loadNextScene ());
    }

    IEnumerator loadNextScene ()
    {
        yield return new WaitForSeconds (3.0f);
        GameState.gs.loadNextScene ();
    }

    IEnumerator ActivateHumptyUI ()
    {
        yield return new WaitForSeconds (0.5f);
        humptyUI.SetActive (true);
    }

    void StateChange (int newState)
    {
        noPuzzlesSolved = newState;
        door.OpenDoor ();
    }

    void ActivateHumpty (bool newState)
    {
        doorEntered = newState;
        StartCoroutine (ActivateHumptyUI ());
    }
}
