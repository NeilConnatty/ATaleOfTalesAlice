using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

/*
 * script describing the behaviour of a word in the poem on player 2's UI
 * in room 3
 */
public class PoemWord : MonoBehaviour
{
    public string solution;
    // optional alternate solution
    public string alternateSolution;

    public Color editingColor;
    public Color correctColor;
    public Color incorrectColor;

    private InputField _inputField;
    private Image _inputImage;
    private bool _isCorrect;

    public void Awake ()
    {
        _isCorrect = false;
        _inputField = this.GetComponent<InputField> ();
        _inputImage = this.GetComponent<Image>();
    }

    /*
     * called in editor whenever player finishes inputing word
     */
    public void inputSet ()
    {
        if (_inputField.text.Equals (""))
            setColor (editingColor);
        else
            checkSolution ();
    }

    void checkSolution ()
    {
        _isCorrect = _inputField.text.Equals(solution, StringComparison.CurrentCultureIgnoreCase)
                    || _inputField.text.Equals(alternateSolution, StringComparison.CurrentCultureIgnoreCase);
        if (_isCorrect) setColor (correctColor);
        else setColor (incorrectColor);
    }

    void setColor (Color color)
    {
        _inputImage.color = color;
    }

}
