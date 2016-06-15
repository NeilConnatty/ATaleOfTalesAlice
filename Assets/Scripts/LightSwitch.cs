using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class LightSwitch : MonoBehaviour
{
    public MagicWord magicWord;

    void OnMouseDown ()
    {
        magicWord.lightSwtichOn ();
    }
}
