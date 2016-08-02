using UnityEngine;
using UnityEngine.Networking;

/*
 * Script initializing a networked player object
 */
public class ArrowKeysPlayerInitialize : NetworkBehaviour
{
    // camera denoting player 2's perspective
    private GameObject _secondaryCamera;
    // UI canvas for player 2 screen
    private GameObject _playerTwoUI;

    // triangle denoting player's direction
    public GameObject triangle;

    /*
     * initialize variables
     */
    void Awake ()
    {
        _secondaryCamera = GameObject.FindWithTag("P2Camera");
        _playerTwoUI = GameObject.FindWithTag("P2UI");
    }

    void Start ()
    {
        // check if device is hosting game (i.e. is player 1)
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
            // if this game object is controlled by the local player
            if (isLocalPlayer) {
                ((MonoBehaviour) gameObject.GetComponent("ArrowKeysLooker")).enabled = true;
                ((MonoBehaviour) gameObject.GetComponent("ArrowKeysController")).enabled = true;
                gameObject.transform.FindChild("Main Camera").gameObject.SetActive(true);
            // else this game object is not controlled by the local player
            } else {
                gameObject.SetActive(false);
            }
        // if device is not hosting game
        } else {
            // if this game object if controlled by the local player
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

    /*
     * deactivate triangle
     * triangle can be seen from first-person perspective if not disabled
     */
    public void disableTriangle ()
    {
        if (triangle) triangle.SetActive (false);
    }
}
