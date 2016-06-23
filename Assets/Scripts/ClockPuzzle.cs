using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClockPuzzle : MonoBehaviour
{
    public Text hours;
    public Text minutesTens;
    public Text minutesOnes;

    public string hoursSolution;
    public string minutesTensSolution;
    public string minutesOnesSolution;

    public PuzzleTwoManager pm;

    public void checkSolution ()
    {
        if (compareStrings ()) {
            pm.finishClockPuzzle ();
        }
    }

    bool compareStrings ()
    {
        return  hours.text.Equals (hoursSolution) &&
                minutesTens.text.Equals (minutesTensSolution) &&
                minutesOnes.text.Equals (minutesOnesSolution);
    }
}
