using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public enum State {
    START, MAZE1, PUZZLE1, MAZE2, PUZZLE2, MAZE3, PUZZLE3, MAZE4, END
}

public class GameState : NetworkBehaviour
{
    public static GameState gs;

    public string roomOne;
    public string roomTwo;
    public string roomThree;
    public string mazeScene;

    [SyncVar(hook="StateChange")] State _gameState;

    void Awake ()
    {
        if (gs!=null) {
            Destroy(this.gameObject);
        } else {
            gs = this.GetComponent<GameState> ();
            DontDestroyOnLoad(this.gameObject);
        }

        _gameState = State.MAZE1;
    }

    public void loadNextScene ()
    {
        switch (_gameState) {
            case State.START :
                break;

            case State.MAZE1 :
                StartCoroutine (ChangeScene (roomOne));
                StartCoroutine (ChangeState (State.PUZZLE1));
                break;
        }
    }

    IEnumerator ChangeScene (string nextScene)
    {
        NetworkManager.singleton.ServerChangeScene (nextScene);
    }

    IEnumerator ChangeState (State nextState)
    {
        yield return new WaitForSeconds (2.5f);
        _gameState = nextState;
    }

    void StateChange (State newState)
    {
        _gameState = newState;
        switch (_gameState) {
            case State.MAZE2 :
                AnimationController.ac.TriggerRotationOne ();
                break;

            case State.MAZE3 :
                AnimationController.ac.TriggerRotationTwo ();
                break;

            default :
                break;
        }
    }
}
