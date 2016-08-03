using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent (typeof (Collider))]
[RequireComponent (typeof (Material))]
/*
 * Script describing behaviour of light switch in puzzle room one
 */
public class LightSwitch : NetworkBehaviour
{
    // default UI to be displayed on player 2's screen
    public GameObject defaultUI;
    // UI to be displayed when light turned on
    public GameObject blacklightUI;
    // highlight to turn on when mouse hovers over object
    public GameObject highlight;

    private Renderer _rend;
    private Renderer _highlightRenderer;

    // variable to sync behaviour over network
    [SyncVar(hook="StateChange")] bool blackLightOn = false;

    void Awake ()
    {
        _rend = this.GetComponent<Renderer> ();
        _highlightRenderer = highlight.GetComponent<Renderer> ();
        _highlightRenderer.enabled = false;
    }

    void OnMouseEnter ()
    {
        // display highlight
        _highlightRenderer.enabled = true;
    }

    void OnMouseExit ()
    {
        // turn off highlight
        _highlightRenderer.enabled = false;
    }

    void OnMouseDown ()
    {
        blackLightOn = !blackLightOn;
    }

    /*
     * syncronize behaviour over network
     */
    void StateChange (bool newState)
    {
        blackLightOn = newState;

        if (blackLightOn) {
            _rend.sharedMaterial.SetColor("_Color", Color.green);
            defaultUI.SetActive (false);
            blacklightUI.SetActive (true);
            //magicWord.lightSwtichOn ();
        } else {
            _rend.sharedMaterial.SetColor("_Color", Color.red);
            defaultUI.SetActive (true);
            blacklightUI.SetActive (false);
            //magicWord.lightSwtichOff ();
        }
    }
}
