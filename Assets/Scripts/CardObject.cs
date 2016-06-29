using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class CardObject : MonoBehaviour
{
    private bool _selected;

    public CardLock cardLock;

    void Awake ()
    {
        _selected = false;
    }

    void OnMouseDown ()
    {
        cardLock.ResetAll ();
        _selected = true;
        cardLock.determineSelected ();
    }

    public bool isSelected ()
    {
        return _selected;
    }

    public void Reset ()
    {
        _selected = false;
    }
}
