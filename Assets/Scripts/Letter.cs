using UnityEngine;
using System.Collections;

/*
 * Script describing the behaviour of a string displayed in a letter-scramble or
 * number scramble puzzle
 */
public class Letter : MonoBehaviour
{
    // array of strings representing the possible letters that can be displayed
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

    /*
     * display next letter in array
     */
    public void LetterUp ()
    {
        _indexDisplayedLetter = (_indexDisplayedLetter + 1) % lettersLength;
    }

    /*
     * display previous letter in array
     */
    public void LetterDown ()
    {
        if (_indexDisplayedLetter == 0)
            _indexDisplayedLetter = lettersLength - 1;
        else
            _indexDisplayedLetter--;
    }


}
