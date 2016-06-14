using UnityEngine;
using System.Collections;

public class TriangleDown : MonoBehaviour
{
    public GameObject letterBox;
    private Letter _letter;

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
}
