using UnityEngine;
using UnityEngine.Networking;

public class OVRPlayerInitialize : NetworkBehaviour
{
    private GameObject _secondaryCamera;
    private GameObject _playerTwoUI;

    public GameObject triangle;

    void Awake ()
    {
        _secondaryCamera = GameObject.FindWithTag("P2Camera");
        _playerTwoUI = GameObject.FindWithTag("P2UI");
    }

    void Start ()
    {
        if (isServer) {
            if (_secondaryCamera) {
                _secondaryCamera.SetActive(false);
            }
            if (_playerTwoUI) {
                _playerTwoUI.GetComponent<Canvas> ().enabled = false;
            }
            if (triangle) {
                triangle.SetActive(false);
            }
            if (isLocalPlayer) {
                ((MonoBehaviour) gameObject.GetComponent("OVRPlayerController")).enabled = true;
                ((MonoBehaviour) gameObject.GetComponent("OVRSceneSampleController")).enabled = true;
                ((MonoBehaviour) gameObject.GetComponent("OVRDebugInfo")).enabled = true;
            } else {
                gameObject.SetActive(false);
            }
        } else {
            if (isLocalPlayer) {
                if (_secondaryCamera) {
                    _secondaryCamera.SetActive(true);
                }
                if (_playerTwoUI) {
                    _playerTwoUI.GetComponent<Canvas> ().enabled = true;
                }
                Destroy(this.gameObject);
            } else {
                gameObject.transform.FindChild("OVRCameraRig").gameObject.SetActive(false);
            }
        }
    }

    public void disableTriangle ()
    {
        Debug.Log ("this is called");
        if (triangle) triangle.SetActive (false);
    }
}
