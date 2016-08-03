using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

struct TeapotClick {
    public SmokeColor smokeColor;
    public Color color;
    public Vector3 position;
}

/*
 * Script describing behaviour of teapot puzzle
 */
public class TeapotPuzzle : NetworkBehaviour
{
    // array of enums giving solution
    public SmokeColor[] solution;
    // reference to room's puzzle manager
    public PuzzleTwoManager pm;
    // reference to smoke particle system prefab
    public GameObject particleSystem;

    private int _numberCorrect;

    // variable to sync behaviour across network
    [SyncVar(hook="StateChange")] TeapotClick teapotClick;

    void Awake ()
    {
        _numberCorrect = 0;
    }

    [Server]
    void InitState () {
		teapotClick = new TeapotClick {
            smokeColor = SmokeColor.BLUE,
			color = Color.blue,
			position = new Vector3 (0,0,0)
		};
	}

    [Server]
    public void clickTeapot (SmokeColor smokeColor, Color color, Vector3 newPosition)
    {
        teapotClick = new TeapotClick {
                            smokeColor = smokeColor,
                            color = color,
                            position = newPosition
                        };

    }

    void submitSmoke (SmokeColor smokeColor)
    {
        // check if color is correct, if yes, check if solution reached, if no,
        // reset _numberCorrect variable
        if (solution[_numberCorrect] == smokeColor) {
            _numberCorrect++;
            if (_numberCorrect == 4) {
                solvePuzzle ();
                _numberCorrect = 0;
            }
        } else {
            _numberCorrect = 0;
        }
    }

    void solvePuzzle ()
    {
        pm.activateClockHint ();
    }

    void makeSmoke (Color color, Vector3 position)
    {
        GameObject newPS = Instantiate (particleSystem);
        newPS.transform.position = position;

        // Get particleSystem component, set its color, then play it
        ParticleSystem ps = newPS.GetComponent<ParticleSystem>();
        ps.startColor = color;
        ps.Play ();

        Destroy(newPS, 10.0f);
    }

    void StateChange (TeapotClick potClick)
    {
        teapotClick = potClick;
        // make smoke white on player one's screen, coloured on player two
        if (isServer) {
            makeSmoke (Color.white, teapotClick.position);
        } else {
            makeSmoke (teapotClick.color, teapotClick.position);
        }
        submitSmoke (teapotClick.smokeColor);

    }
}
