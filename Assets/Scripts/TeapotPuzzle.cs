using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

struct TeapotClick {
    public SmokeColor color;
    public Vector3 position;
}

public class TeapotPuzzle : NetworkBehaviour
{
    public SmokeColor[] solution;
    public PuzzleTwoManager pm;
    public GameObject particleSystem;

    private int _numberCorrect;

    [SyncVar(hook="StateChange")] TeapotClick teapotClick;

    void Awake ()
    {
        _numberCorrect = 0;
    }

    [Server]
    void InitState () {
		teapotClick = new TeapotClick {
			color = SmokeColor.BLUE,
			position = new Vector3 (0,0,0)
		};
	}

    [Server]
    public void clickTeapot (SmokeColor color, Vector3 newPosition)
    {
        teapotClick = new TeapotClick {
                            color = color,
                            position = newPosition
                        };

    }

    void submitSmoke (SmokeColor color)
    {
        if (solution[_numberCorrect] == color) {
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

    void makeSmoke (SmokeColor color, Vector3 position)
    {
        GameObject newPS = Instantiate (particleSystem);
        newPS.transform.position = position;

        // Get particleSystem component, set its color, then play it
        ParticleSystem ps = newPS.GetComponent<ParticleSystem>();
        switch (color) {
            case SmokeColor.WHITE :
                ps.startColor = Color.white;
                break;
            case SmokeColor.BLUE :
                ps.startColor = Color.blue;
                break;
            case SmokeColor.CYAN :
                ps.startColor = Color.cyan;
                break;
            case SmokeColor.GREEN :
                ps.startColor = Color.green;
                break;
            case SmokeColor.MAGENTA :
                ps.startColor = Color.magenta;
                break;
            case SmokeColor.RED :
                ps.startColor = Color.red;
                break;
            case SmokeColor.YELLOW :
                ps.startColor = Color.yellow;
                break;
        }
        ps.Play ();

        Destroy(newPS, 10.0f);
    }

    void StateChange (TeapotClick potClick)
    {
        teapotClick = potClick;
        if (isServer) {
            makeSmoke (SmokeColor.WHITE, teapotClick.position);
        } else {
            makeSmoke (teapotClick.color, teapotClick.position);
        }
        submitSmoke (teapotClick.color);

    }
}
