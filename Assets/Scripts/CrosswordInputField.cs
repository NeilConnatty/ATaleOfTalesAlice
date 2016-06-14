using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrosswordInputField : MonoBehaviour
{
    public string solutionLetter;

    private Transform _myTransform;
    private InputField _inputField;
    private Text _inputText;

    void Awake ()
    {
        _myTransform = this.GetComponent<Transform>();
        GameObject childText = _myTransform.Find("Text").gameObject;
        _inputText = childText.GetComponent<Text>();
        _inputField = this.GetComponent<InputField>();
    }

    public void CheckLetter ()
    {
        if (_inputText.text.Equals(solutionLetter)) {
            _inputField.interactable = false;
        }
    }

}
