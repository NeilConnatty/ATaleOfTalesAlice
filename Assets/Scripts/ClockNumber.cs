using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof (Text))]
public class ClockNumber : MonoBehaviour
{
    public string[] numbers;

    private int _currentPosition;
    private Text _myText;

    void Awake ()
    {
        _myText = this.gameObject.GetComponent<Text> ();
        _currentPosition = 0;
    }

    void Start ()
    {
        _myText.text = numbers[_currentPosition];
    }

    public void numberUp ()
    {
        _currentPosition = (_currentPosition+1) % numbers.Length;
        _myText.text = numbers[_currentPosition];
    }

    public void numberDown ()
    {
        if (_currentPosition == 0) _currentPosition = numbers.Length - 1;
        else _currentPosition -= 1;
        _myText.text = numbers[_currentPosition];
    }
}
