using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public enum SmokeColor {
    BLUE, CYAN, GREEN, MAGENTA, RED, YELLOW
}

[RequireComponent (typeof (Collider))]
public class Teapot : NetworkBehaviour
{
    public SmokeColor smokeColor;
    public ParticleSystem particleSystem;

    private TeapotPuzzle _teapotPuzzle;

    void Start ()
    {
        _teapotPuzzle = GameObject.FindWithTag ("TeapotPuzzle").GetComponent<TeapotPuzzle> ();
    }

    void OnMouseDown ()
    {
        if (!isServer) return;
        particleSystem.Play ();
        _teapotPuzzle.submitSmoke (smokeColor);
    }
}
