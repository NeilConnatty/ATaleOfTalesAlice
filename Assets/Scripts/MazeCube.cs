using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public enum CubeNumber {one = 0, two = 1, three = 2};

public class MazeCube : NetworkBehaviour
{
    [SyncVar(hook="StateChange")] bool mouseClicked = false;

    public CubeNumber cubeNum;

    private GameObject _player;

    void Start ()
    {
        _player = GameObject.FindWithTag("Player");
        if (!_player) Debug.LogError ("couldn't get player");
    }

    void OnMouseDown ()
    {
        if (!isServer) return;
        mouseClicked = true;
        TriggerEvent ();
    }

    void StateChange (bool clicked)
    {
        mouseClicked = clicked;
        TriggerEvent ();
    }

    void TriggerEvent ()
    {
        GameState.gs.loadNextScene ();
        /*
        Vector3 tempPosition = _player.GetComponent<Transform> ().position;
        tempPosition.x = 0;
        tempPosition.z = 0;
        _player.GetComponent<Transform> ().position = tempPosition;
        */
    }
}
