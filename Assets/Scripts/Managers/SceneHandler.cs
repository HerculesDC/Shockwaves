using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//named "SceneHandler" because Unity already has a "SceneManager"
public class SceneHandler : MonoBehaviour {

    private Scene m_currentScene;

    private static Scenes sceneTracker;
    public static Scenes SceneTracker { get { return sceneTracker; } }

    private static SceneHandler SC_instance = null;
    public static SceneHandler SC_Instance { get { return SC_instance; } }
    

    void Awake(){

        if (SC_instance == null) SC_instance = this;
        else if (SC_instance != this) Destroy(this.gameObject);

        m_currentScene = this.gameObject.scene;

        sceneTracker = (Scenes)m_currentScene.buildIndex;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        m_currentScene = this.gameObject.scene;
        sceneTracker = (Scenes)m_currentScene.buildIndex;
    }

    //RETHINK!!!
    public static bool RequestSceneChange(Scenes targetScene) {

        if (targetScene < Scenes.SCENE_COUNT) {

            if (targetScene == sceneTracker) {

                Debug.Log("What's the point of changing to the same scene?");
                return false;
            }
            else {

                SceneManager.LoadScene((int)targetScene);
                return true;
            }
        }
        else return false;
    }
}
