using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{
    public static GameManager gm;
    public string levelAfterVictory;
    public GameObject humptyDumptyPieceOne;

    void Awake ()
    {
        if (gm == null)
            gm = this.GetComponent<GameManager> ();

        humptyDumptyPieceOne.SetActive(false);
    }

    public void SolvePuzzle ()
    {
        humptyDumptyPieceOne.SetActive(true);
    }

    public void PickUpPiece ()
    {
        Debug.Log ("receive click");
    }
}
