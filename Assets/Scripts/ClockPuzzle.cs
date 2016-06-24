using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClockPuzzle : MonoBehaviour
{
    public Text hours;
    public Text minutes;

    public string[] hoursSolutions;
    public string[] minutesSolutions;

    public GameObject[] hints;

    public PuzzleTwoManager pm;

    public void checkSolution ()
    {
        for (int i=0; i<hints.Length; i++) {
            if (compareStrings (i)) {
                hints[i].SetActive (true);
            }
        }
    }

    bool compareStrings (int i)
    {
        return  hours.text.Equals (hoursSolutions[i]) &&
                minutes.text.Equals (minutesSolutions[i]);
    }
}
