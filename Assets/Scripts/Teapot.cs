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

    void OnMouseDown ()
    {
        teapotPuzzle.clickTeapot (smokeColor, color, this.transform.position);
    }
}
