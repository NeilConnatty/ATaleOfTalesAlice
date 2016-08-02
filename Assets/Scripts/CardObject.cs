using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
/*
 * Script describing behaviour of object on which card material will be rendered
 */
public class CardObject : MonoBehaviour
{
    private bool _selected;

    // reference to card lock puzzle
    public CardLock cardLock;
    // reference to gameobject that highlights card when mouse hovers over
    public GameObject highlight;

    private Renderer _highlightRenderer;

    void Awake ()
    {
        _selected = false;
        _highlightRenderer = highlight.GetComponent<Renderer> ();
        _highlightRenderer.enabled = false;
    }

    void OnMouseEnter ()
    {
        _highlightRenderer.enabled = true;
    }

    void OnMouseExit ()
    {
        _highlightRenderer.enabled = false;
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
