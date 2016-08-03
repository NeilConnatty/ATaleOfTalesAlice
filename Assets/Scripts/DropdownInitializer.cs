using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class DropdownInitializer : MonoBehaviour {

	public NetworkManagerHUD managerHUD;

	void Start ()
	{
		managerHUD.listMatches ();
	}

}
