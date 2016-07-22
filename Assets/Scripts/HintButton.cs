using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HintButton : MonoBehaviour
{
    public GameObject hint;
    public Sprite offSprite;
    public Sprite clickedSprite;

    private Image _image;
    private bool _enabled;

    void Awake ()
    {
        _enabled = false;
        hint.SetActive (false);
        _image = this.gameObject.GetComponent<Image>();
        _image.sprite = offSprite;
    }

    public void OnClick ()
    {
        _enabled = !_enabled;
        hint.SetActive (_enabled);
        if (_enabled) {
            _image.sprite = clickedSprite;
        } else {
            _image.sprite = offSprite;
        }
    }
}
