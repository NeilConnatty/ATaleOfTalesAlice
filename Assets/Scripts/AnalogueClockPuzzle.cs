using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnalogueClockPuzzle : MonoBehaviour
{
    public AnalogueClockHand hoursHand;
    public AnalogueClockHand minutesHand;

    public float[] hoursSolutionAngles;
    public float[] minutesSolutionAngles;

    public GameObject[] hints;

    public float minutes_wiggle_room = 15.0f;
    public float hours_wiggle_room = 15.0f;

    void Start ()
    {
        for (int i=0; i<hints.Length; i++) {
            hints[i].SetActive (false);
        }
    }

    void Update ()
    {
        checkSolution ();
    }

    void checkSolution ()
    {
        for (int i=0; i<hints.Length; i++) {
            if (correctAngles (i)) {
                hints[i].SetActive (true);
            }
        }
    }

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
