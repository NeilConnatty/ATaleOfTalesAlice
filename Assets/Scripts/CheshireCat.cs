using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class CheshireCat : MonoBehaviour
{
    public CardLock cardLock;
    public TextMesh catTextOne;
    public TextMesh catTextTwo;

    void OnMouseDown ()
    {
        if (cardLock.checkCorrectness ()) {
            catTextOne.text = "Thank you, you've\nput them in line.";
            catTextTwo.text = "Now go fix this\nfriend of mine.";
            GameManager.gm.SolvePuzzle ();
        } else {
            catTextOne.text = "That isn't right.\nThey're still not\nin line.";
        }
    }
}
