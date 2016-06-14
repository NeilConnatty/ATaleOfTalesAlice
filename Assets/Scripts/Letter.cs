using UnityEngine;
using System.Collections;

public class Letter : MonoBehaviour
{
    public string[] letters;
    public int lettersLength;

    public GameObject textDisplay;

    private TextMesh displayedLetter;
    private int _indexDisplayedLetter;

    void Start ()
    {
        _indexDisplayedLetter = 0;
        if (textDisplay) {
            displayedLetter = textDisplay.GetComponent("TextMesh") as TextMesh;
        } else {
            Debug.LogError ("No 3DText object");
        }
    }

    void Update ()
    {
        displayedLetter.text = letters[_indexDisplayedLetter];
    }

    public void LetterUp ()
    {
        _indexDisplayedLetter = (_indexDisplayedLetter + 1) % lettersLength;
    }

    public void LetterDown ()
    {
        if (_indexDisplayedLetter == 0)
            _indexDisplayedLetter = lettersLength - 1;
        else
            _indexDisplayedLetter--;
    }


}
