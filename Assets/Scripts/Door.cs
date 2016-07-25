using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public float yRoationClosed;
    public float yRotationOpen;

    private Transform _transform;

    void Awake ()
    {
        _transform = this.gameObject.GetComponent<Transform>();
    }

    public void OpenDoor ()
    {
        Vector3 newRot = _transform.eulerAngles;
        newRot.y = yRotationOpen;
        _transform.eulerAngles = newRot;
    }

    void OnMouseDown ()
    {
        GameManager.gm.PickUpPiece ();
    }
}
