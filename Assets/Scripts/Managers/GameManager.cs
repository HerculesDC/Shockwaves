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
    private uint m_currentScene = 0u;

    private float m_waitTime = 3.0f;
    private float m_elapsedTime = 0.0f;

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

            Debug.Log(m_previousState);
            Debug.Log(GM_state);
            if (GM_state != GameState.LEVEL_END)
                m_previousState = GM_state;

            UpdateUIState(GM_state); //UI has to be updated independently of level
            UpdateScene(GM_state);//logic error...           
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
                if (!SceneHandler.RequestSceneChange(Scenes.LEVEL_1)) Debug.Log("Unable to change levels...");
                break;
            case GameState.LEVEL_2:
                if (!SceneHandler.RequestSceneChange(Scenes.LEVEL_2)) Debug.Log("Unable to change levels...");
                break;
            case GameState.LEVEL_3:
                if (!SceneHandler.RequestSceneChange(Scenes.LEVEL_3)) Debug.Log("Unable to change levels...");
                break;
            case GameState.LEVEL_END:
                if (m_elapsedTime < m_waitTime) m_elapsedTime += Time.deltaTime;
                else Restate();
                break; //to implement level transitions
            case GameState.GAME_END:
                break;
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

    void ResetTimer() { m_elapsedTime = 0.0f; }

    void Restate() {

        switch (m_previousState) {

            case GameState.LEVEL_1: ResetTimer(); GM_state = GameState.LEVEL_2;  break;
            case GameState.LEVEL_2: ResetTimer(); GM_state = GameState.LEVEL_3;  break;
            case GameState.LEVEL_3: ResetTimer(); GM_state = GameState.GAME_END; break;
            default: Debug.Log("REPORTING ERROR!"); break;
        }
    }
}