using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

/*
 * Script that manages behaviour of game when solving a puzzle
 */
public class GameManager : NetworkBehaviour
{
    // static reference to this script
    public static GameManager gm;
    // UI congratulating player for finishing room
    public GameObject humptyUI;
    // door object
    public Door door;

    // variables to syncronize behaviour across network
    [SyncVar(hook="StateChange")] int noPuzzlesSolved = 0;
    [SyncVar(hook="ActivateHumpty")] bool doorEntered = false;

    void Awake ()
    {
        if (gm == null)
            gm = this.GetComponent<GameManager> ();

        humptyUI.SetActive(false);
    }

    /*
     * called when room's puzzle is completed
     */
    public void SolvePuzzle ()
    {
        noPuzzlesSolved += 1;
    }

    /*
     * Depreciated
     */
    public void PickUpPiece ()
    {
        GameState.gs.loadNextScene ();
    }

    /*
     * Called when player one enters door to exit room
     */
    public void EnterDoor ()
    {
        doorEntered = true;
        StartCoroutine (loadNextScene ());
    }

    /*
     * Tell GameState to load next scene
     */
    IEnumerator loadNextScene ()
    {
        yield return new WaitForSeconds (3.0f);
        GameState.gs.loadNextScene ();
    }

    /*
     * Activate congratulations UI
     */
    IEnumerator ActivateHumptyUI ()
    {
        yield return new WaitForSeconds (0.5f);
        humptyUI.SetActive (true);
    }

    /*
     * called on clients when noPuzzlesSolved value changed on server
     */
    void StateChange (int newState)
    {
        noPuzzlesSolved = newState;
        door.OpenDoor ();
    }

    /*
     * called on clients when doorEntered value changed on server
     */
    void ActivateHumpty (bool newState)
    {
        doorEntered = newState;
        StartCoroutine (ActivateHumptyUI ());
    }
}
