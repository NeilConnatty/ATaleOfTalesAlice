using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

/*
 * Place empty GameObject in scene with this script if you want player to
 * spawn with triangle on scene load
 */
public class TriangleLover : MonoBehaviour
{
    private GameObject trianglePrefab;

    void Start ()
    {
        trianglePrefab = NetworkManager.singleton.gameObject.GetComponent<NetworkPlayerPrefabs>().trianglePrefab;
        NetworkManager.singleton.playerPrefab = trianglePrefab;
    }
}
