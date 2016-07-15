using UnityEngine;
using System.Collections;

public class TriangleDown : MonoBehaviour
{
    public GameObject letterBox;
    public Material redMat;
    public Material pinkMat;

    private Letter _letter;
    private Renderer _myRenderer;

    void Awake ()
    {
        _myRenderer = this.gameObject.GetComponent<Renderer>();
        _myRenderer.material = redMat;
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
        _myRenderer.sharedMaterial = pinkMat;
    }

    void OnMouseExit ()
    {
        _myRenderer.sharedMaterial = redMat;
    }
}
