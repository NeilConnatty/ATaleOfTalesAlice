using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class CardTriangleRight : MonoBehaviour
{
    public CardLock cardLock;

    void OnMouseDown ()
    {
        cardLock.moveSelectedRight ();
    }
}
