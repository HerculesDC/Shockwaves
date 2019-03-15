using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager GM_instance;
    public static GameManager GM_Instance { get { return GM_instance; } }

    private GameState m_previousState;
    private static GameState GM_state;
    public static GameState GM_State { get { return GM_state; } }

    private UIManager m_UIInstance = null;
    private SceneHandler m_SCInstance = null;
    private uint currentScene = 0u;

    void Awake() {

        if (GM_instance == null)
                    GM_instance = this;

        else if (GM_instance != this)
                    Destroy(this.gameObject);

        m_previousState = GameState.START;
        GM_state = GameState.START;

        DontDestroyOnLoad(this.gameObject);

        if (!m_UIInstance) m_UIInstance = UIManager.UI_Instance;
        if (!m_SCInstance) m_SCInstance = SceneHandler.SC_Instance;
    }

	// Use this for initialization
	void Start () {

        if (!m_SCInstance) m_SCInstance = SceneHandler.SC_Instance;
    }
	
	// Update is called once per frame
	void Update () {

        if (m_previousState != GM_state) {
            
            UpdateUIState(GM_state); //UI has to be updated independently of level
            UpdateScene(GM_state);//logic error...
            //implemented for level tracking
            if (GM_state != GameState.LEVEL_END) m_previousState = GM_state;
        }
	}

    void UpdateUIState(GameState newState) {

        if(!m_UIInstance.RequestUIChange(newState)) Debug.Log ("Unable to change UI state...");
    }

    void UpdateScene(GameState newLevel) {

        switch (newLevel) {
            case GameState.START: 
            case GameState.SETUP:
                //As per current settings, GameState.START and GameState.SETUP shouldn't change scenes. Only UI states
                break;
            case GameState.LEVEL_1:
                if (!SceneHandler.RequestSceneChange(Scenes.TEST)) Debug.Log("Unable to change levels...");
                break;
            case GameState.LEVEL_2:
            case GameState.LEVEL_3:
                //these levels aren't implemented yet. But they'll take a similar code path
                break;
            case GameState.LEVEL_END: break; //to implement level transitions
            default: break;
        }
    }

    public static bool RequestStateChange(GameState target) {

        if (target < GameState.STATE_COUNT) {

            if (target == GM_state) {

                Debug.Log("Cannot change to same state...");
                return false;
            }
            GM_state = target;
        }
        return GM_state == target;
    }
}

