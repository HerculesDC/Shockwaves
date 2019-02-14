using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager GM_instance = null;

    private SceneHandler scInstance = null;
    private uint currentScene = 0u;

    void Awake() {

        if (GM_instance == null)
                    GM_instance = this;

        else if (GM_instance != this)
                    Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);

        if (!scInstance) scInstance = SceneHandler.SC_Instance;
    }

	// Use this for initialization
	void Start () {
        if (!scInstance) scInstance = SceneHandler.SC_Instance;
    }
	
	// Update is called once per frame
	void Update () {
        currentScene = (uint)scInstance.SceneTracker;
	}
}
