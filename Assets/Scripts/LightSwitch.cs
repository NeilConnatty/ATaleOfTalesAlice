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

    private Renderer _rend;

    [SyncVar(hook="StateChange")] bool blackLightOn = false;

    void Awake ()
    {
        _rend = this.GetComponent<Renderer> ();
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
