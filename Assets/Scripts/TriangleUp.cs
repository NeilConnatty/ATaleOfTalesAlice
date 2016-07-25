using UnityEngine;
using System.Collections;

public class TriangleUp : MonoBehaviour
{
    public GameObject letterBox;
    public Material redMat;
    public Material greenMat;

    private Letter _letter;
    private Renderer _myRenderer;

    void Awake ()
    {
        _myRenderer = this.gameObject.GetComponent<Renderer>();
        _myRenderer.enabled = false;
        //_myRenderer.material = redMat;
    }

    void Start ()
    {
        if (letterBox) {
            _letter = letterBox.GetComponent("Letter") as Letter;
        } else {
            Debug.LogError ("TriangleUp reference to LetterBox not set");
        }

    }

    void OnMouseDown ()
    {
        _letter.LetterUp ();
    }

    void OnMouseEnter ()
    {
        _myRenderer.enabled = true;
        //_myRenderer.sharedMaterial = greenMat;
    }

    void OnMouseExit ()
    {
        _myRenderer.enabled = false;
        //_myRenderer.sharedMaterial = redMat;
    }
}
