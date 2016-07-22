using UnityEngine;

public class NetworkPlayerPrefabs : MonoBehaviour
{
    public GameObject trianglePrefab;
    public GameObject noTrianglePrefab;

    void Awake ()
    {
        if (!trianglePrefab) Debug.LogError ("need to add player prefabs in NetworkManager");
        if (!noTrianglePrefab) Debug.LogError ("need to add player prefabs in NetworkManager");
    }
}
