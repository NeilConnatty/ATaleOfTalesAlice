using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent (typeof (Collider))]
[RequireComponent (typeof (Material))]
public class LightSwitch : NetworkBehaviour
{
    public MagicWord magicWord;

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
            _rend.material.SetColor("_Color", Color.red);
            magicWord.lightSwtichOn ();
        } else {
            _rend.material.SetColor("_Color", Color.green);
            magicWord.lightSwtichOff ();
        }
    }
}
