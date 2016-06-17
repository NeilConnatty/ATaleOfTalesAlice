using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour
{
    public static GameManager gm;
    public static NetworkManager nm;
    public string levelAfterVictory;
    public GameObject humptyDumptyPieceOne;

    void Awake ()
    {
        if (gm == null)
            gm = this.GetComponent<GameManager> ();

        if (nm == null)
            nm = GameObject.FindWithTag("NetworkManager").GetComponent<NetworkManager> ();

        humptyDumptyPieceOne.SetActive(false);
    }

    public void SolvePuzzle ()
    {
        humptyDumptyPieceOne.SetActive(true);
    }

    public void PickUpPiece ()
    {
        // TODO
    }
}
