using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class CardTriangleLeft : MonoBehaviour
{
    public CardLock cardLock;

    void OnMouseDown ()
    {
        cardLock.moveSelectedLeft ();
    }
}
