using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof (InputField))]
[RequireComponent (typeof (Image))]
public class CrosswordInputField : MonoBehaviour
{
    public string solutionLetter;

    private Transform _myTransform;
    private InputField _inputField;
    private Text _inputText;
    private Image _inputImage;
    private bool _hasInput;

    void Awake ()
    {
        _myTransform = this.GetComponent<Transform>();
        GameObject childText = _myTransform.Find("Text").gameObject;
        _inputText = childText.GetComponent<Text>();
        _inputField = this.GetComponent<InputField>();
        _inputImage = this.GetComponent<Image>();
    }

    public void inputSet (bool input)
    {
        _hasInput = input;
    }

    public void makeUninteractable ()
    {
        _inputField.interactable = false;
    }

    public bool isSolution ()
    {
        return _inputText.text.Equals (solutionLetter);
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
