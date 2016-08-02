using UnityEngine;
using System.Collections;

/*
 * Depreciated
 */
public class HumptyPiece : MonoBehaviour
{
    void OnMouseDown ()
    {
        GameManager.gm.PickUpPiece ();
    }
}
