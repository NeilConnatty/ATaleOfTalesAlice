using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TriangleKiller : MonoBehaviour
{
    private GameObject noTrianglePrefab;

    void Start ()
    {
        noTrianglePrefab = NetworkManager.singleton.gameObject.GetComponent<NetworkPlayerPrefabs>().noTrianglePrefab;
        NetworkManager.singleton.playerPrefab = noTrianglePrefab;
    }
}
