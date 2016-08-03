using UnityEngine;

/*
 * Class describing structure of different player prefabs that can be spawned
 * in different scenes
 */
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
