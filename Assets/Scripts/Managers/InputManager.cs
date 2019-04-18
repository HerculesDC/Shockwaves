using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private GameState m_stateTracker;
    
    void Awake() {

        m_stateTracker = GameManager.GM_State;
    }
    // Use this for initialization
	void Start () {
                    
    }
	
	// Update is called once per frame
	void Update () {

        m_stateTracker = GameManager.GM_State; //Don't forget to update state trackers!!!

        if (Input.GetKeyDown(KeyCode.N)) {

            switch (m_stateTracker) {

                case GameState.START: GameManager.RequestStateChange(GameState.SETUP);   break;
                case GameState.SETUP: GameManager.RequestStateChange(GameState.LEVEL_1); break;
                default: break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
    }
}
