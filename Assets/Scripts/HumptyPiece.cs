using UnityEngine;
using System.Collections;

public class HumptyPiece : MonoBehaviour
{
    void OnMouseDown ()
    {
        GameManager.gm.PickUpPiece ();
        GameState.gs.loadNextScene ();
    }
}
