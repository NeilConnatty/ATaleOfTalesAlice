using UnityEngine;
using System.Collections;

/*
 * script describing behaviour of downward triangle in number lock
 * and word-scramble lock
 */
public class TriangleDown : MonoBehaviour
{
    // reference to box containing Letter in associated with triangle
    public GameObject letterBox;

    private Letter _letter;
    private Renderer _myRenderer;

    void Awake ()
    {
        _myRenderer = this.gameObject.GetComponent<Renderer>();
        _myRenderer.enabled = false;
    }

    void Start ()
    {
        if (letterBox) {
            _letter = letterBox.GetComponent("Letter") as Letter;
        } else {
            Debug.LogError ("TriangleDown reference to LetterBox not set");
        }
    }

    void OnMouseDown ()
    {
        _letter.LetterDown ();
    }

    void OnMouseEnter ()
    {
        _myRenderer.enabled = true;
    }

    void OnMouseExit ()
    {
        _myRenderer.enabled = false;
    }
}
