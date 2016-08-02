using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
/*
 * Script describing behaviour of triangle that moves a card right in card lock puzzle
 */
public class CardTriangleRight : MonoBehaviour
{
    // reference to card lock puzzle
    public CardLock cardLock;
    // materials that change when mouse hovers over object
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
