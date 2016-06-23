using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public enum SmokeColor {
    BLUE, CYAN, GREEN, MAGENTA, RED, YELLOW
}

[RequireComponent (typeof (Collider))]
public class Teapot : MonoBehaviour
{
    public SmokeColor smokeColor;
    public ParticleSystem particleSystem;
    public TeapotPuzzle teapotPuzzle;

    void OnMouseDown ()
    {
        particleSystem.Play ();
        teapotPuzzle.submitSmoke (smokeColor);
    }
}
