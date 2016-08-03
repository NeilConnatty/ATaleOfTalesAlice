using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public enum SmokeColor {
    BLUE, CYAN, GREEN, MAGENTA, RED, YELLOW, PURPLE, ORANGE, TURQUOISE, WHITE
}

[RequireComponent (typeof (Collider))]
/*
 * Script describing the behaviour of teapot in room two
 */
public class Teapot : MonoBehaviour
{
    // colour of smoke emitted by teapot as enum
    public SmokeColor smokeColor;
    // colour of smoke emitted by teapot as Color
    public Color color;
    // reference to teapot puzzle 
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
