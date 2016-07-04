using UnityEngine;
using UnityEngine.Networking;

public class ArrowKeysPlayerInitialize : NetworkBehaviour
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
                ((MonoBehaviour) gameObject.GetComponent("ArrowKeysLooker")).enabled = true;
                ((MonoBehaviour) gameObject.GetComponent("ArrowKeysController")).enabled = true;
                gameObject.transform.FindChild("Main Camera").gameObject.SetActive(true);
            } else {
                gameObject.SetActive(false);
            }
        } else {
            if (isLocalPlayer) {
                gameObject.SetActive(false);
                if (_secondaryCamera) {
                    _secondaryCamera.SetActive(true);
                }
                if (_playerTwoUI) {
                    _playerTwoUI.GetComponent<Canvas> ().enabled = true;
                }
            }
        }
    }
}
