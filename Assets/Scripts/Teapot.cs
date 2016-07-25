using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public enum SmokeColor {
    BLUE, CYAN, GREEN, MAGENTA, RED, YELLOW, PURPLE, ORANGE, TURQUOISE, WHITE
}

[RequireComponent (typeof (Collider))]
public class Teapot : MonoBehaviour
{
    public SmokeColor smokeColor;
    public Color color;
    public TeapotPuzzle teapotPuzzle;

    private Renderer _renderer;

    void Awake ()
    {
        _renderer = this.gameObject.GetComponent<Renderer> ();
        _renderer.enabled = false;
    }

    void OnMouseEnter ()
    {
        _renderer.enabled = true;
    }

    void OnMouseExit ()
    {
        _renderer.enabled = false;
    }

    void OnMouseDown ()
    {
        teapotPuzzle.clickTeapot (smokeColor, color, this.transform.position);
    }
}
