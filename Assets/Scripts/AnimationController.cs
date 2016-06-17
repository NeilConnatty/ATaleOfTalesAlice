using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class AnimationController : MonoBehaviour
{
    public static AnimationController ac;
    public static NetworkManager nm;

    public GameObject innerMaze;
    public string levelAfterVictory;

    private Animator _mazeAnimator;

    void Awake ()
    {
        if (ac == null)
            ac = this.GetComponent<AnimationController> ();

        _mazeAnimator = innerMaze.GetComponent<Animator> ();
    }

    public void TriggerRotationOne ()
    {
        _mazeAnimator.SetTrigger ("FirstRotation");
    }

    public void TriggerRotationTwo ()
    {
        _mazeAnimator.SetTrigger ("SecondRotation");
    }

    public void LevelComplete ()
    {
        StartCoroutine (LoadNextLevel());
    }

    IEnumerator LoadNextLevel ()
    {
        yield return new WaitForSeconds (0.5f);
        NetworkManager.singleton.ServerChangeScene (levelAfterVictory);
    }
}