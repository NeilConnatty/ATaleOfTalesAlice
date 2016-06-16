using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof (InputField))]
[RequireComponent (typeof (Image))]
public class CrosswordInputField : MonoBehaviour
{
    public string solutionLetter;
    public Word[] words;

    private Transform _myTransform;
    private InputField _inputField;
    private Image _inputImage;
    private bool _hasInput;

    void Awake ()
    {
        _myTransform = this.GetComponent<Transform>();
        GameObject childText = _myTransform.Find("Text").gameObject;
        _inputField = this.GetComponent<InputField>();
        _inputImage = this.GetComponent<Image>();
        _hasInput = false;
    }

    public void inputSet ()
    {
        if (_inputField.text.Equals (""))
            _hasInput = false;
        else
            _hasInput = true;

        foreach (Word word in words) {
            word.inputUpdate ();
        }
    }

    public void makeUninteractable ()
    {
        _inputField.interactable = false;
    }

    public bool isSolution ()
    {
        return _inputField.text.Equals (solutionLetter);
    }

    public bool hasInput ()
    {
        return _hasInput;
    }

    public void setColor (Color color)
    {
        _inputImage.color = color;
    }

    public Color getColor ()
    {
        return _inputImage.color;
    }

}
