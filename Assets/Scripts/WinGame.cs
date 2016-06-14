using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public string levelAfterVictory;

    void OnMouseDown()
    {
        SceneManager.LoadScene (levelAfterVictory);
	}

}
