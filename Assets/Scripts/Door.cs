using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public float yRoationClosed;
    public float yRotationOpen;
    public GameObject portal;

    private Transform _transform;

    void Start ()
    {
        _transform = this.gameObject.GetComponent<Transform>();
        Vector3 newRot = _transform.eulerAngles;
        newRot.y = yRoationClosed;
        _transform.eulerAngles = newRot;

        portal.SetActive(false);
    }

    public void OpenDoor ()
    {
        Vector3 newRot = _transform.eulerAngles;
        newRot.y = yRotationOpen;
        _transform.eulerAngles = newRot;

        portal.SetActive(true);
    }
}
