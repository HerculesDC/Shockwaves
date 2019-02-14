using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private GameManager gmInstance = null;
    private SceneHandler scInstance = null;

    private uint currentScene = 0u;
    
    void Awake() {
        gmInstance = GameManager.GM_instance;
        scInstance = SceneHandler.SC_Instance;
    }
    // Use this for initialization
	void Start () {
        if (!gmInstance) gmInstance = GameManager.GM_instance;
        if (!scInstance) scInstance = SceneHandler.SC_Instance;
            currentScene = (uint)scInstance.SceneTracker;
    }
	
	// Update is called once per frame
	void Update () {

        switch (currentScene) {

            case 0: scInstance.ChangeScene(Scenes.SETUP); break;
            case 1: scInstance.ChangeScene(Scenes.TEST); break;

            default: break;
        }
	}
}
