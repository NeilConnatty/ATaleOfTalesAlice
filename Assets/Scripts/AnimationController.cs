using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

/*
 * Script controlling the behaviour of the inner maze's animation
 * annimation triggered if game at correct GameState
 */
public class AnimationController : MonoBehaviour
{
    // static reference so can be accessed by other scripts
    public static AnimationController ac;

    public GameObject innerMaze;
    public string levelAfterVictory;

    private Animator _mazeAnimator;

    void Awake ()
    {
        if (ac == null)
            ac = this.GetComponent<AnimationController> ();

        _mazeAnimator = innerMaze.GetComponent<Animator> ();
    }

    void Start ()
    {
        State gameState = GameState.gs.getState ();
        switch (gameState) {
            case State.PUZZLE1 :
                TriggerRotationOne ();
                break;

            case State.MAZE2 :
                TriggerRotationOne ();
                break;

            case State.PUZZLE2 :
                TriggerRotationOne ();
                break;

            case State.MAZE3 :
                TriggerRotationOne ();
                break;
        }
    }

    public void TriggerRotationOne ()
    {
        _mazeAnimator.SetTrigger ("FirstRotation");
    }

    public void TriggerRotationTwo ()
    {
        _mazeAnimator.SetTrigger ("SecondRotation");
    }

    /* no longer needed?
    public void LevelComplete ()
    {
        StartCoroutine (LoadNextLevel());
    }

    IEnumerator LoadNextLevel ()
    {
        yield return new WaitForSeconds (0.5f);
        NetworkManager.singleton.ServerChangeScene (levelAfterVictory);
    }
    */
}
