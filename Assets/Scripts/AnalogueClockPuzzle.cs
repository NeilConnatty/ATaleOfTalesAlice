using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Script describing behaviour of Analogue clock puzzle
 */
public class AnalogueClockPuzzle : MonoBehaviour
{
    // two hands of clock
    public AnalogueClockHand hoursHand;
    public AnalogueClockHand minutesHand;
    // arrays containing angles hands must be at for solution
    public float[] hoursSolutionAngles;
    public float[] minutesSolutionAngles;
    // array containing GameObjects to be activated when solution reached
    public GameObject[] hints;

    public float minutes_wiggle_room = 15.0f;
    public float hours_wiggle_room = 15.0f;

    void Start ()
    {
        // deactivate all hints
        for (int i=0; i<hints.Length; i++) {
            hints[i].SetActive (false);
        }
    }

    void Update ()
    {
        checkSolution ();
    }

    /*
     * activate corresponding hint if correct solution reached
     */
    void checkSolution ()
    {
        for (int i=0; i<hints.Length; i++) {
            if (correctAngles (i)) {
                hints[i].SetActive (true);
            }
        }
    }

    /*
     * return true if solution reached
     * solution reached if hour hand's angle == hoursSolutionAngles[i]
     * AND if minute hand's angle == minutesSolutionAngles[i]
     */
    bool correctAngles (int i)
    {
        float hoursAngle = hoursHand.getZRotation ();
        float hoursSolution = hoursSolutionAngles[i];
        float minutesAngle = minutesHand.getZRotation ();
        float minutesSolution = minutesSolutionAngles[i];

        return (hoursAngle >= hoursSolution - hours_wiggle_room && hoursAngle <= hoursSolution + hours_wiggle_room)
            && (minutesAngle >= minutesSolution - minutes_wiggle_room && minutesAngle <= minutesSolution + minutes_wiggle_room);
    }
}
