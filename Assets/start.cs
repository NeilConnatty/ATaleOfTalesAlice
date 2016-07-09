using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {

	public void clickBtn (string name) {

		switch (name) {

		case "Start":

			Application.LoadLevel ("Choose_Game");
			break;



		case "Quit":
			Application.Quit ();
			break;
		}

	}

		public void chooseServer (string name) {

		//Code for choosing server goes here. Variable "name" can be used as server name. At the end, loads the main scene.

		Application.LoadLevel ("Maze");
		
	}

	// Update is called once per frame
	void Update () {

	}
}