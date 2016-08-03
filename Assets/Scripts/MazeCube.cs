using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public enum CubeNumber {one = 0, two = 1, three = 2};

[RequireComponent (typeof (Collider))]
/*
 * script describing behaviour of portal in maze
 * in early prototypes, was represented by a cube, now represented by
 * a mushroom
 */
public class MazeCube : NetworkBehaviour
{
    public CubeNumber cubeNum;
    // star object that appears above portal
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

    /*
     * activate star if correct state and correct CubeNumber
     */
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
        // display highlight
        _renderer.enabled = true;
    }

    void OnMouseExit ()
    {
        // turn off highlight
        _renderer.enabled = false;
    }

    void OnMouseDown ()
    {
        // check to prevent TriggerEvent from being called multiple times
        // if player accidentally double-clicks
        if (mouseClicked) return;
        mouseClicked = true;
        TriggerEvent ();
    }

    /*
     * tell GameState to load next scene, but only if called by player one
     */
    [Server]
    void TriggerEvent ()
    {
        GameState.gs.loadNextScene ();
    }
}
