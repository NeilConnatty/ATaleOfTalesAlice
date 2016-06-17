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
    public string endScene;

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

            case State.PUZZLE1 :
                StartCoroutine (ChangeScene (mazeScene));
                StartCoroutine (ChangeState (State.MAZE2));
                break;

            case State.MAZE2 :
                StartCoroutine (ChangeScene (roomTwo));
                StartCoroutine (ChangeState (State.PUZZLE2));
                break;

            case State.PUZZLE2 :
                StartCoroutine (ChangeScene (mazeScene));
                StartCoroutine (ChangeState (State.MAZE3));
                break;

            case State.MAZE3 :
                StartCoroutine (ChangeScene (roomThree));
                StartCoroutine (ChangeState (State.PUZZLE3));
                break;

            case State.PUZZLE3 :
                StartCoroutine (ChangeScene (mazeScene));
                StartCoroutine (ChangeState (State.MAZE4));
                break;

            case State.MAZE4 :
                StartCoroutine (ChangeScene (endScene));
                StartCoroutine (ChangeState (State.END));
                break;
            
        }
    }

    IEnumerator ChangeScene (string nextScene)
    {
        yield return new WaitForSeconds (0.0f);
        NetworkManager.singleton.ServerChangeScene (nextScene);
    }

    IEnumerator ChangeState (State nextState)
    {
        yield return new WaitForSeconds (1.0f);
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
        }
    }
}
