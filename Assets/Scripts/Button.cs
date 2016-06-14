using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

	public void loadLevel(string level)
	{
		SceneManager.LoadScene (level);
	}
}
