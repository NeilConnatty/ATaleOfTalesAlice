using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PoemWord : MonoBehaviour
{
    public string solution;
    // optional alternate solution
    public string alternateSolution;

    private InputField _inputField;
    private Image _inputImage;
    private bool _isCorrect;

    public void Awake ()
    {
        _isCorrect = false;
        _inputField = this.GetComponent<InputField> ();
        _inputImage = this.GetComponent<Image>();
    }

    public void inputSet ()
    {
        if (_inputField.text.Equals (""))
            setColor (Color.white);
        else
            checkSolution ();
    }

    void checkSolution ()
    {
        _isCorrect = _inputField.text.Equals(solution, StringComparison.CurrentCultureIgnoreCase)
                    || _inputField.text.Equals(alternateSolution, StringComparison.CurrentCultureIgnoreCase);
        if (_isCorrect) setColor (Color.green);
        else setColor (Color.red);
    }

    void setColor (Color color)
    {
        _inputImage.color = color;
    }

}
