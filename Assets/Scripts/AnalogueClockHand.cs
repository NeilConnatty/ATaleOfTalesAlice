using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Script describing behaviour of one hand of analogue clock
 */
public class AnalogueClockHand : MonoBehaviour
{
    // defaultImage, and highlightedImage to be displayed when
    // clock hand touched or clicked
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
