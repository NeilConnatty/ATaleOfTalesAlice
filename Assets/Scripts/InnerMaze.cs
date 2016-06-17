using UnityEngine;
using System.Collections;

public class InnerMaze : MonoBehaviour {

	private bool _initialized = false;

	// Hack to initialize innerMaze y position
	void Update () {
		//if (_initialized) return;
		Vector3 tempPosition = this.GetComponent<Transform> ().position;
        tempPosition.y = 7;
        this.GetComponent<Transform> ().position = tempPosition;
	}


}
