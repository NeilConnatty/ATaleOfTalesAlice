using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TriangleKiller : MonoBehaviour
{
    public GameObject noTrianglePlayerPrefab;

    void Start ()
    {
        NetworkManager.singleton.playerPrefab = noTrianglePlayerPrefab;
    }
}
