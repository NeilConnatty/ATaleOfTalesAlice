using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnalogueClockHand : MonoBehaviour
{
    public Sprite defaultImage;
    public Sprite highlightedImage;

    private Image _imageScript;

    void Awake ()
    {
        _imageScript = this.gameObject.GetComponent<Image> ();
    }

    void Start ()
    {
        setDefaultImage ();
    }

    public void setDefaultImage ()
    {
        _imageScript.sprite = defaultImage;
    }

    public void setHighlightedImage ()
    {
        _imageScript.sprite = highlightedImage;
    }

    // return z value of rotation as euler-angle
    public float getZRotation ()
    {
        return this.gameObject.transform.rotation.eulerAngles.z;
    }
}
