using UnityEngine;
using System.Collections;

public class TriangleKiller : MonoBehaviour
{
    private GameObject _player;
    private ArrowKeysPlayerInitialize _playerInitializer;

    void Start ()
    {
        _player = GameObject.FindWithTag ("Player");
        _playerInitializer = _player.GetComponent<ArrowKeysPlayerInitialize> ();
        _playerInitializer.disableTriangle ();
    }
}
