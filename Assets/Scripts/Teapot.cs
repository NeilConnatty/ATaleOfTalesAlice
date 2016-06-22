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
    public ParticleSystem _particleSystem;

    void Start ()
    {
        //_particleSystem.startColor = smokeColor;
    }

    void OnMouseDown ()
    {
        if (!isServer) return;
        _particleSystem.Play();
    }
}
