using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

/*
 * Place empty GameObject in scene with this script if you want player to
 * spawn with no triangle on scene load
 */
public class TriangleKiller : MonoBehaviour
{
    private GameObject noTrianglePrefab;

    void Start ()
    {
        noTrianglePrefab = NetworkManager.singleton.gameObject.GetComponent<NetworkPlayerPrefabs>().noTrianglePrefab;
        NetworkManager.singleton.playerPrefab = noTrianglePrefab;
    }
}
