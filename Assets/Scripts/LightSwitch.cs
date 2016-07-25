using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent (typeof (Collider))]
[RequireComponent (typeof (Material))]
public class LightSwitch : NetworkBehaviour
{
    //public MagicWord magicWord;
    public GameObject defaultUI;
    public GameObject blacklightUI;
    public GameObject highlight;

    private Renderer _rend;
    private Renderer _highlightRenderer;

    [SyncVar(hook="StateChange")] bool blackLightOn = false;

    void Awake ()
    {
        _rend = this.GetComponent<Renderer> ();
        _highlightRenderer = highlight.GetComponent<Renderer> ();
        _highlightRenderer.enabled = false;
    }

    void OnMouseEnter ()
    {
        _highlightRenderer.enabled = true;
    }

    void OnMouseExit ()
    {
        _highlightRenderer.enabled = false;
    }

    void OnMouseDown ()
    {
        blackLightOn = !blackLightOn;
    }

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
