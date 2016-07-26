using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    void OnTriggerEnter ()
    {
        GameManager.gm.EnterDoor ();
    }
}
