using UnityEngine;
using System.Collections;

/*
 * portal players walk through after door opens
 */
public class Portal : MonoBehaviour
{
    void OnTriggerEnter ()
    {
        GameManager.gm.EnterDoor ();
    }
}
