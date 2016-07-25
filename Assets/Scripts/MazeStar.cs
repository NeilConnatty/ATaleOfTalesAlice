using UnityEngine;
using System.Collections;

public class MazeStar : MonoBehaviour
{
    void Awake ()
    {
        State gameState = GameState.gs.getState ();
    }
}
