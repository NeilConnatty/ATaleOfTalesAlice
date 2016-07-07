using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[RequireComponent (typeof (InputField))]
[RequireComponent (typeof (Image))]
public class CrosswordInputField : MonoBehaviour
{
    public string solutionLetter;
    public Word[] words;
    // different paths for input fields shared by two words
    public InputField[] nextInputs;
    private int _previousWordNumber;

    private InputField _inputField;
    private Image _inputImage;
    private bool _hasInput;
    private bool _isHighlighted;
    private Color _unhighlightedColor;

    void Awake ()
    {
        _inputField = this.GetComponent<InputField>();
        _inputImage = this.GetComponent<Image>();
        _hasInput = false;
        _isHighlighted = false;
        _unhighlightedColor = Color.white;
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
        return _inputField.text.Equals (solutionLetter, StringComparison.CurrentCultureIgnoreCase);
    }

    public bool hasInput ()
    {
        return _hasInput;
    }

    public void setColor (Color color)
    {
        if (!_isHighlighted) {
            _inputImage.color = color;
        }
        _unhighlightedColor = color;
    }

    public Color getColor ()
    {
        return _inputImage.color;
    }

    public void makeHighlighted ()
    {
        _isHighlighted = true;
        _unhighlightedColor = _inputImage.color;
        _inputImage.color = Color.yellow;
    }

    public void makeUnhighlighted ()
    {
        _isHighlighted = false;
        _inputImage.color = _unhighlightedColor;
    }

    public void activateThisInputField (int previousWordNumber)
    {
        _previousWordNumber = previousWordNumber;
        _inputField.ActivateInputField ();
    }

    public void activateNextInputField ()
    {
        if (!nextInputs[_previousWordNumber]) return;
        nextInputs[_previousWordNumber].ActivateInputField ();
    }

}
