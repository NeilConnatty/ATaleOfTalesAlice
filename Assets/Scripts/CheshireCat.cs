using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class CheshireCat : MonoBehaviour
{
    public CardLock cardLock;

    void OnMouseDown ()
    {
        if (cardLock.checkCorrectness ()) {
            Debug.Log ("correct!");
            GameManager.gm.SolvePuzzle ();
        } else {
            Debug.Log ("not correct");
        }
    }
}
