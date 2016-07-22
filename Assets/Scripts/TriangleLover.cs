using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TriangleLover : MonoBehaviour
{
    private GameObject trianglePrefab;

    void Start ()
    {
        trianglePrefab = NetworkManager.singleton.gameObject.GetComponent<NetworkPlayerPrefabs>().trianglePrefab;
        NetworkManager.singleton.playerPrefab = trianglePrefab;
    }
}
