using UnityEngine;
using System.Collections;

/*
 * Script managing behaviour of humpty object in maze
 */
public class HumptyManager : MonoBehaviour
{
    public GameObject pieceOne;
    public GameObject pieceTwo;
    public GameObject wholeHumpty;

    void Start ()
    {
        pieceOne.SetActive (false);
        pieceTwo.SetActive (false);
        wholeHumpty.SetActive (false);
        InitializePieces ();
    }

    void InitializePieces ()
    {
        State gameState = GameState.gs.getState ();
        switch (gameState) {
            case State.PUZZLE1 :
                pieceOne.SetActive (true);
                break;

            case State.MAZE2 :
                pieceOne.SetActive (true);
                break;

            case State.PUZZLE2 :
                pieceOne.SetActive (true);
                pieceTwo.SetActive (true);
                break;

            case State.MAZE3 :
                pieceOne.SetActive (true);
                pieceTwo.SetActive (true);
                break;

            case State.PUZZLE3 :
                wholeHumpty.SetActive (true);
                break;

            case State.MAZE4 :
                wholeHumpty.SetActive (true);
                break;
        }
    }
}
