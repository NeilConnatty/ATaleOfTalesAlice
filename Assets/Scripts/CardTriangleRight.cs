using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class CardTriangleRight : MonoBehaviour
{
    public CardLock cardLock;

    public Material redMat;
    public Material greenMat;

    private Renderer _myRenderer;

    void Awake ()
    {
        _myRenderer = this.gameObject.GetComponent<Renderer>();
        _myRenderer.material = redMat;
    }

    void OnMouseDown ()
    {
        cardLock.moveSelectedRight ();
    }

    void OnMouseEnter ()
    {
        _myRenderer.material = greenMat;
    }

    void OnMouseExit ()
    {
        _myRenderer.material = redMat;
    }
}
