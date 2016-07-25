using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class CheshireCat : MonoBehaviour
{
    public CardLock cardLock;
    public TextMesh catTextOne;
    public TextMesh catTextTwo;
    public GameObject highlight;

    private Renderer _highlightRenderer;

    void Awake ()
    {
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
        if (cardLock.checkCorrectness ()) {
            catTextOne.text = "You did it, you've\nput them in line.";
            catTextTwo.text = "Now go fix this\nfriend of mine.";
            GameManager.gm.SolvePuzzle ();
        } else {
            catTextOne.text = "That isn't right.\nThey're still not\nin line.";
        }
    }
}
