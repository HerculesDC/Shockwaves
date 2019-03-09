using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private static UIManager UI_instance = null;
    public static UIManager UI_Instance { get { return UI_instance; } }

    [SerializeField] private Canvas m_canvas;
                     private CanvasManager m_canvasManager;
                     private CanvasState m_canvasState;

    void Awake(){

        if (!UI_instance) UI_instance = this;
        else if (UI_instance != this) Destroy(this.gameObject);

        m_canvasManager = CanvasManager.CM_Instance;
        m_canvasState = CanvasManager.CS_State;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //currentScene = scInstance.SceneTracker;

	}

    //has to be transfered to the Canvas manager
    public void ActivateEnd() {

        //if (!m_textElement.activeInHierarchy) m_textElement.SetActive(true);
    }

    public static bool RequestUIChange(GameState newState) {
        
        CanvasState temp = CanvasState.CANVAS_COUNT; //prevents illogical state change

        if (newState < GameState.STATE_COUNT) {
            
            switch (newState) {

                case GameState.START: temp = CanvasState.START; break;
                case GameState.SETUP: temp = CanvasState.SETUP; break;
                case GameState.LEVEL_1:
                case GameState.LEVEL_2:
                case GameState.LEVEL_3:
                    temp = CanvasState.LEVEL;
                    break;
                case GameState.LEVEL_END: temp = CanvasState.END; break;
                    //THIS SHOULD BE GAME END...
                case GameState.END: temp = CanvasState.END; break;

                default:
                    Debug.Log("Not supposed to have reached here...");
                    break;
            }
        }
        return CanvasManager.RequestCanvasChange(temp);
    }
}
