using UnityEngine;
using System.Collections;

/*
 * Destroy GameState from previous game
 */
public class GameStateKiller : MonoBehaviour {

	private GameObject _gameState;

	void Start () {
		_gameState = GameState.gs.gameObject;
		if (_gameState) Destroy (_gameState);
	}

}
