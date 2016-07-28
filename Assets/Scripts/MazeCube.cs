using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public enum CubeNumber {one = 0, two = 1, three = 2};

[RequireComponent (typeof (Collider))]
public class MazeCube : NetworkBehaviour
{

    public CubeNumber cubeNum;
    public GameObject star;

    private bool mouseClicked = false;
    private GameObject _player;
    private Renderer _renderer;

    void Start ()
    {
        _player = GameObject.FindWithTag("Player");
        if (!_player) Debug.LogError ("couldn't get player");
        _renderer = this.gameObject.GetComponent<Renderer> ();
        _renderer.enabled = false;

        InitializeStar ();
    }

    void InitializeStar ()
    {
        star.SetActive (false);
        State gameState = GameState.gs.getState ();
        switch (cubeNum) {
            case CubeNumber.one :
                if (gameState == State.MAZE1) star.SetActive (true);
                break;

            case CubeNumber.two :
                if (gameState == State.MAZE2 || gameState == State.PUZZLE1)
                    star.SetActive (true);
                break;

            case CubeNumber.three :
                if (gameState == State.MAZE3 || gameState == State.PUZZLE2)
                    star.SetActive (true);
                break;
        }
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
        if (mouseClicked) return;
        mouseClicked = true;
        TriggerEvent ();
    }

    /*
    void StateChange (bool clicked)
    {
        mouseClicked = clicked;
        TriggerEvent ();
    }
    */
    [Server]
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
