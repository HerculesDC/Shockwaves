using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



//named "SceneHandler" because Unity already has a "SceneManager"
public class SceneHandler : MonoBehaviour {

    private Scene currentScene;

    private Scenes sceneTracker;
    public Scenes SceneTracker { get { return sceneTracker; } }

    private static SceneHandler SC_instance = null;
    public static SceneHandler SC_Instance { get { return SC_instance; } }
    

    void Awake(){

        if (SC_instance == null) SC_instance = this;
        //else if (SC_instance != this) SC_instance = this;

        currentScene = this.gameObject.scene;

        sceneTracker = (Scenes)currentScene.buildIndex;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        sceneTracker = (Scenes)currentScene.buildIndex;
    }

    public void ChangeScene(Scenes targetScene) { SceneManager.LoadScene((int)targetScene); }
}
